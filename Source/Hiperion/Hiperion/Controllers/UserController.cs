namespace Hiperion.Controllers
{
    #region References

    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Models;
    using Services.Interfaces;

    #endregion

    [Authorize]
    public class UserController : ApiController
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        //GET: /api/User
        [HttpGet]
        public HttpResponseMessage Get()
        {
            //ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            //var userName = principal.Claims.Where(c => c.Type == "sub").Single().Value;

            var users = _userServices.GetAllUsers();
            return users == null
                ? Request.CreateResponse(HttpStatusCode.NotFound)
                : Request.CreateResponse(HttpStatusCode.OK, users);
        }

        [HttpPost] // POST api/user
        public HttpResponseMessage Post(UserDto user)
        {
            _userServices.SaveOrUpdateUser(user);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpDelete] // DELETE api/user/5
        public HttpResponseMessage Delete(int id)
        {
            _userServices.DeleteUser(id);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPost] // POST api/signup
        public HttpResponseMessage SignUp(UserDto user)
        {
            _userServices.SignUp(user);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }
    }
}