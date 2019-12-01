using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.Profile;
using Profiles.Business;

namespace WebApplication.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult profileView(string id)
        {
            ProfileModel model = new ProfileModel(Int32.Parse(id));

            return View("Profile", model);
        }

        //Create an action method to handle the image click and enter key when text form is the focus
        //This will be an HTTP Get Action
        //[AcceptVerbs(HttpVerbs.Get)]
        [AcceptVerbs(HttpVerbs.Get)]
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
                int id = collection.GetIndexOfProfileByName(firstName, lastName);
                if (id > 0 && id <= collection.ProfileList.Count)
                {
                    //RedirectToAction("profileView", id.ToString());
                    return RedirectToAction("profileView", "ProfileController", "1");
                }
            }
            return View();
        }
    }
}