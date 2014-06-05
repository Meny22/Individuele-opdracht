using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBA_Application
{
    /// <summary>
    /// This page is opened when a visitor has searched for objects on the home page
    /// Here the searchresults are shown for the searchterm of the visitor
    /// It's also possible to show more info by selecting a searchresults and clicking on the info button
    /// </summary>
    public partial class SearchResults : System.Web.UI.Page
    {
        
        List<ISearchable> Resultslist;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                    if(PreviousPage != null)
                    {
                        Resultslist = PreviousPage.SearchResults;
                        Session["ResultList"] = Resultslist; //Session that stores the Searchresults of the searchterm that the visitor filled in
                        foreach (ISearchable result in Resultslist)
                        {
                            lbResults.Items.Add(result.GetType().Name + ": " + result.Search);
                        }
                        if(Resultslist.Count == 0)
                        {
                            lbResults.Items.Add("No Results");
                        }
                    }
                    else
                    {
                        lbResults.Items.Add("No results");
                    }     
            }
            
            if (Session["ResultList"] != null)
            {
                Resultslist = (List<ISearchable>)(Session["ResultList"]);
            }
        }

        /// <summary>
        /// When this button is clicked more info is shown about the selected searchresult
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInfo_Click(object sender, EventArgs e)
        {
            string InfoChoice = lbResults.SelectedValue;
            foreach (ISearchable result in Resultslist)
            {
                if (InfoChoice == result.GetType().Name + ": " + result.Search)
                {
                    tbMoreInfo.Text = result.ToString();
                }
            }
        }
    }
}