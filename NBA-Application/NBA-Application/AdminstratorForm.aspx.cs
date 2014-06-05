using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EO.Web;

namespace NBA_Application
{
    public partial class AdminstratorForm : System.Web.UI.Page
    {
        DatabaseConnection db;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            db = new DatabaseConnection();
            if (!IsPostBack)
            {
                
                FillDropDown();
                pnlAddTicketConfirm.Visible = false;
                pnlAddSeasonTicket.Visible = false;
            }
            else
            {
                ClientScript.RegisterHiddenField("isPostBack", "1");
                pnlAddTicketConfirm.Visible = false;
                pnlAddSeasonTicket.Visible = false;
            } 
            
        }

        private void FillDropDown()
        {
            List<ISearchable> Employees = db.SearchMultipleObjects("", "Team_Employee", "EmpName");
            List<ISearchable> Teams = db.SearchMultipleObjects("", "Team", "TeamName");
            List<ISearchable> Players = db.SearchMultipleObjects("", "Player", "Name");
            List<ISearchable> Stadiums = db.SearchMultipleObjects("", "Stadium", "Stadium_Name");
            ddlHomeTeam.Items.Clear();
            ddlAwayTeam.Items.Clear();
            ddlDivision.Items.Clear();
            ddlConference.Items.Clear();
            ddlStadium.Items.Clear();
            ddlTeam.Items.Clear();
            ddlTopscorer.Items.Clear();
            foreach(Team_Employee t in Employees)
            {
                ddlAssistent.Items.Add(t.EmployeeName);
            }
            foreach (Team team in Teams)
            {
                ddlAwayTeam.Items.Add(team.Team_Name);
                ddlHomeTeam.Items.Add(team.Team_Name);
                ddlEmpTeam.Items.Add(team.Team_Name);
                ddlSeasonTeam.Items.Add(team.Team_Name);
                ddlTeam.Items.Add(team.Team_Name);
            }
            foreach (Player p in Players)
            {
                ddlTopscorer.Items.Add(p.Name);
            }
            foreach (Stadium s in Stadiums)
            {
                ddlStadium.Items.Add(s.StadiumName);
                ddlStadiumMatch.Items.Add(s.StadiumName);
            }
            for (int i = 50; i <= 150; i++)
            {
                ddlWeight.Items.Add(i.ToString());
            }
            for (int i = 150; i <= 230; i++)
            {
                ddlLength.Items.Add(i.ToString());
            }
            for (int i = 1; i <= 31; i++)
            {
                if (i < 10)
                    ddlDay.Items.Add("0" + i.ToString());
                else
                    ddlDay.Items.Add(i.ToString());
            }
            for (int i = 1; i <= 12; i++)
            {
                if(i < 10)
                    ddlMonth.Items.Add("0" + i.ToString());
                else
                    ddlMonth.Items.Add(i.ToString());
            }
            for (int i = 1900; i <= 2000; i++)
            {
                ddlYear.Items.Add(i.ToString());
            }
            for (int i = 1900; i <= 2014; i++)
            {
                ddlPro_Year.Items.Add(i.ToString());
            }
            ddlConference.Items.Clear();
            ddlConference.Items.Add("Western");
            ddlConference.Items.Add("Eastern");
            ddlDivision.Items.Add("Pacific");
            ddlDivision.Items.Add("Northwest");
            ddlDivision.Items.Add("Southwest");
            ddlDivision.Items.Add("Atlantic");
            ddlDivision.Items.Add("Central");
            ddlDivision.Items.Add("Southeast");
            foreach (var item in typeof(Player.Position).GetFields())
            {

                if (item.FieldType == typeof(Player.Position))
                    ddlPosition.Items.Add(item.Name);

            }

        }

        protected void btnAddPConfirm_Click(object sender, EventArgs e)
        {
            string PlayerName = tbPlayerName.Text;
            int Length = Convert.ToInt32(ddlLength.SelectedValue);
            int Weight = Convert.ToInt32(ddlWeight.SelectedValue);
            string School_Country = tbSchool_Country.Text;
            if (PlayerName != string.Empty && School_Country != string.Empty)
            {
                string Birthdate = ddlDay.SelectedValue + "-" + ddlMonth.SelectedValue + "-" + ddlYear.SelectedValue;
                int Pro_Year = Convert.ToInt32(ddlPro_Year.SelectedValue);
                Player.Position Position;
                Enum.TryParse(ddlPosition.SelectedValue, out Position);
                string Team = ddlTeam.SelectedValue;
                Player NewPlayer = new Player(PlayerName, Length, Weight, School_Country, Birthdate, Pro_Year, Position, Team);
                if (db.AddPlayer(NewPlayer))
                {
                    lblError.Visible = false;
                    FillDropDown();
                }
            }
            else
            {
                lblError.Visible = true;
            }
        }

        protected void btnAddTeamConfirm_Click(object sender, EventArgs e)
        {
            string TeamName = tbTeamName.Text;
            string City = tbCity.Text;
            int Founded = 0;
            if (TeamName != string.Empty && City != string.Empty && int.TryParse(tbFounded.Text, out Founded))
            {
                string Conference = ddlConference.SelectedValue;
                string Division = ddlDivision.SelectedValue;
                string Stadium = ddlStadium.SelectedValue;
                Team NewTeam = new Team(TeamName, City, Founded, Conference, Division, Stadium);
                if (db.AddTeam(NewTeam))
                {
                    lblError.Visible = false;
                    FillDropDown();
                }
            }
            else
            {
                lblError.Visible = true;
            }

        }

        protected void btnAddMConfirm_Click(object sender, EventArgs e)
        {
            DateTime MatchDateTime = dpDateMatch.SelectedDate;
            string HomeTeam = ddlHomeTeam.SelectedValue;
            string AwayTeam = ddlAwayTeam.SelectedValue;
            if (HomeTeam != AwayTeam)
            {
                string Stadium = ddlStadiumMatch.SelectedValue;
                Match NewMatch = new Match(MatchDateTime, HomeTeam, AwayTeam, Stadium);
                TextBox tbAmount = (TextBox)ucTicketsAddDetails.FindControl("tbTickets");
                TextBox tbPrice = (TextBox)ucTicketsAddDetails.FindControl("tbPriceTicket");
                int AmountOfTickets = Convert.ToInt32(tbAmount.Text);
                int PriceTicket = Convert.ToInt32(tbPrice.Text);
                int ID = db.GetInsertID("MatchID", "Match");
                bool Succes = false;
                NewMatch.MatchID = ID;
                if (db.AddMatch(NewMatch))
                {
                    for (int i = 1; i <= AmountOfTickets; i++)
                    {
                        Succes = db.AddSingle(PriceTicket, NewMatch);
                    }
                    lblError.Visible = false;
                }
            }
            else
            {
                lblError.Visible = true;
            }
        }

        protected void btnAddDetailsConfirm_Click(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.ListBox MatchChoice = (System.Web.UI.WebControls.ListBox)ucMatchesOnDateDetails.FindControl("lbMatches");
            DatePicker dpDate = (DatePicker)ucMatchesOnDateDetails.FindControl("dpMatchPick");
            List<Match> Matches = db.GetMatches(dpDate.SelectedDate);
            int HomeScore = Convert.ToInt32(tbHomeScore.Text);
            int AwayScore = Convert.ToInt32(tbAwayScore.Text);
            if (int.TryParse(tbHomeScore.Text, out HomeScore) && int.TryParse(tbAwayScore.Text, out AwayScore) && HomeScore != AwayScore)
            {
                string Topscorer = ddlTopscorer.SelectedValue;
                foreach (Match m in Matches)
                {
                    if (m.ToString() == MatchChoice.SelectedItem.ToString())
                    {
                        Match ChosenMatch = m;
                        if (ChosenMatch.AddDetails(HomeScore, AwayScore, Topscorer))
                        {
                            lblError.Visible = false;
                            break;
                        }
                    }

                }
            }
            else
            {
                lblError.Visible = true;
            }
            

        }
        
        protected void btnAddEConfirm_Click(object sender, EventArgs e)
        {
            string EmployeeName = tbEmployeeName.Text;
            string College = tbCollege.Text;
            string Function = tbFunction.Text;
            if (EmployeeName != string.Empty && Function != string.Empty)
            {
                string Assistent = string.Empty;
                string TeamName = ddlEmpTeam.SelectedValue;
                if (ddlAssistent.SelectedValue != "No Assistent")
                {
                    Assistent = ddlAssistent.SelectedValue;
                }
                Team_Employee newEmployee = new Team_Employee(EmployeeName, College, Function, Assistent, TeamName);
                if (db.AddTeam_Employee(newEmployee))
                {
                    lblError.Visible = false;
                    FillDropDown();
                }
            }
            else
            {
                lblError.Visible = true;
            }
        }

        protected void btnAddSConfirm_Click(object sender, EventArgs e)
        {
            string StadiumName = tbStadiumName.Text;
            string Location = tbLocation.Text;
            int MaxPeople = 0;
            if (int.TryParse(tbMaxPeople.Text, out MaxPeople) && StadiumName != string.Empty && Location != string.Empty)
            {
                Stadium NewStadium = new Stadium(StadiumName, Location, MaxPeople);
                if (db.AddStadium(NewStadium))
                {
                    lblError.Visible = false;
                    FillDropDown();
                }
            }
            else
            {
                lblError.Visible = true;
            }
        }

        protected void btnAddSingle_Click(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.ListBox MatchChoice = (System.Web.UI.WebControls.ListBox)ucMatchesOnDateSingle.FindControl("lbMatches");
            DatePicker dpDate = (DatePicker)ucMatchesOnDateDetails.FindControl("dpMatchPick");
            if (dpDate.SelectedDateString == "")
            {
                dpDate = (DatePicker)ucMatchesOnDateSingle.FindControl("dpMatchPick");
            }
            List<Match> Matches = db.GetMatches(dpDate.SelectedDate);
            TextBox tbAmount = (TextBox)ucTicketsAddSingle.FindControl("tbTickets");
            TextBox tbPrice = (TextBox)ucTicketsAddSingle.FindControl("tbPriceTicket");
            int Price = 0;
            int Amount = 0;
            if (int.TryParse(tbAmount.Text, out Amount) && int.TryParse(tbPrice.Text, out Price))
            {
                if (Amount <= 10)
                {
                    foreach (Match m in Matches)
                    {
                        if (m.ToString() == MatchChoice.SelectedItem.ToString())
                        {
                            Match ChosenMatch = m;
                            for (int i = 1; i <= Amount; i++)
                            {
                                db.AddSingle(Price, ChosenMatch);
                            }
                            lblError.Visible = false;
                        }

                    }
                }
                else
                {
                    lblError.Visible = true;
                }
            }
        }

        protected void btnAddSeasonTConfirm_Click(object sender, EventArgs e)
        {
            string ChosenTeam = ddlSeasonTeam.SelectedValue;
            TextBox tbAmount = (TextBox)ucAddTicketsSeason.FindControl("tbTickets");
            TextBox tbPrice = (TextBox)ucAddTicketsSeason.FindControl("tbPriceTicket");
            int Price = Convert.ToInt32(tbPrice.Text);
            int Amount = Convert.ToInt32(tbAmount.Text);
            DateTime SeasonStart = dpSeasonStart.SelectedDate;
            if (Amount <= 10)
            {
                for (int i = 1; i <= Amount; i++)
                {
                    db.AddSeasonTicket(Price, SeasonStart, ChosenTeam);
                }
                lblError.Visible = false;
            }
            else
            {
                lblError.Visible = true;
            }
        }

        protected void btnAddEventConfirm_Click(object sender, EventArgs e)
        {
            string EventName = tbNameEvent.Text;
            if (EventName != string.Empty)
            {
                string BeginDate = dpBeginDateEvent.SelectedDate.ToString("dd-MM-yyyy");
                Event NewEvent = new Event(EventName, BeginDate);
                if (db.AddEvent(NewEvent))
                {
                    lblError.Visible = false;
                }
            }
            else
            {
                lblError.Visible = true;
            }
        }

        protected void btnAddTickets_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterHiddenField("Ticket", "1");
            if (pnlAddTicketConfirm.Visible == false)
            {
                pnlAddTicketConfirm.Visible = true;
                pnlAddSeasonTicket.Visible = true;
            }
            else
            {
                pnlAddTicketConfirm.Visible = false;
                pnlAddSeasonTicket.Visible = false;
            }
        }
    }
}