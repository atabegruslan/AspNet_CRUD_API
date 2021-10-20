using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using TravelBlog.Models;
using TravelBlog.ViewModels;

namespace TravelBlog.Controllers
{
    [RoutePrefix("Api/Destinations")]
    public class RestApiController : ApiController
    {
        private DestinationsDBEntities _db = new DestinationsDBEntities();

        [HttpGet]
        [Route("Test")]
        public string Test()
        {
            return "Welcome To Web API blah blah";
        }

        [HttpGet]
        [Route("AllDestinations")]
        public IHttpActionResult Index()
        {
            try
            {
                var destinations = (
                    from d in _db.Destinations
                    select new DestinationCountry
                    {
                        Id = d.Id,
                        Name = d.Name,
                        Description = d.Description,
                        CountryName = d.Country.Name
                    }
                ).ToList();

                return Ok(destinations);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
