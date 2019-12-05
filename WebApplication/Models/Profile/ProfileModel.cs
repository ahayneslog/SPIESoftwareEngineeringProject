using System;
using Profiles.Business;

namespace WebApplication.Models.Profile
{
    public class ProfileModel
    {
        public ProfileModel()
        {

        }

        public ProfileModel(int ID)
        {
            //Retrieve current selection of profiles
            ProfileCollection collection = new ProfileCollection();
            //Determine if queried profile exists
            Profiles.Business.Profile userProfile = collection.GetProfile(ID);
            if(userProfile != null)
            {
                FullName = userProfile.FirstName + " " + userProfile.LastName;
                SPIERole = userProfile.SPIERole;
                Company = userProfile.Company;
                JobTitle = userProfile.JobTitle;
                PictureFileName = userProfile.PictureFileName;
            }
            else
            {
                throw new Exception("Profile doesn't exist");
            }
        }


        public string FullName;
        public string SPIERole;
        public string Company;
        public string JobTitle;
        public string PictureFileName;
    }
}