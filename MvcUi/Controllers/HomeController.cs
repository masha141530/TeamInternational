using MvcUi.Infrastructure;
using MvcUi.ViewModels;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamProject.DAL.Entities;
using TeamProject.DAL.Repositories.Interfaces;

namespace MvcUi.Controllers
{
    [CustomErrorHandler]//куда его лучше положить?
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IndexVM indexVM = new IndexVM();
            indexVM.isAutorized = false;
            indexVM.UserName = null;
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