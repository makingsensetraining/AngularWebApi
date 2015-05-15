namespace Hiperion.Controllers
{
    #region References

    using System.Web.Mvc;

    #endregion

    public class HomeController : Controller
    {
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
    }
}