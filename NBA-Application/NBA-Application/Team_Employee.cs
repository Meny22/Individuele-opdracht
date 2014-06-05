using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA_Application
{
    public class Team_Employee : ISearchable
    {
        public string EmployeeName
        {
            get;
            set;
        }
        public string College
        {
            get;
            set;
        }
        public string Function
        {
            get;
            set;
        }
        public string AssistentName
        {
            get;
            set;
        }

        public string TeamName
        {
            get;
            set;
        }
	    public Team_Employee(string employee_name, string college, string function, string assistent, string teamname)
	    {
            this.EmployeeName = employee_name;
            this.College = college;
            this.Function = function;
            this.AssistentName = assistent;
            this.TeamName = teamname;
	    }

        public string Search
        {
            get { return this.EmployeeName; }
        }

        public override string ToString()
        {
            return " Name : " + this.EmployeeName + " \n College: " + this.College + " \n Function: " + this.Function + " \n Assistent: " + this.AssistentName
                + " \n Team: " + this.TeamName;
        }
    }
}