using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Profiles.Business;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProfileCollection collection = new ProfileCollection();

            return View(collection);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SearchProfiles(string txtSearch)
        {
            //Capitalize the input and trim off whitespace at the end
            txtSearch = txtSearch.ToUpper().Trim();
            if (!String.IsNullOrEmpty(txtSearch))
            {
                return RedirectToAction(actionName: "SearchResults", controllerName: "SearchResults", routeValues: new { txtSearch = txtSearch });
            }
            return RedirectToAction("Index");
        }
    }
}