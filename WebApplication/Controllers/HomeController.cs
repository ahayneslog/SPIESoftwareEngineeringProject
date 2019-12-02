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
                //Validation
                string[] names = txtSearch.Split(' ');
                //Retrieve profiles
                ProfileCollection collection = new ProfileCollection();
                List<Profile> profiles = new List<Profile>();

                //Partial Name Search
                if (names.Length == 1)
                {
                    profiles = collection.GetProfilesByFirstNameOrLastName(txtSearch);
                }
                //Full Name Search
                if(names.Length > 1)
                {
                    string firstName = txtSearch.Substring(0, txtSearch.IndexOf(' '));
                    //Treat everything after first white space as Last Name
                    string lastName = txtSearch.Substring(txtSearch.IndexOf(' ') + 1);
                    profiles = collection.GetProfilesByFullName(firstName, lastName);
                }

                //If only one profile comes back, go directly to it
                //If more than one comes back, go to Search Results View
                //If none come back, do nothing
                if (profiles.Count == 1)
                {
                    return RedirectToAction(actionName: "profileView", controllerName: "profile", routeValues: new { id = profiles[0].ID });
                }
                else if (profiles.Count > 1)
                {
                    //Add RedirectToAction(actionName: "searchResultsView", controllerName: "searchResults", routeValues: profiles)
                }
            }
            return RedirectToAction("Index");
        }
    }
}