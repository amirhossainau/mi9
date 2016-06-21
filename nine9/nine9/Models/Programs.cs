using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nine9.Models
{
    public class Programs
    {
        #region Properties
        public List<Payload> payload { get; set; }
        public int skip { get; set; }
        public int take { get; set; }
        public int totalRecords{get;set;}
        #endregion
    }
}