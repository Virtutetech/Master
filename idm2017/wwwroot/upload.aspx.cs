using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lnkbtn.Visible = false; 
        }
    }

    protected void lnkbtn_Click(object sender, EventArgs e)
    {
        try
        {
            string filePath = lblresult.Text;
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }
        catch (Exception ex)
        {

            Response.Write(ex.Message.ToString());
        }
  
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtFolder.Text.Trim()))
            {
                lblresult.Text = "Enter Folder name";
                return;
            }
            if (fp1.HasFile == false)
            {
                lblresult.Text = "Please select a file to upload";
                return;
            }
            if (System.IO.Directory.Exists(Server.MapPath(txtFolder.Text)) == false)
            {
                System.IO.Directory.CreateDirectory(Server.MapPath(txtFolder.Text.Trim()));
            }
            if (System.IO.File.Exists(Server.MapPath(txtFolder.Text) + "/" + fp1.FileName) == false)
            {
                System.IO.File.Delete(Server.MapPath(txtFolder.Text.Trim() + "/" + fp1.FileName));
            }
            byte[] myfile = ReadFully(fp1.PostedFile.InputStream);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(myfile);
            //FileStream fs = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath(actFolder, FileMode.Create);
            System.IO.FileStream fs = new FileStream(Server.MapPath(txtFolder.Text.Trim()) + "/" + fp1.PostedFile.FileName, FileMode.Create);
            ms.WriteTo(fs);
            ms.Close();
            fs.Close();
            fs.Dispose();


            try
            {
                //fp1.SaveAs(Server.MapPath(txtFolder.Text.Trim() + "/" + fp1.FileName));
                lblresult.Text = HttpContext.Current.Request.Url.Host + "/ws_app/" + txtFolder.Text.Trim() + "/" + fp1.FileName.Replace(" ", "_");
                lnkbtn.Visible = true;
            }
            catch (Exception ex)
            {

                lblresult.Text = ex.Message.ToString();
            }
        }
        catch (Exception ex)
        {

            Response.Write(ex.Message.ToString());
        }
        
        
    }
    public static byte[] ReadFully(Stream input)
    {
        byte[] buffer = new byte[input.Length];
        //byte[] buffer = new byte[16 * 1024];
        using (MemoryStream ms = new MemoryStream())
        {
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }
            return ms.ToArray();
        }
    }
}