using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Drawing;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Security;
using System.Xml;
using System.Web.UI.WebControls;
using edu.stanford.nlp.process;
using edu.stanford.nlp.trees;
using edu.stanford.nlp.ie.crf;
using edu.stanford.nlp.parser.lexparser;
using edu.stanford.nlp.tagger.maxent;
using edu.stanford.nlp.coref;
using edu.stanford.nlp.pipeline;
using edu.stanford.nlp.simple;
using edu.stanford.nlp.time;
using HtmlAgilityPack;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Put /edu in C:/Program Files (x86)/IIS Express
            NLPObjs.cfier = CRFClassifier.getClassifierNoExceptions("edu\\stanford\\nlp\\models\\ner\\english.muc.7class.nodistsim.crf.ser.gz");

            NLPObjs.tizer = PTBTokenizer.factory(new CoreLabelTokenFactory(), "asciiQuotes");

            
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {

            //this is good

            //TODO: Check for empty text boxes
            articleInit(divTextbox.Controls.OfType<TextBox>().Select(o =>o.Text).ToList());
        }

        protected void buttonPreload_Click(object sender, EventArgs e)
        {
            List<string> urls = new List<string>(new string[] { "https://www.nytimes.com/2017/02/24/us/politics/white-house-sean-spicer-briefing.html", "http://thedailybanter.com/2017/02/trump-administration-bans-cnn/",  " http://www.politicususa.com/2017/02/24/trump-hide-truth-banning-media-write-scandal-press-briefing.html", " http://www.politico.com/story/2017/02/reporters-blocked-white-house-gaggle-235360",  " https://www.washingtonpost.com/lifestyle/style/cnn-new-york-times-other-media-barred-from-white-house-briefing/2017/02/24/4c22f542-fad5-11e6-be05-1a3817ac21a5_story.html","http://www.foxnews.com/politics/2017/02/24/media-outlets-accuse-white-house-blocking-certain-press-from-covering-event.html"," http://www.vox.com/policy-and-politics/2017/2/24/14729078/white-house-banned-media-outlets-press-briefing", "  https://www.conservativereview.com/commentary/2017/02/media-freak-out-when-white-house-blocks-cnn-and-others-from-press-gaggle", "  https://www.theguardian.com/us-news/2017/feb/24/media-blocked-white-house-briefing-sean-spicer", " http://www.huffingtonpost.com/entry/white-house-bars-news-organizations_us_58b08a76e4b0a8a9b78213ae"});

            articleInit(urls);

        }

        //This produces
        protected List<Article> articleInit(List<string> urls)
        {
            List<Article> allArticles = new List<Article>();
            //TODO: clean the URL's, throw out improper ones

            foreach (String s in urls)
            {
                //Change color of textbox?

                // Is anything in the textbox?
                if (!string.IsNullOrEmpty(s))
                {
                    // Is it actually a URL?
                    if (Uri.IsWellFormedUriString(s, UriKind.Absolute))
                    {
                        // Create new article object and add it to list of all articles
                        Article newArticle = new Article(s);
                        allArticles.Add(newArticle);
                    }
                    else
                    {
                        //Change color of TextBox?

                        //Alert user of invalid input
                        String x = "Invalid input: " + s + " is not a valid URL.";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + x  + "');", true);
                    }
                }
            }


            //then Pass them to URLGet
            for (int i = 0; i < allArticles.Count; i++) { URLGet(allArticles[i]); }

            //then instantiate each Article object and return as a list to be output to GUI and/or condensed into finalarticle

            return allArticles;

            //Output compared articles to main window

            /*
            foreach (Article A in allArticles)
                {
                //Comparing and appending articles

                } */

            }


        // Retrieve text from webpage in paragraph form based on URL and assign to passed in Article object
        private void URLGet(Article anArticle)
        {
            // Create HTMLWeb object, enable cookies, and use Article object's URL string to load online webpage
            // into HTMLDocument object
            HtmlWeb webPage = new HtmlWeb();
            webPage.UseCookies = true;
            HtmlAgilityPack.HtmlDocument getHtmlWeb = webPage.Load(anArticle.URL);

            // For each node in loaded webpage that is in paragraph tags (<p> </p>) add contained text to Article 
            // object's list of paragraphs
            //anArticle.title = System.Net.WebUtility.HtmlDecode(getHtmlWeb.DocumentNode.SelectSingleNode("//title").InnerText);
            HtmlNodeCollection n = getHtmlWeb.DocumentNode.SelectNodes("//p | div[contains (@class, body)]");
            if (n.Count > 0)
            {
                foreach (HtmlNode node in n)
                {
                    anArticle.AddParagraph(System.Net.WebUtility.HtmlDecode(node.InnerText));
                }
            }
        }
    }
}