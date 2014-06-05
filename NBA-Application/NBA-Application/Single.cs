using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA_Application
{
    public class Single : Ticket, ISearchable
    {
        public Match Match
        {
            get;
            set;
        }

        public Single(string type, int price, string section, int row, int seat, Match match) : base(type, price, section, row, seat)
	    {
		    this.Match = match;
	    }

        string ISearchable.Search
        {
            get { throw new NotImplementedException(); }
        }
    }
}