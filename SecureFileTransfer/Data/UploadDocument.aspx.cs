using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using FileUploadDownloadApp;

public partial class UploadDocument : System.Web.UI.Page
{
    FileUploadDownloadOperations objFileUploadDownloadApp = new FileUploadDownloadOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshdata();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile && TextBox1.Text != "")
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
            objFileUploadDownloadApp.UploadFileInDb(Server.MapPath("~/Data/")+ FileUpload1.FileName, TextBox1.Text);
            
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
        

    }

    public void refreshdata()
    {
        //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        DataTable dt = new DataTable();
        dt.Columns.Add("File", typeof(string));
        dt.Columns.Add("Size", typeof(string));
        dt.Columns.Add("Type", typeof(string));

        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
        {
            FileInfo fi = new FileInfo(strFile);
            dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtension(fi.Extension));
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
        if(e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "fileName=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Data/")+e.CommandArgument);
            Response.End();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            objFileUploadDownloadApp.DownloadFileDatabase("PerformanceExecutionLog (1).txt", "12345");
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
        }
        else
        {
            Response.Write("<script>alert('Please Enter Security Key');</script>");
        }
    }
}
