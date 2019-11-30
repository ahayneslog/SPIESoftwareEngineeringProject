﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profiles.Business
{
    public class ProfileCollection
    {

        public List<Profile> ProfileList;

        public ProfileCollection()
        {
            ProfileList = new List<Profile>()
            {
                new Profile()
                {
                    ID = 1,
                    FirstName = "Jim",
                    LastName = "Bob",
                    Company = "SPIE",
                    SPIERole = "SPIE Member",
                    JobTitle = "UX/UI Designer",
                    PictureFileName = "jimbob.jpg"
                },
                new Profile()
                {
                    ID = 2,
                    FirstName = "Samantha",
                    LastName = "Johnson",
                    Company = "SPIE",
                    SPIERole = "SPIE Fellow",
                    JobTitle = "Optics & Photonics Researcher",
                    PictureFileName = "samanthajohnson.jpg"
                },
                new Profile()
                {
                    ID = 3,
                    FirstName = "Jackie",
                    LastName = "Zope",
                    Company = "NASA",
                    SPIERole = "SPIE Conference Chair",
                    JobTitle = "Astrophysicist",
                    PictureFileName = "jackiezope.jpg"
                },
                 new Profile()
                {
                    ID = 4,
                    FirstName = "Jonathon",
                    LastName = "Watkinson",
                    Company = "Blue Origins",
                    SPIERole = "SPIE Member",
                    JobTitle = "Embedded Optical Engineer",
                    PictureFileName = "jonathonwatkinson.jpg"
                }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID">Associated ID to User</param>
        /// <returns>If ID was valid, a profile. Otherwise, a null value.</returns>
        public Profile GetProfile(int ID)
        {            
            //Solution #1: This approach allows us to avoid validation on ID value
            //Current Runtime: O(n)
            //However, if O(ProfileList) becomes exponentially large,
            //the search needs to switch to a binary search.
            //We really don't want to deal with a linear search where the ID's value is 1,000,000.
            //A cleaner solution would be to do the following:
            //Solution #2: The assumption in this scenario is that ProfileList is sorted
            //We can also safely assume that the situation is a "write once, read often"
            //where a user is doing multiple searches. 
            //So do a sort once, then binary search often.
            //Another situation to consider is checking if new profiles came in. 
            //Resort when necessary.
            //Sort: Insertion Sort
            //Search: Binary Search
            //Solution #3: A direct query to database by sanitizing the input of ID.
            //This also reduces data on mobile device instead of 
            //hosting irrelevant profile information for searching
            Profile foundProfile = null;            
            foreach(Profile profile in ProfileList)
            {
                if (profile.ID == ID) foundProfile = profile;
            }
            return foundProfile;
        }
    }
}