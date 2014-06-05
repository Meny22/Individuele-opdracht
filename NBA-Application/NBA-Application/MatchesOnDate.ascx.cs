using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBA_Application
{
    public partial class MatchesOnDate : System.Web.UI.UserControl
    {
        DatabaseConnection db;
        List<Match> DateMatches;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new DatabaseConnection();
            DateMatches = new List<Match>();
        }

        protected void dpMatchPick_SelectionChanged(object sender, EventArgs e)
        {
                
                ScriptManager.RegisterHiddenField(Page, "MatchDate", "MatchDate");
                DateMatches = db.GetMatches(dpMatchPick.SelectedDate);
                lbMatches.Items.Clear();
                foreach (Match m in DateMatches)
                {
                    if (m.Status == "NOTPLAYED")
                    {
                        lbMatches.Items.Add(m.ToString());
                    }
                }
                if (lbMatches.Items.Count == 0)
                {
                    lbMatches.Items.Add("No matches on this date");
                }
          
        }
    }
}