using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
//using FileUploadDownloadApp;

namespace SecureFileTransfer
{
    public partial class UploadDocument : System.Web.UI.Page
    {
        SecureFileTransfer.FileUploadDownloadOperations objFileUploadDownloadApp = new SecureFileTransfer.FileUploadDownloadOperations();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                refreshdata();
            }
        }

        /// <summary>
        /// To Bind Grid Data
        /// </summary>
        public void refreshdata()
        {
            DataTable dt = new DataTable();
            try
            {
                if (objFileUploadDownloadApp.GetFileName().Rows.Count > 0)
                {
                    dt = objFileUploadDownloadApp.GetFileName();
                }
                //else
                //{

                //    dt.Columns.Add("File", typeof(string));
                //    foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
                //    {
                //        FileInfo fi = new FileInfo(strFile);
                //        dt.Rows.Add(fi.Name);
                //    }
                //}
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error while binding data to grid');</script>");
            }
        }

        /// <summary>
        /// To Upload Files into File System and Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile && TextBox1.Text != "")
                {
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
                    FileInfo file = new FileInfo(Server.MapPath("~/Data/") + FileUpload1.FileName);
                    objFileUploadDownloadApp.UploadFile(Server.MapPath("~/Data/") + FileUpload1.FileName, TextBox1.Text);
                    Response.Write("<script>alert('File Uploaded Successfully');</script>");
                    refreshdata();
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Security Key');</script>");
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error while Uploading File');</script>");
            }


        }


        /// <summary>
        /// To Get scripted Extension of the file
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        private string GetFileTypeByExtension(string extension)
        {
            switch (extension.ToLower())
            {
                case ".doc":
                case ".docx":
                    return "Microsoft Word document";
                case ".xls":
                case ".xlsx":
                    return "Microsoft Excel document";
                case ".jpg":
                case ".png":
                    return "Image";
                case ".txt":
                    return "Text document";
                default:
                    return "Unknown";
            }
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                Response.Clear();
                Response.ContentType = "application/octect-stream";
                Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
                Response.TransmitFile(Server.MapPath("~/Data/") + e.CommandArgument);
                Response.End();

            }
        }

        /// <summary>
        /// To Download Files to the given destination folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            DatabaseOpe DBO = new DatabaseOpe();
            string passKey = "";
            string FileToBeDownloaded = string.Empty;

            try
            {
                foreach (GridViewRow gvrow in GridView1.Rows)
                {
                    var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                    if (checkbox.Checked)
                    {
                        var FileName = gvrow.FindControl("Label2") as Label;
                        FileToBeDownloaded = FileName.Text;
                        break;
                    }
                }
                if (FileToBeDownloaded == string.Empty)
                {
                    Response.Write("<script>alert('Please check atlist one checkbox');</script>");
                    return;
                }
                Byte[] data = DBO.GetDocumentFromDb(FileToBeDownloaded, out passKey);
                if (passKey == TextBox2.Text)
                {
                    objFileUploadDownloadApp.DownloadFile(@"D:\SecureFiles", FileToBeDownloaded, TextBox2.Text);
                }
                else
                {
                    Response.Write("<script>alert('Please enter valid Security Key');</script>");
                }

            }
            catch (Exception)
            {
                Response.Write("<script>alert('Exception while downloading files');</script>");
            }
        }
    }
}