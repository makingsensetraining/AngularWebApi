namespace Hiperion.Controllers
{
    using System.Web.Http;
    using Domain;
    using Infrastructure.EF.Interfaces;

    public class UsersController : ApiController
    {
        private readonly IDbContext _dbContext;

        public UsersController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IHttpActionResult GetUsers()
        {
            return Ok(
                new
                {
                    Results = _dbContext.Entity<User>()
                }
                );
        }
    }
}