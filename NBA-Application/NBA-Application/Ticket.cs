using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA_Application
{
    public abstract class Ticket
    {
        public string Type
        {
            get;
            set;
        }
        public int Price
        {
            get;
            set;
        }
        public string Section
        {
            get;
            set;
        }
        public int Row
        {
            get;
            set;
        }
        public int Seat
        {
            get;
            set;
        }
	    public Ticket(string type, int price, string section, int row, int seat)
	    {
            this.Type = type;
            this.Price = price;
            this.Section = section;
            this.Row = row;
            this.Seat = seat;
	    }
    }
}