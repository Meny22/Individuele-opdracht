using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA_Application
{
    public class Team : ISearchable
    {
        public string Team_Name
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
        public int Founded
        {
            get;
            set;
        }
        public int Championships
        {
            get;
            set;
        }
        public string Conference
        {
            get;
            set;
        }
        public string Division
        {
            get;
            set;
        }

        public string Stadium
        {
            get;
            set;
        }

	    public Team(string team_name, string city, int founded, string conference, string division, string stadium)
	    {
            this.Team_Name = team_name;
            this.City = city;
            this.Founded = founded;
            this.Conference = conference;
            this.Division = division;
            this.Stadium = stadium;
            this.Championships = 0;
	    }

        public string Search
        {
            get { return this.Team_Name; }
        }

        public override string ToString()
        {
            return " Name: " + Team_Name + " \n City: " + City + " \n Founded: " + Founded + " \n Conference: " + Conference + " \n Division: " +
                Division + " \n Homestadium: " + Stadium + " \n Championships: " + Championships;
        }
    }
}