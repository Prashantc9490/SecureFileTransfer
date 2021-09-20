using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureFileTransfer
{
    public class DatabaseOpe
    {
        string connectionstring = "Data Source = UTS-SATISHC;Initial Catalog = testdb; User ID = sa; Password = uts@123";

        public bool InsertDocumentInDb(string fileName, byte[] fileData, string passKey, string actualFileSize, string zipFileSize)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionstring;
                    conn.Open();
                    SqlCommand cmd;
                    string s = "INSERT INTO StoreFiles (FileName,Data,PasswordKey,ActualSize,ZipSize)VALUES(@fileName,@Data,@passwordKey,@actualSize,@zipSize)";
                    cmd = new SqlCommand(s, conn);
                    cmd.Parameters.AddWithValue("@fileName", fileName);
                    cmd.Parameters.AddWithValue("@Data", fileData);
                    cmd.Parameters.AddWithValue("@passwordKey", passKey);
                    cmd.Parameters.AddWithValue("@actualSize", actualFileSize);
                    cmd.Parameters.AddWithValue("@zipSize", zipFileSize);
                    cmd.CommandType = CommandType.Text;
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    return false;
                }
                return true;
            }
        }
        public byte[] GetDocumentFromDb(string fileName, out string passKey)
        {
            byte[] byteData = null;
            passKey = "";
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionstring;
                    conn.Open();
                    string query = "SELECT * FROM StoreFiles where FileName = '" + fileName + "'";
                    SqlCommand selectCommand = new SqlCommand(query, conn);
                    SqlDataReader reader = selectCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        byteData = (byte[])reader[3];
                        passKey = Convert.ToString(reader[2]);
                        string strData = Encoding.UTF8.GetString(byteData);
                        Console.WriteLine(strData);
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return byteData;
                }
                return byteData;
            }
        }
        public DataTable GetDocumentListFromDb()
        {

            List<string> files = new List<string>();
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection())
            {

                try
                {
                    conn.ConnectionString = connectionstring;
                    string query = "SELECT FileName FROM StoreFiles";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    // this will query your database and return the result to your datatable
                    da.Fill(dataTable);

                    conn.Close();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return dataTable;
                }
                return dataTable;
            }
        }
    }
}
