using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Profiles.Business;

namespace WebApplication.Controllers
{
    public class SearchResultsController : Controller
    {
        // GET: SearchResults
        public ActionResult SearchResults(string txtSearch)
        {
            if(!String.IsNullOrEmpty(txtSearch))
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
                if (names.Length > 1)
                {
                    string firstName = txtSearch.Substring(0, txtSearch.IndexOf(' '));
                    //Treat everything after first white space as Last Name
                    string lastName = txtSearch.Substring(txtSearch.IndexOf(' ') + 1);
                    profiles = collection.GetProfilesByFullName(firstName, lastName);
                }
                if(profiles.Count > 0)
                {
                    return View(profiles);
                }
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public ActionResult Details(string id)
        {
            return RedirectToAction(actionName: "profileView", controllerName: "profile", routeValues: new { id = id });
        }
    }
}