using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBA_Application
{
    /// <summary>
    /// Usercontrol that gets added to the Home page for each match on a selected date
    /// </summary>
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        DatabaseConnection db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new DatabaseConnection();
            
        }
    }
}