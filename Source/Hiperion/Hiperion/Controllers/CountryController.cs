namespace Hiperion.Controllers
{
    #region References

    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Models;
    using Services.Interfaces;

    #endregion

    public class CountryController : ApiController
    {
        private readonly ICountryServices _countryServices;

        public CountryController(ICountryServices countryServices)
        {
            _countryServices = countryServices;
        }

        //GET: /api/Country
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var countries = _countryServices.GetAllCountries();
            return countries == null
                ? Request.CreateResponse(HttpStatusCode.NotFound)
                : Request.CreateResponse(HttpStatusCode.OK, countries);
        }

        [HttpPost] // POST api/Country
        public HttpResponseMessage Post(CountryDto country)
        {
            _countryServices.SaveOrUpdateCountry(country);
            return Request.CreateResponse(HttpStatusCode.OK, country);
        }

        [HttpDelete] // DELETE api/Country/5
        public HttpResponseMessage Delete(int id)
        {
            _countryServices.DeleteCountry(id);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}