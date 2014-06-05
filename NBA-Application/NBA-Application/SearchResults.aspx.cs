using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBA_Application
{
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
                        Session["ResultList"] = Resultslist;
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