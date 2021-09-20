<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadDocument.aspx.cs" Inherits="SecureFileTransfer.UploadDocument" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        /*body{font-size: 1.1em;}
        .upload-container, .download-container, .title-wrapper{width: 100%;box-sizing: border-box;border: 1px solid #000; border-radius: 10px;padding: 10px 15px;margin-bottom: 30px;}
        .file-browser-wrapper{width: 100%;box-sizing: border-box;display: flex; align-items: center; justify-content: flex-start;padding: 15px;}
        .btn-wrapper{margin-left:50px;}
        label{margin-right: 15px;}
        input[type="text"]{height: 25px; border: 1px solid #222;}
        input[type="text"], button{border-radius: 4px;}
        button{padding: 8px 15px; background-color: #1c7be5;color: #fff; border: 1px solid #1c7be5;    font-size: .9em; transition: .4s all ease;}
        button:hover{cursor: pointer;background-color: #0f69cf;}
        .btn-download{background:#11a317;border: 1px solid #11a317;}
        .btn-download:hover{background-color:#0d9f13;}*/
        @font-face {
            font-family: OpenSans;
            src: url(CSS/OpenSans-Regular.ttf);
        }

        * {
            font-family: OpenSans;
        }

        body {
            font-size: 1.1em;
        }

        .container {
            width: 90%;
            box-sizing: border-box;
            border-radius: 10px;
            padding: 10px 15px;
            margin-bottom: 30px;
            -webkit-box-shadow: 0 0 10px #ccc;
            box-shadow: 0 0 10px #ccc;
            margin: 30px auto;
        }

        .title {
            font-size: 1.6em;
        }

        .input-wrapper, .btn-wrapper {
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 15px;
        }

        .btn-wrapper {
            justify-content: flex-end;
        }

        label {
            margin-right: 15px;
        }

        input[type="text"] {
            height: 30px;
            border: 1px solid #222;
        }

        input[type="text"], button {
            border-radius: 4px;
        }
        .label {margin-right:15px;}

        .btn-upload, .btn-download  {
            padding: 8px 15px;
            background-color: #1c7be5;
            color: #fff;
            border: 1px solid #1c7be5;
            font-size: .9em;
            transition: .4s all ease;
            border-radius: 4px;
        }

            .btn-upload:hover {
                cursor: pointer;
                background-color: #0f69cf;
            }

        .btn-download {
            background: #11a317;
            border: 1px solid #11a317;
        }

            .btn-download:hover {
                background-color: #0d9f13;
            }

        .download-wrapper, .upload-wrapper {
            width: 100%;
            box-sizing: border-box;
            display: flex;
            align-items: center;
            justify-content: start;
        }

        .sub_title {
            border-bottom: 1px solid #ccc;
            padding-bottom: 10px;
        }

        .col {
            width: 50%;
            display: flex;
            flex-direction: row;
            align-items: center;
            justify-content: center;
        }

        .container-row {
            display: flex;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        

            <div>

                <div class="container">
                    <h3>Secure File Reduce Space</h3>
                </div>

                <!-- Upload Container -->
                <div class="container">
                    <h3 class="sub_title">Upload</h3>
                    <div class="upload-wrapper">
                        <div class="file-browser">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </div>

                        <div class="input-wrapper">
                            <asp:Label ID="Label1" CssClass="label" runat="server" Text="Security Key" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="TextBox1" runat="server" Width="139px"></asp:TextBox>
                        </div>

                        <div class="btn-wrapper">
                            <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" CssClass="btn-upload" Width="113px" />
                        </div>
                    </div>
                </div>

                <!-- Download Container -->
                <div class="container">
                    <div class="download-container">
                        <h3 class="sub_title">Download</h3>                        
                        <div class="container-row">
                            <div class="col">
                                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Select Data">
                                            <EditItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="File Name">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("FileName") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("FileName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                    <RowStyle BackColor="White" ForeColor="#330099" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                                </asp:GridView>
                            </div>
                            <div class="col">
                                <div class="input-wrapper">
                                    <asp:Label ID="Label2"  CssClass="label" runat="server" Text="Security Key" Font-Bold="true"></asp:Label>
                                    <asp:TextBox ID="TextBox2" runat="server" Width="139px"></asp:TextBox>
                                </div>

                                <div class="btn-wrapper">
                                    <asp:Button ID="Button2" runat="server" Text="Download" OnClick="Button2_Click" CssClass="btn-download" Width="113px" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
    </form>
</body>
</html>
