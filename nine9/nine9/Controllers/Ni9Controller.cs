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
        public HttpResponseMessage Post(Programs programs)
        {
            if (programs == null)
                return Request.CreateResponse<CustomError>(HttpStatusCode.BadRequest, new CustomError("Could not decode request: JSON parsing failed"));
            else
            {
                try
                {
                    return Request.CreateResponse<ResponseResult>(HttpStatusCode.OK, new ResponseResult(programs.payload));
                }
                catch(Exception)
                { return Request.CreateResponse<CustomError>(HttpStatusCode.BadRequest, new CustomError("Could not decode request: JSON parsing failed")); }
            }
            
        }

      
    }
}
