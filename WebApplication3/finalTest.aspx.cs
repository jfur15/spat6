using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class finalTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox n = new TextBox();
            n.CssClass = "form-control style=height: 100%";
            n.TextMode = TextBoxMode.MultiLine;
            n.ReadOnly = true;
            n.Rows = 32;
            n.ID = "finalTextBox";
            
            n.Text = "Trump turned the power of the White House against the news media on Friday, escalating his attacks on journalists as “the enemy of the people” and berating members of his own F.B.I. as “leakers” who he said were putting the nation at risk. What the White House hasn’t considered is that the media can retaliate by not covering Trump’s rallies and publicity stunts. President Trump has escalated his war with the media, and the American people must demand that the free press is allowed to report the truth about what their government is doing without punishment or reprisal from the President. Sean Spicer holds off camera briefing, Trump bans reporters from briefing, Trump war with media, White House bans reporters from briefing The White House blocked a number of news organizations from attending an informal briefing Friday, a rare and surprising move that came amid President Trump’s escalating war against the media. The selected group included One America News Network, a small, conservative cable network that was founded in 2013 and has given favorable coverage to Trump. Among those excluded was CNN, which on Thursday broke the story of Priebus’s contacts with the FBI, and the New York Times, which first reported last week on alleged contacts between Trump’s campaign advisers and Russian officials. BuzzFeed, another excluded outlet, was the sole publisher of a 35-page dossier containing unproven allegations about Trump, including supposed compromising personal information. President Trump's war with the press intensified Friday when several journalists perceived as critical of the administration charged they were barred from a press briefing with White House spokesman Sean Spicer and lodged a complaint. While Trump’s presidential campaign was known for banning media outlets from rallies and campaign events, this is one of the first times the media has been explicitly barred from a White House press event during Trump’s presidency. “Many of these groups are part of large media corporations that have their own agenda,” Trump said at CPAC. “And it's not your agenda and it's not the country's agenda, it's their own agenda. They have a professional obligation as members of the press to report honestly, but as you saw throughout the entire campaign and even now, the fake news doesn't tell the truth.” The Guardian, New York Times, CNN and more were barred from ‘gaggle’ hours after Trump once again called much of the media an ‘enemy of American people’ The Guardian, New York Times, CNN and more were barred from ‘gaggle’ hours after Trump once again called much of the media an ‘enemy of American people’ The decision to limit access to Spicer, hours after Trump once again declared that much of the media was “the enemy of the American people” while speaking at the annual Conservative Political Action Conference, marked a dramatic shift. Earlier on Friday, Trump continued his assault on the press in a speech before the nation’s largest gathering of conservative activists. “As you saw throughout the entire campaign, and even now, the fake news doesn’t tell the truth,” Trump said at CPAC. In a speech to the Conservative Political Action Conference, Mr. Trump criticized as “fake news” organizations that publish anonymously sourced reports that reflect poorly on him. And in a series of Twitter posts, he assailed the F.B.I. as a dangerously porous agency, condemning unauthorized revelations of classified information from within its ranks and calling for an immediate hunt for leakers. Hours after the speech, as if to demonstrate Mr. Trump’s determination to punish reporters whose coverage he dislikes, Sean Spicer, the White House press secretary, barred journalists from The New York Times and several other news organizations from attending his daily briefing, a highly unusual breach of relations between the White House and its press corps. Mr. Trump’s barrage against the news media continued well into Friday night. “FAKE NEWS media knowingly doesn’t tell the truth,” he wrote on Twitter shortly after 10 p.m., singling out The Times and CNN. “A great danger to our country.” The moves underscored the degree to which Mr. Trump and members of his inner circle are eager to use the prerogatives of the presidency to undercut those who scrutinize him, dismissing negative stories as lies and confining press access at the White House to a few chosen news organizations considered friendly. The Trump White House has also vowed new efforts to punish leakers. Mr. Trump’s attacks on the press came as the White House pushed back on a report by CNN on Thursday night that a White House official had asked the F.B.I. to rebut a New York Times article last week detailing contacts between Mr. Trump’s associates and Russian intelligence officials. The report asserted that a senior White House official had called top leaders at the F.B.I. to request that they contact reporters to dispute the Times’s account. “The fake news doesn’t tell the truth,” Mr. Trump said to the delight of the conservatives packed into the main ballroom at the Gaylord National Resort and Convention Center just south of Washington. “It doesn’t represent the people, it doesn’t and never will represent the people, and we’re going to do something about it.” Still, the Committee to Protect Journalists, which typically advocates press rights in countries with despotic regimes, issued an alarmed statement on Friday about Mr. Trump’s escalating language. Mr. Trump, in his attack on the news media at the conservative gathering, complained at length about the use of anonymous sources in news stories, charging that some reporters were fabricating unnamed sources to level unfair charges against him. “They shouldn’t be allowed to use sources unless they use somebody’s name,” Mr. Trump said. “Let their name be put out there.” In the West Wing less than three hours later, the consequences were becoming clear. Mr. Spicer told a handpicked group of reporters in a briefing in his spacious office that the White House would relentlessly counter coverage it considered inaccurate. Reporters from The Times, BuzzFeed News, CNN, The Los Angeles Times, Politico, the BBC and The Huffington Post were among those shut out of the briefing. Aides to Mr. Spicer admitted only reporters from a group of news organizations that, the White House said, had been previously confirmed. Later, in the briefing from which the Times was excluded, Mr. Spicer said that it was top F.B.I. officials — first Andrew G. McCabe, the deputy director, and later James B. Comey, the director — who approached Reince Priebus, the White House chief of staff, the day after the article appeared to say that it was false. “They came to us and said the story is not true. We said, ‘Great, could you tell people that?’” Mr. Spicer said, describing the discussions between Mr. Priebus and F.B.I. officials. Last week the White House declined to comment on the Times article and referred reporters back to Mr. Spicer’s previous assertions that Mr. Trump’s campaign had no contact with the Russian government. Mr. Spicer’s small-group Friday session, known as a gaggle, was scheduled as an off-camera event, less formal than his usual briefings that are carried live on cable news. But past administrations have not selected outlets that can attend such sessions. “Nothing like this has ever happened at the White House in our long history of covering multiple administrations of different parties,” Dean Baquet, the executive editor of The Times, said in a statement. “We strongly protest the exclusion of The New York Times and the other news organizations. Free media access to a transparent government is obviously of crucial national interest.” “Nothing like this has ever happened at the White House in our long history of covering multiple administrations of different parties,” Dean Baquet, the Times' executive editor, said in a statement. “We strongly protest the exclusion of The New York Times and the other news organizations. Free media access to a transparent government is ";

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
        }
        protected void btnEditInputs(object sender, EventArgs e)
        {
            var x = ViewState["Variable"];

        }
    }

}