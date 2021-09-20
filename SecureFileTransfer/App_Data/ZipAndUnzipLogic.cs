using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureFileTransfer
{
    class ZipAndUnzipLogic
    {
        /// <summary>
        /// Member function for zipping a file and storing it at source location.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="logicalFileName"></param>
        /// <param name="zipFilePath"></param>
        internal bool ZipFile(string path, string fileName, out string zipFilePath)
        {
            bool status = false;
            zipFilePath = "";
            try
            {
                string output = Path.GetTempPath() + "\\" + fileName + ".zip";
                string input = path;
                using (var zipStream = new ICSharpCode.SharpZipLib.Zip.ZipOutputStream(System.IO.File.Create(output)))
                {
                    zipStream.SetLevel(9);
                    var buffer = new byte[4096];
                    var entry = new ICSharpCode.SharpZipLib.Zip.ZipEntry(Path.GetFileName(input));
                    zipStream.PutNextEntry(entry);

                    using (FileStream fs = System.IO.File.OpenRead(input))
                    {
                        int sourceBytes;
                        do
                        {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            zipStream.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }
                    zipFilePath = output;

                    zipStream.Finish();
                    zipStream.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Zip file failed " + ex.Message);
            }
            return status;
        }


        /// <summary>
        /// Member function to unzip a file at destination location.
        /// </summary>
        /// <param name="destinationUnZipFilePath"></param>
        /// <returns></returns>
        internal bool UnZippedFile(string destinationUnZipFilePath, string fileName)
        {
            bool status = false;
            try
            {
                string actualpath = destinationUnZipFilePath;
                string extractPath = Path.GetDirectoryName(destinationUnZipFilePath);

                string fileNameWithEx = extractPath + "\\" + fileName;
                ICSharpCode.SharpZipLib.Zip.FastZip fastZip = new ICSharpCode.SharpZipLib.Zip.FastZip();
                string fileFilter = null;
                // Will always overwrite if target filenames already exist
                fastZip.ExtractZip(actualpath, extractPath, fileFilter);
                status = true;
                File.Delete(actualpath);
                //To delete the zipped file at source
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = false;
            }
            return status;

        }
    }
}
