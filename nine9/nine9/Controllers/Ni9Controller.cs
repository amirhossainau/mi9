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
            ResponseResult responseresult = null;
            if (programs == null)
                throw new HttpResponseException(Request.CreateResponse<CustomError>(HttpStatusCode.BadRequest, new CustomError("Could not decode request: JSON parsing failed")));
            else
            {
                try
                {
                    responseresult = new ResponseResult(programs.payload);
                }
                catch(Exception)
                { throw new HttpResponseException(Request.CreateResponse<CustomError>(HttpStatusCode.BadRequest, new CustomError("Could not decode request: JSON parsing failed"))); }
            }
            return Json(responseresult);
        }

      
    }
}
