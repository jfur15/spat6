using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // h1.InnerText = "Helloo";
        }
        protected void clearbutton_click(object sender, EventArgs e)
        {
            foreach (TextBox t in textboxdiv.Controls)
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
    }
}