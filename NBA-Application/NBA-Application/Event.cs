using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA_Application
{
    public class Event : ISearchable
    {
        public string EventName
        {
            get;
            set;
        }

        public string BeginDate
        {
            get;
            set;
        }
	    public Event(string eventname, string begindate)
	    {
            this.EventName = eventname;
            this.BeginDate = begindate;
	    }


        public string Search
        {
            get { return this.EventName; }
        }

        public override string ToString()
        {
            return " Name Event: " + EventName + " \n BeginDate: " + BeginDate;
        }
    }
}