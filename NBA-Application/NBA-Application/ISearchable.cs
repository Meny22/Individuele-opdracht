using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA_Application
{
    /// <summary>
    /// This interface is used to group the objects that can get searched by the visitor
    /// </summary>
    public interface ISearchable
    {
        string Search
        {
            get;
        }
    }
}