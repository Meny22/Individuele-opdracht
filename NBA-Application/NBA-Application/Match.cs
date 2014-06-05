using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA_Application
{
    public class Match
    {
        public int MatchID
        {
            get;
            set;
        }
        
        public DateTime DateTime
        {
            get;
            set;
        }

        public string HomeTeam
        {
            get;
            set;
        }
        public string AwayTeam
        {
            get;
            set;
        }
        public int HomeScore
        {
            get;
            set;
        }

        public int AwayScore
        {
            get;
            set;
        }
        public string StadiumName
        {
            get;
            set;
        }

        public string TopScorer
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }
	    public Match(DateTime datetime, string hometeam, string awayteam, string stadiumname)
	    {
            this.DateTime = datetime;
            this.HomeTeam = hometeam;
            this.AwayTeam = awayteam;
            this.StadiumName = stadiumname;
	    }

        public bool AddDetails(int Home_Score, int Away_Score, string Top_Scorer)
        {
            DatabaseConnection db = new DatabaseConnection();
            if (db.AddDetails(this.MatchID, Home_Score, Away_Score, Top_Scorer))
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            if(Status == "PLAYED")
            {
                return this.MatchID + ". " + this.HomeTeam + " vs " + this.AwayTeam + " " + this.HomeScore + "-" + this.AwayScore;
            }
            else if(Status == "NOTPLAYED")
            {
                return this.MatchID + ". " + this.DateTime.ToString("HH:mm") + " " + this.HomeTeam + " vs " + this.AwayTeam;
            }
            return "";
        }

    }
}