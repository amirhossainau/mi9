using nine9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace nine9.Controllers
{
     public class Ni9Controller : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(Programs programs)
        {
            List<Response> responselist;// = null;
            if (programs == null)
                throw new HttpResponseException(Request.CreateResponse<CustomError>(HttpStatusCode.BadRequest, new CustomError("Could not decode request: JSON parsing failed")));
            else
            {
                try
                {
                    responselist = new List<Response>();
                    responselist = programs.payload.Where(d => d.drm == true && d.episodeCount > 0).Select(x => new Response() { image = x.image.showImage, slug = x.slug, title = x.title }).ToList();
                }
                catch(Exception exception)
                { throw new HttpResponseException(Request.CreateResponse<CustomError>(HttpStatusCode.BadRequest, new CustomError("Could not decode request: JSON parsing failed"))); }
            }
            ResponseResult oResres = new ResponseResult();
            oResres.response = new List<Response>();
            oResres.response = responselist;
            return Json(oResres);// Request.CreateResponse<ResponseResult>(HttpStatusCode.OK, oResres);
        }
    }
}
