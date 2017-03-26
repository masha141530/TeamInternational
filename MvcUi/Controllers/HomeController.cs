using MvcUi.Infrastructure;
using MvcUi.ViewModels;

using System.Web.Mvc;

namespace MvcUi.Controllers
{
    [CustomErrorHandler]//куда его лучше положить?
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IndexModel indexVM = new IndexModel { isAutorized=false,UserName=null};
            if (User.Identity.IsAuthenticated)
            {
                indexVM.UserName = User.Identity.Name;
                indexVM.isAutorized = true;
              //  return RedirectToAction("Movie","List");
            }
            return View(indexVM);
            
        }
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

    }

   
}