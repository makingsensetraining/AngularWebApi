namespace Hiperion.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Models;
    using Services.Interfaces;

    public class UserController : ApiController
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            var users = _userServices.GetAllUsers();
            return users == null ?
                Request.CreateResponse(HttpStatusCode.NotFound) : 
                Request.CreateResponse(HttpStatusCode.OK, users);
        }

        [HttpPost]// POST api/user
        public HttpResponseMessage Post(UserDto user)
        {
            _userServices.SaveOrUpdateUser(user);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpDelete]// DELETE api/user/5
        public HttpResponseMessage Delete(int id)
        {
            _userServices.DeleteUser(id);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}