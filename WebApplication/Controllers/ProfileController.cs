using System;
using System.Web.Mvc;
using WebApplication.Models.Profile;

namespace WebApplication.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult profileView(string id)
        {
            ProfileModel model = null;
            try
            {
                model = new ProfileModel(Int32.Parse(id));
            }
            catch(Exception e)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            return View("Profile", model);
        }
    }
}