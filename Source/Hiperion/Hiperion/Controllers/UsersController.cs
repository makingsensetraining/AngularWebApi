using System.Web.Http;
using System.Web.Mvc;
using Hiperion.Infrastructure.EF.Interfaces;

namespace Hiperion.Controllers
{
    public class UsersController : ApiController
    {
        private IDbContext _dbContext;

        public UsersController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult GetUsers()
        {
            return null;
        }
    }
}
