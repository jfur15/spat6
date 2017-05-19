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
            string articleText = "";
            if(!IsPostBack)
            {
                ViewState["Article"] = this.Context.Items["newkey"].ToString();
            }
            if(ViewState["Article"] != null)
            {
                articleText = (string)ViewState["Article"];
            }


            
            TextBox n = new TextBox();
            n.CssClass = "form-control style=height: 100%";
            n.TextMode = TextBoxMode.MultiLine;
            n.ReadOnly = true;
            n.Rows = 32;
            n.ID = "finalTextBox";

            n.Text = articleText;

            finalDiv.Controls.Add(n);
        }

        protected void btnDownloadArticle(object sender, EventArgs e)
        {
            string FileName = "article.txt";
            string FilePath = Request.PhysicalApplicationPath + FileName;

            StreamWriter w;
            w = File.CreateText(FilePath);
            TextBox thebox =  (TextBox)Page.FindControl("finalTextBox");
            string theboxtext = ViewState["Article"].ToString();
            if (thebox != null)
            {
                theboxtext = thebox.Text;
            }
            w.Write(theboxtext);

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