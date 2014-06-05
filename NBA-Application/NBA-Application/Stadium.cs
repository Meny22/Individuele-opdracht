using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA_Application
{
    public class Stadium : ISearchable
    {
        public string StadiumName
        {
            get;
            set;
        }
        public string Location
        {
            get;
            set;
        }
        public int MaxPeople
        {
            get;
            set;
        }

	    public Stadium(string stadium_name, string location, int max_people)
	    {
            this.StadiumName = stadium_name;
            this.Location = location;
            this.MaxPeople = max_people;
	    }

        public string Search
        {
            get { return this.StadiumName; }
        }

        public override string ToString()
        {
            return " Name: " + StadiumName + " \n Location: " + Location + " \n Max People: " + MaxPeople;
        }
    }
}