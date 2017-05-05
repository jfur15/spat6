using System;
using System.Collections.Generic;
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
            n.Text = this.Context.Items["newkey"].ToString();
            finalDiv.Controls.Add(n);
        }
    }
}