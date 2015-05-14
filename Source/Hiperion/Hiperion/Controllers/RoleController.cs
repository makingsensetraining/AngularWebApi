namespace Hiperion.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Models;
    using Services.Interfaces;

    public class RoleController : ApiController
    {
        private readonly IRoleServices _roleServices;

        public RoleController(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        //GET: /api/User
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var roles = _roleServices.GetAllRoles();
            return roles == null
                ? Request.CreateResponse(HttpStatusCode.NotFound)
                : Request.CreateResponse(HttpStatusCode.OK, roles);
        }

        [HttpPost] // POST api/user
        public HttpResponseMessage Post(RoleDto role)
        {
            _roleServices.SaveOrUpdateRole(role);
            return Request.CreateResponse(HttpStatusCode.OK, role);
        }

        [HttpDelete] // DELETE api/user/5
        public HttpResponseMessage Delete(int id)
        {
            _roleServices.DeleteRole(id);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
