using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class finalArticle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox n = new TextBox();
            n.CssClass = "form-control style=height: 100%";
            n.TextMode = TextBoxMode.MultiLine;
            n.ReadOnly = true;
            n.Rows = 32;
            n.ID = "finalTextBox";

            if (Context.Items["newkey"] != null)
            {
                n.Text = this.Context.Items["newkey"].ToString();
            }

            finalDiv.Controls.Add(n);
        }

        protected void btnDownloadArticle(object sender, EventArgs e)
        {
            string FileName = "article.txt";
            string FilePath = Request.PhysicalApplicationPath + FileName;

            StreamWriter w;
            w = File.CreateText(FilePath);

            w.Write(finalDiv.Controls.OfType<TextBox>().First().Text);

            w.Flush();
            w.Close();

            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
            response.TransmitFile(FilePath);
            response.Flush();
            response.End();


            Context.Items["newkey"] = finalDiv.Controls.OfType<TextBox>().First().Text;



        }
        protected void btnEditInputs(object sender, EventArgs e)
        {

        }
    }


}