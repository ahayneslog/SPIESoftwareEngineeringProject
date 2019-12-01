using System;
using System.Web.Mvc;
using WebApplication.Models.Profile;

namespace WebApplication.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult profileView(string id)
        {
            ProfileModel model = new ProfileModel(Int32.Parse(id));

            return View("Profile", model);
        }
    }
}