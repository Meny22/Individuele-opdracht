using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA_Application
{
    public class SeasonTicket : Ticket, ISearchable
    {
        public DateTime Begindate
        {
            get;
            set;
        }

        public string TeamName
        {
            get;
            set;
        }

        public SeasonTicket(string type, int price, string section, int row, int seat, DateTime begindate, string teamname) : base(type, price, section, row, seat)
	    {
            this.Begindate = begindate;
            this.TeamName = teamname;
	    }

        public int Search
        {
            get { throw new NotImplementedException(); }
        }

        string ISearchable.Search
        {
            get { throw new NotImplementedException(); }
        }
    }
}