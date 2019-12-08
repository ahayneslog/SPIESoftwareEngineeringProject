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
            catch (Exception)
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
            catch (Exception)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection fc)
        {
            ProfileModel newProfile = new ProfileModel();
            newProfile.Company = fc["Company"];
            newProfile.JobTitle = fc["JobTitle"];
            //Not adding code here because we should be using the ID of the profile to make the update to the database
            //and then return the new model to the EditProfile view
            //Design Issue here: ProfileModel does not contain the ID of the profile
            return View("EditProfile", newProfile);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(FormCollection fc)
        {
            try
            {
                Profile newProfile = new Profile();
                var fullName = fc["FullName"];
                
                
                string firstName = fullName.Substring(0, fullName.IndexOf(' '));
                //Treat everything after first white space as Last Name
                string lastName = fullName.Substring(fullName.IndexOf(' ') + 1);
                newProfile.FirstName = firstName;
                newProfile.LastName = lastName;
                newProfile.Company = fc["Company"];
                newProfile.JobTitle = fc["JobTitle"];
                newProfile.role = ProfileRoles.USER;
                newProfile.SPIERole = "SPIE Member";
                //In future builds, add validation check if username already exists
                newProfile.username = fc["Username"];
                //In future builds, add validation check if password meets password requirements
                newProfile.username = fc["Password"];
                //Next two lines would be replaced with a database call if user passes all validation checks
                ProfileCollection collection = new ProfileCollection();
                collection.ProfileList.Add(newProfile);

                //After database call is successful, send the user to profileView with newly created ID
                //otherwise, for assignment demo purpose, just go back home
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
                        HttpCookie role = new HttpCookie("Role");
                        role.Value = profile.role;
                        this.ControllerContext.HttpContext.Response.Cookies.Add(userID);
                        this.ControllerContext.HttpContext.Response.Cookies.Add(userNm);
                        this.ControllerContext.HttpContext.Response.Cookies.Add(role);
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
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Role"))
            {
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["Role"];
                cookie.Expires = DateTime.Now.AddDays(-1);
                this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
    }
}