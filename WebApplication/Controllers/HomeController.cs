using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            //Use Regular Expression to break apart the txtSearch value to:
            //1) String before first occurrence of white space is First Name
            //2) String after white space is Last Name
            //If either empty, don't try to Redirect
            //If both populated and validated, redirect to profileView with correct ID
            if (!String.IsNullOrEmpty(txtSearch))
            {
                string firstName = txtSearch.Substring(0, txtSearch.IndexOf(' '));
                string lastName = txtSearch.Substring(txtSearch.IndexOf(' ') + 1);
                ProfileCollection collection = new ProfileCollection();
                int profileID = collection.GetIndexOfProfileByName(firstName, lastName);
                if (profileID > 0 && profileID <= collection.ProfileList.Count)
                {
                    //RedirectToAction("profileView", id.ToString());
                    return RedirectToAction(actionName: "profileView", controllerName: "profile", routeValues: new {id = profileID});
                }
            }
            return RedirectToAction("Index");
        }
    }
}