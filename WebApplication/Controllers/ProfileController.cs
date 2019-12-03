using System;
using System.Web.Mvc;
using WebApplication.Models.Profile;

namespace WebApplication.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult profileView(string id)
        {
            try
            {
                return View("Profile", new ProfileModel(Int32.Parse(id)));
            }
            catch(Exception e)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
        }

        public ActionResult Edit(string id)
        {
            try
            {
                return View("EditProfile", new ProfileModel(Int32.Parse(id)));
            }
            catch (Exception e)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
        }
    }
}