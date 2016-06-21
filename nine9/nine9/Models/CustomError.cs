using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nine9.Models
{
    // manage the custom error object
    public class CustomError
    {
        #region Properties
        public string error { get; private set; }
        #endregion
        public CustomError(string strcustmsg)
        {
            this.error = strcustmsg;
        }
    }
}