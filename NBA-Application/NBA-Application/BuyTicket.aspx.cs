using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EO.Web;

namespace NBA_Application
{
    /// <summary>
    /// On this page it is possible to buy tickets for a selected date. You are redirected here from the Homepage.
    /// </summary>
    public partial class BuyTicket : System.Web.UI.Page
    {
        DatabaseConnection db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new DatabaseConnection();
        }

        /// <summary>
        /// Confirm your purchase of a tickets of a selected match
        /// when name and banknumber have been filled in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBuy_Click(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.ListBox MatchChoice = (System.Web.UI.WebControls.ListBox)TicketMatchOnDate.FindControl("lbMatches");
            DatePicker dpDate = (DatePicker)TicketMatchOnDate.FindControl("dpMatchPick");
            List<Match> Matches = db.GetMatches(dpDate.SelectedDate);
            string Name = tbName.Text;
            string BankNumber = tbBank.Text;
            foreach (Match m in Matches)
            {
                if (m.ToString() == MatchChoice.SelectedItem.ToString())
                {
                    if (db.BuyTicket(m.MatchID, Name, BankNumber))
                    {
                        break;
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Tickets sold out for this match');", true); 
                    }
                }

            }
        }
    }
}