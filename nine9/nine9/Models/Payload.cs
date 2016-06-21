using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace nine9.Models
{
    public class Payload
    {
        #region Properties
        public string country { get; set; }

        public string description { get; set; }
        public bool drm { get; set; }
        public int episodeCount { get; set; }

        public string genre { get; set; }
        // refer to the image object
        public Image image { get; set; }
        public string language { get; set; }
        // refer to the nextepisode object
        public NextEpisolde nextEpisode { get; set; }
        public string primaryColour { get; set; }
        // refer to the season object an get the list one to many relationship
        public List<Season> seasons { get; set; }
        public string slug { get; set; }
        public string title { get; set; }
        public string tvChannel { get; set; }
        #endregion
    }
}