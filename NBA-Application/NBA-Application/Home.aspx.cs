using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBA_Application
{
    /// <summary>
    /// Homepage for this web-application here you can view today's matches or matches on another date.
    /// You can also search for a specific player or other object or search for all objects.
    /// Administrators can sign in to get to the administration-form.
    /// </summary>
    public partial class Webform1 : System.Web.UI.Page
    {
        DatabaseConnection db;
        public List<ISearchable> SearchResults
        {
            get;
            set;
        }
        string AdminUN;
        string AdminPW;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            db = new DatabaseConnection();
            SearchResults = new List<ISearchable>();
            btnSearch.PostBackUrl = "~/SearchResults.aspx";
            AdminUN = "Meny";
            AdminPW = "Metekia";
             
            if (!IsPostBack)
            {
                GetMatches(DateTime.Now);
                dpDateMatches.SelectedDate = DateTime.Now;
                lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            }
            else
            {
                ClientScript.RegisterHiddenField("isPostBack", "1");
                GetMatches(dpDateMatches.SelectedDate);
                
            }
        }

        /// <summary>
        /// This method is used for getting matches on a specific date. On load it automatically gets today's matches
        /// </summary>
        /// <param name="date">Date to search for in the database</param>
        private void GetMatches(DateTime date)
        {
            List<Match> Matches = db.GetMatches(date);
            if (Matches.Count > 0)
            {
                lblNoMatches.Visible = false;
                foreach (Match m in Matches)
                {
                    WebUserControl1 NotPlayed = LoadControl("~/MatchNotPlayed.ascx") as WebUserControl1;
                    PlaceHolder1.Controls.Add(NotPlayed);
                    Label lblTime = (Label)NotPlayed.FindControl("lblTime");
                    Label lblHidden = (Label)NotPlayed.FindControl("lblHidden");
                    Label lblTeamHome = (Label)NotPlayed.FindControl("lblTeam1");
                    Label lblTeamAway = (Label)NotPlayed.FindControl("lblTeam2");
                    Label lblStadium = (Label)NotPlayed.FindControl("lblStadium");
                    Label lblHomescore = (Label)NotPlayed.FindControl("lblHomeScore");
                    Label lblAwayscore = (Label)NotPlayed.FindControl("lblAwayScore");
                    Image imgTv = (Image)NotPlayed.FindControl("imgTv");
                    Image imgHome = (Image)NotPlayed.FindControl("imgHome");
                    Button btnBuy = (Button)NotPlayed.FindControl("btnBuy");
                    Panel pnlBuyTicket = (Panel)NotPlayed.FindControl("pnlBuyTicket");
                    lblTime.CssClass = "lblTime";
                    btnBuy.PostBackUrl = "~/BuyTicket.aspx";
                    lblTime.Text = m.DateTime.ToString("HH:mm");
                    lblTeamHome.CssClass = "lblTeamHome";
                    lblTeamHome.Text = m.HomeTeam;
                    lblTeamAway.Text = m.AwayTeam;
                    lblHomescore.CssClass = "lblHomeScore";
                    lblAwayscore.CssClass = "lblAwayScore";
                    lblTeamAway.CssClass = "lblTeamAway";
                    lblStadium.CssClass = "lblStadium";
                    lblStadium.Text = m.StadiumName;
                    btnBuy.CssClass = "btnBuy";
                    imgTv.CssClass = "imgTv";
                    imgHome.CssClass = "imgHome";
                    if (m.Status == "PLAYED")
                    {
                        lblHomescore.Text = m.HomeScore.ToString();
                        lblAwayscore.Text = m.AwayScore.ToString();
                        if (lblTeamHome.Text.Length > 5)
                        {
                            lblHomescore.CssClass = "lblHomeScoreLong";
                        }
                        if(lblTeamHome.Text.Length > 7)
                        {
                            lblHomescore.CssClass = "lblHomeScoreExtraLong";
                        }
                        if(lblTeamAway.Text.Length > 5)
                        {
                            lblAwayscore.CssClass = "lblAwayScoreLong";
                        }
                        if (lblTeamAway.Text.Length > 7)
                        {
                            lblAwayscore.CssClass = "lblAwayScoreExtraLong";
                        }
                        
                        if (m.HomeScore > m.AwayScore)
                        {
                            lblHomescore.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            lblAwayscore.ForeColor = System.Drawing.Color.Red;  
                        }
                    }
                    
                }
                
            }
            else
            {
                lblNoMatches.Visible = true;
            }

        }
        /// <summary>
        /// Confirm button for searching, in a textbox a searchterm is written and there can be filtered on different object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchterm = tbSearch.Text;
            
            if(rbEmployee.Checked || rbAll.Checked)
            {
                List<ISearchable> Employees = db.SearchMultipleObjects(searchterm, "Team_Employee", "EmpName");
                if(Employees != null)
                SearchResults.AddRange(Employees);
            }
            if (rbPlayer.Checked || rbAll.Checked)
            {
                List<ISearchable> Players = db.SearchMultipleObjects(searchterm, "Player", "Name");
                if(Players != null)
                SearchResults.AddRange(Players);
            }
            if (rbTeam.Checked || rbAll.Checked)
            {
                 List<ISearchable> Teams = db.SearchMultipleObjects(searchterm, "Team", "TeamName");
                 if(Teams != null)
                 SearchResults.AddRange(Teams);
            }
            if (rbStadium.Checked || rbAll.Checked)
            {
                List<ISearchable> Stadiums = db.SearchMultipleObjects(searchterm, "Stadium", "Stadium_Name");
                if(Stadiums != null)
                SearchResults.AddRange(Stadiums);
            }
            if (rbEvent.Checked || rbAll.Checked)
            {
               List<ISearchable> Events = db.SearchMultipleObjects(searchterm, "Event", "EventName");
               if(Events != null)
               SearchResults.AddRange(Events);
            }

        }

        /// <summary>
        /// Confirm for login of an administrator. This is only simulated for this version and will be expanded later on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = Page.Request.Form["tbPassword"].ToString();
            if (username == AdminUN && password == AdminPW)
            {
                Response.Redirect("~/AdminstratorForm.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Username or password incorrect');", true);
            }
        }

        protected void dpDateMatches_SelectionChanged(object sender, EventArgs e)
        {
            lblDate.Text = dpDateMatches.SelectedDate.ToString("dd-MM-yyyy");
            GetMatches(dpDateMatches.SelectedDate);
        }

    }
}