using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace nine9.Models
{
    public class Image
    {
        #region Properties
        [Display(Name="image")]
        public string showImage { get; set; }
        #endregion
    }
}