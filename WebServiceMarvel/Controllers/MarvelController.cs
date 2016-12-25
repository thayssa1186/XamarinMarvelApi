using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceMarvel.Service;

namespace WebServiceMarvel.Controllers
{
    public class MarvelController : BaseApiController
    {
        [HttpGet]
        [BasicAuthentication(RequireSsl = false)]
        public HttpResponseMessage Get()
        {
            return base.BuildSuccessResult(HttpStatusCode.OK, WrapperServiceMarvel.characters());
        }
    }
}
