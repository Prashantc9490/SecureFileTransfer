using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecureFileTransfer
{
    public class FileUploadDownloadOperations
    {
        ZipAndUnzipLogic zipClass = new ZipAndUnzipLogic();
        EncryptionAndDecryptionLogic enCnLogic = new EncryptionAndDecryptionLogic();
        DatabaseOpe databaseOpe = new DatabaseOpe();


        public void UploadFile(string filePath, string password)
        {
            string actualFileSize = string.Empty;
            string zipFileSize = string.Empty;

            string tempPath = Path.GetTempPath() + Path.GetFileName(Path.GetFileName(filePath));

            actualFileSize = ConvertBytesToMegabytes(filePath);

            enCnLogic.FileEncrypt(filePath, password);

            zipClass.ZipFile(filePath + ".aes", Path.GetFileName(filePath), out string zipFilePath);

            zipFileSize = ConvertBytesToMegabytes(zipFilePath);

            byte[] data = File.ReadAllBytes(zipFilePath);

            databaseOpe.InsertDocumentInDb(Path.GetFileName(filePath), data, password, actualFileSize, zipFileSize);
        }


        string ConvertBytesToMegabytes(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            return (fileInfo.Length / 1024).ToString() + " kb";
        }

        public void DownloadFile(string destFileSavePath, string fileName, string password)
        {
            string passKey = "";
            Byte[] data = databaseOpe.GetDocumentFromDb(fileName, out passKey);
            if (passKey == password)
            {
                string finalDestinationPath = Path.GetTempPath() + "\\" + fileName + ".zip";
                using (var fs = new FileStream(finalDestinationPath, FileMode.Create, FileAccess.Write))
                    fs.Write(data, 0, data.Length);
                zipClass.UnZippedFile(finalDestinationPath, fileName);
                string extractPath = Path.GetDirectoryName(finalDestinationPath) + "\\" + fileName + ".aes";
                enCnLogic.FileDecrypt(extractPath, @"D:\\response\\" + fileName, password);
            }
            else
            {
                //MessageBox.Show("Invalid password please check.");
            }
        }



        //private void UploadFileInDb(string fileFullPath, string password)
        //{
        //    string filePath = fileFullPath;
        //    byte[] data = File.ReadAllBytes(filePath);
        //    string result = Encoding.UTF8.GetString(data);
        //    result = Encrypt(result, password);
        //    DatabaseOpe databaseOpe = new DatabaseOpe();
        //    databaseOpe.InsertDocumentInDb(Path.GetFileName(filePath), Encoding.ASCII.GetBytes(result), "12345");
        //}
        private void DownloadFileDatabase(string fileNameWithExt, string password)
        {
            string fileName = fileNameWithExt;
            DatabaseOpe databaseOpe = new DatabaseOpe();
            string passKey = "";
            Byte[] data = databaseOpe.GetDocumentFromDb(fileName, out passKey);

            if (passKey == password)
            {
                string res = Decrypt(Encoding.ASCII.GetString(data), password);
                string tempPath = Path.GetTempPath() + Path.GetFileName(fileName);
                File.WriteAllBytes(tempPath, Encoding.ASCII.GetBytes(res));
            }
            else
            {
                ///MessageBox.Show("Invalid password please check.");
            }
        }

        public string Decrypt(string cipher, string key)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        try
                        {
                            byte[] cipherBytes = Convert.FromBase64String(cipher);
                            byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                            return UTF8Encoding.UTF8.GetString(bytes);
                        }
                        catch (Exception ex)
                        {
                            // MessageBox.Show("Invalid password please check.");
                            return "";
                        }
                    }
                }
            }
        }


        public string Encrypt(string text, string key)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        public DataTable GetFileName()
        {
            DataTable dt = new DataTable();
            try
            {
                DatabaseOpe dbo = new DatabaseOpe();
                dt = dbo.GetDocumentListFromDb();
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }
    }
}
