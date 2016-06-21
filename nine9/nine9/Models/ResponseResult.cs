using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nine9.Models
{
    public class ResponseResult
    {
        #region Properties
        public List<Response> response { get; private set; }
        public ResponseResult(List<Payload> payload)
        {
            this.response = payload.Where(d => d.drm == true && d.episodeCount > 0).Select(x => new Response { image = x.image.showImage, slug = x.slug, title = x.title }).ToList();
        }
        #endregion
    }
}