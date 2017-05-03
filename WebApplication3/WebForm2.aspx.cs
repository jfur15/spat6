using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication3
{



    public partial class WebForm2 : System.Web.UI.Page
    {
        override protected void OnInit(EventArgs e)
        {
            // Create dynamic controls here.
            // Use "using System.Web.UI.WebControls;"
            for (int i = 0; i < 10; i++)
            {
                textboxdiv.Controls.Add(new TextBox());
            }
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }

            
        }
        protected void clearbutton_click(object sender, EventArgs e)
        {
            foreach (TextBox t in textboxdiv.Controls.OfType<TextBox>())
            {
                t.Text = "";
            }
        }
        protected void submitbutton_click(object sender, EventArgs e)
        {
            List<string> urls = new List<string>();
            foreach (TextBox t in textboxdiv.Controls.OfType<TextBox>())
            {
                urls.Add(t.Text);
            }
        }
        protected void temp_createnew(object sender, EventArgs e)
        {
            TextBox t = new TextBox();
            t.CssClass = "form-control";
            textboxdiv.Controls.Add(t);
        }

    }
}