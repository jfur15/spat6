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
            Directory.SetCurrentDirectory("\\");

            NLPObjs.cfier = CRFClassifier.getClassifierNoExceptions("\\home\\site\\wwwroot\\english.muc.7class.nodistsim.crf.ser.gz");

            NLPObjs.tizer = PTBTokenizer.factory(new CoreLabelTokenFactory(), "asciiQuotes");

            if (this.Context.Items["URLsback"] != null)
            {
                List<String> theUrls = (List<String>)this.Context.Items["URLsback"];
                List<TextBox> theBoxes = divTextbox.Controls.OfType<TextBox>().ToList<TextBox>();

                for (int i = 0; i < theUrls.Count; i++)
                {
                    if (i <= theBoxes.Count)
                    {
                        theBoxes[i].Text = theUrls[i];
                    }
                }
            }
        }


        private static bool EmptyString(String s)
        {
            return s.Equals("");
        }

        protected void submitbutton_Click(object sender, EventArgs e)
        {

            //this is good

            //TODO: Check for empty text boxes
            List<string> tlist = divTextbox.Controls.OfType<TextBox>().Select(o => o.Text).ToList();

            tlist.RemoveAll(EmptyString);


            articleInit(tlist);
        }

        protected void clearbutton_click(object sender, EventArgs e)
        {
            foreach (TextBox t in divTextbox.Controls.OfType<TextBox>())
            {
                t.Text = "";
            }
        }

        protected void buttonPreload_Click(object sender, EventArgs e)
        {
            this.Context.Items["URLsback"] = new List<string>(new string[] { "https://www.nytimes.com/2017/02/24/us/politics/white-house-sean-spicer-briefing.html",  " http://www.politicususa.com/2017/02/24/trump-hide-truth-banning-media-write-scandal-press-briefing.html", " http://www.politico.com/story/2017/02/reporters-blocked-white-house-gaggle-235360",  " https://www.washingtonpost.com/lifestyle/style/cnn-new-york-times-other-media-barred-from-white-house-briefing/2017/02/24/4c22f542-fad5-11e6-be05-1a3817ac21a5_story.html","http://www.foxnews.com/politics/2017/02/24/media-outlets-accuse-white-house-blocking-certain-press-from-covering-event.html"," http://www.vox.com/policy-and-politics/2017/2/24/14729078/white-house-banned-media-outlets-press-briefing", "  https://www.conservativereview.com/commentary/2017/02/media-freak-out-when-white-house-blocks-cnn-and-others-from-press-gaggle", "  https://www.theguardian.com/us-news/2017/feb/24/media-blocked-white-house-briefing-sean-spicer", " http://www.huffingtonpost.com/entry/white-house-bars-news-organizations_us_58b08a76e4b0a8a9b78213ae"});
            Server.Transfer("urlListPage.aspx");

        }

        // Clean the URL's, throw out errors for improper ones, create articles for remainder
        /// Then instantiate each Article object and return as a list to be output to GUI and/or condensed into finalarticle:
        /// Retrieves text from webpage in paragraph form based on URL and assign to passed in Article object
        protected void articleInit(List<string> urls)
        {
            List<Article> allArticles = new List<Article>();
            List<ComparisonPool> pooledParagraphs = new List<ComparisonPool>();

            // Clean the URL's, throw out errors for improper ones
            foreach (String s in urls)
            {
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
                        //Alert user of invalid input
                        String x = "Invalid input: " + s + " is not a valid URL.";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + x  + "');", true);
                    }
                }
            }

            // Then Pass them to URLGet
            for (int i = 0; i < allArticles.Count; i++) { URLGet(allArticles[i]); }

            //then instantiate each Article object and return as a list to be output to GUI and/or condensed into finalarticle:
            //// Retrieves text from webpage in paragraph form based on URL and assign to passed in Article object
            tempSentenceProcess(allArticles);

            // instantiate classifiers, pool paragraphs with classifers present
            foreach (Article A in allArticles)
            {
                foreach (Paragraph p in A.paragraphs)
                {

                    List<string>[] cls = { p.listDates, p.listPersons, p.listLocations, p.listOrganizations };
                    string[] classiferNames = { "DATE", "PERSON", "LOCATION", "ORGANIZATION" };

                bool paragraphAdded = false;
                for (int i = 0; i < cls.Length; i++)
                {

                    foreach (string entity in cls[i])
                    {
                        if (classiferNames[i] == "PERSON" || classiferNames[i] == "LOCATION" || classiferNames[i] == "ORGANIZATION")
                        {
                            bool existingClassifier = false;
                            foreach (ComparisonPool C in pooledParagraphs)
                            {
                                if (C.Classifier == entity)
                                {
                                    if (!paragraphAdded)
                                    {
                                        C.addParagraph(p);
                                        paragraphAdded = true;
                                    }
                                    existingClassifier = true;
                                    break;
                                }
                            }
                            if (existingClassifier == false && !paragraphAdded)
                            {
                                ComparisonPool temp = new ComparisonPool(entity);
                                pooledParagraphs.Add(temp);
                                temp.addParagraph(p);
                                paragraphAdded = false;
                                i = cls.Length;
                                break;
                            }
                            }
                        }
                    }
                }
            }



            //HERE IS THE FINAL OUTPUT OK
            string finalArticletext = "";
            int numSameWords = 0;
            List<Paragraph> tempParagraphs = new List<Paragraph>();
            tempParagraphs = comparison(pooledParagraphs);

            //tempParagraphs is the final list of paragraphs
            // for length of tempParagraphs loop through each paragraph
            // outer loop
            for (int i = 0; i < tempParagraphs.Count; i++)
            {
                // for first paragraph, split into words and loop through each one
                string[] listWords1 = tempParagraphs[i].Text.Split(' ');

                // for length of tempParagraphs loop through each paragraph
                // inner loop
                for (int j = 0; j < tempParagraphs.Count; j++)
                {
                    // loop through all paragraphs comparing each one

                    // for second paragraph, split into words and loop through each one
                    string[] listWords2 = tempParagraphs[j].Text.Split(' ');

                    // for length of listWords1, loop through each word
                    // Outer loop
                    for (int k = 0; k < 5; k++)
                    {
                        // for length of listWords2, loop through each word
                        // loop through all words comparing each one
                        // Inner loop
                        if (numSameWords > 5) { j = tempParagraphs.Count; }

                        numSameWords = 0;

                        for (int l = 0; l < 5; l++)
                        {
                            if (listWords1[k] == listWords2[l])
                            {
                                ++numSameWords;
                                if (numSameWords > 5)
                                {
                                    k = 5;
                                    tempParagraphs[i].post = false;
                                }
                            }
                        }
                    }
                }

                if (numSameWords < 5)
                {
                    if(tempParagraphs[i].post == true)
                    {
                        if (tempParagraphs[i].Text.Length > 75) {
                            finalArticletext += tempParagraphs[i].Text + "\n\n\n";
                            tempParagraphs[i].post = false;
                        }
                    }   
                }
            }

            this.Context.Items["newkey"] = finalArticletext;
            this.Context.Items["URLFinal"] = urls; ;
            Server.Transfer("finalArticle.aspx");
            //return allArticles;
            //This function can be void becuase output is done when we switch to a different page
            //no need to retain the allArticles variable

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

        //Throws out all pargraphs with grade lower than 1
        //Supposed to hold all comparison logic
        private void tempSentenceProcess(List<Article> allArticles)
        {
            foreach (Article a in allArticles)
            {
                //This holds all sentences with a grade higher than 1
                List<Paragraph> tempParagraphs = new List<Paragraph>();

                for (int sidx = 0; sidx < a.paragraphs.Count; sidx++)
                {
                    if (a.paragraphs[sidx].Grade > 1 && !tempParagraphs.Contains(a.paragraphs[sidx]))
                    {
                        tempParagraphs.Add(a.paragraphs[sidx]);
                    }
                }

                //Rewrites the original sentence list with the reconstructed one
                a.paragraphs = tempParagraphs;
            }

        }


        //Real comparison
        private List<Paragraph> comparison(List<ComparisonPool> pooledParagraphs)
        {

            List<ComparisonPool> tempPooled = new List<ComparisonPool>();
            foreach (ComparisonPool C in pooledParagraphs)
            {
                if (C.Pool.Count > 2)
                {
                    tempPooled.Add(C);
                }
            }
            pooledParagraphs = tempPooled;

            List<Paragraph> finalParagraphs = new List<Paragraph>();
            Paragraph tempParagraph;



            foreach (ComparisonPool C in pooledParagraphs)
            {
                List<Paragraph> tempPool = new List<Paragraph>();
                foreach (Paragraph p1 in C.Pool.ToList())
                {
                    tempParagraph = p1;
                    tempPool = new List<Paragraph>();
                    foreach (Paragraph p2 in C.Pool.ToList())
                    {
                        if (p1.Text != p2.Text && !p1.Deleted && !p2.Deleted)
                        {
                            if (classifierCompare(p1.listClassifiers(), p2.listClassifiers()))
                            {
                                if (p1.Grade > p2.Grade)
                                {
                                    tempParagraph = p1;
                                    //delete p2
                                    p2.Deleted = true;
                                }
                                else if (p2.Grade > p1.Grade)
                                {
                                    tempParagraph = p2;
                                    //delete p1
                                    p1.Deleted = true;
                                }
                                else
                                {
                                    if (p1.Text.Length < p2.Text.Length)
                                    {

                                        tempParagraph = p2;
                                        //delete p1
                                        p1.Deleted = true;
                                    }
                                    else
                                    {
                                        tempParagraph = p1;
                                        //delete p2
                                        p2.Deleted = true;
                                    }
                                }
                            }
                            else if (p1.listClassifiers() != p2.listClassifiers())
                            {
                                continue;
                            }
                        }
                    }

                    finalParagraphs.Add(tempParagraph);
                    C.Pool.RemoveAll(item => tempPool.Contains(item));
                }

            }
            return finalParagraphs;
        }

        private bool classifierCompare(List<string> p1c, List<string> p2c)
        {
            List<string> cmpA;
            List<string> cmpB;


            if (p1c.Count > p2c.Count)
            {
                cmpA = p1c;
                cmpB = p2c;
            }
            else
            {
                cmpB = p1c;
                cmpA = p2c;
            }
            int sim = 0;
            foreach (string smstring in cmpB)
            {
                if (cmpA.Contains(smstring))
                {
                    sim++;
                }
            }
            if (sim > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}