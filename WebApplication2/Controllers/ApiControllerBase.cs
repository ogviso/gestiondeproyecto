using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    public class ApiControllerBase : Controller
    {
        public ApiControllerBase()
        {

        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage request, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;

            try
            {
                response = function.Invoke();
            }

            catch (Exception)
            {
                response = request.CreateResponse(System.Net.HttpStatusCode.BadRequest);
            }
            return response;
        }
    }
}
