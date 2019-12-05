using Profiles.Business;
using System;
using System.Linq;
using System.Web;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID")] ProfileModel profile)
        {
            if(ModelState.IsValid)
            {
                //update code here
                //use db to perform update
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            catch
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
        }

        public ActionResult Logon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logon(FormCollection collection)
        {
            try
            {
                string username = collection["Username"].Trim();
                string password = collection["Password"].Trim();

                ProfileCollection profiles = new ProfileCollection();
                foreach(Profile profile in profiles.ProfileList)
                {
                    if(profile.username.Equals(username) &&
                        profile.password.Equals(password))
                    {
                        HttpCookie userID = new HttpCookie("User");
                        userID.Value = profile.ID.ToString();
                        HttpCookie userNm = new HttpCookie("Username");
                        userNm.Value = profile.FirstName;
                        this.ControllerContext.HttpContext.Response.Cookies.Add(userID);
                        this.ControllerContext.HttpContext.Response.Cookies.Add(userNm);
                    }
                }

                if (Request.Cookies["User"] != null)
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                }
                else
                {
                    return RedirectToAction(actionName: "Logon", controllerName: "Profile");
                }
            }
            catch
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
        }

        public ActionResult Logoff()
        {
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("User"))
            {
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["User"];
                cookie.Expires = DateTime.Now.AddDays(-1);
                this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            }
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Username"))
            {
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["Username"];
                cookie.Expires = DateTime.Now.AddDays(-1);
                this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
    }
}