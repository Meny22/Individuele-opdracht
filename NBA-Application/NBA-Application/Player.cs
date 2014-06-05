using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA_Application
{
    public class Player : ISearchable
    {
        public string Name
        {
            get;
            set;
        }

        public int Length
        {
            get;
            set;
        }

        public int Weight
        {
            get;
            set;
        }

        public string School_Country
        {
            get;
            set;
        }

        public string BirthDate
        {
            get;
            set;
        }

        public int Pro_Year
        {
            get;
            set;
        }

        public Position Position_Player
        {
            get;
            set;
        }

        public string TeamName
        {
            get;
            set;
        }

        public enum Position
        {
            PG,
            SG,
            SF,
            PF,
            C
        }

	    public Player(string name, int length, int weight, string school_country, string birthdate, int pro_year, Position position_player, string team)
	    {
            this.Name = name;
            this.Length = length;
            this.Weight = weight;
            this.School_Country = school_country;
            this.BirthDate = birthdate;
            this.Pro_Year = pro_year;
            this.Position_Player = position_player;
            this.TeamName = team;
	    }

        public string Search
        {
            get { return this.Name; }
        }

        public override string ToString()
        {
            return " Name: " + Name + " \n Length: " + Length + " \n Weight: " + Weight + " \n School/Country: " + School_Country +
                " \n Birthday: " + BirthDate + " \n Pro Year: " + Pro_Year + " \n Position: " + Position_Player + "\n Team: " + TeamName;
        }
    }
}