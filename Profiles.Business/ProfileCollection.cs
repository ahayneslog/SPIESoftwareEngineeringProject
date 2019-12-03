using System;
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
                    PictureFileName = "jimbob1.jpg"
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
                },
                 new Profile()
                {
                    ID = 5,
                    FirstName = "Cynthia",
                    LastName = "Acosta",
                    Company = "NASA",
                    SPIERole = "SPIE Member",
                    JobTitle = "Software Engineer",
                    PictureFileName = "cynthiaacosta.jpg"
                },
                  new Profile()
                {
                    ID = 6,
                    FirstName = "Jim",
                    LastName = "Bob",
                    Company = "Blue Origins",
                    SPIERole = "SPIE Member",
                    JobTitle = "Research Engineer",
                    PictureFileName = "jimbob2.jpg"
                },
                  new Profile()
                {
                    ID = 7,
                    FirstName = "Jose",
                    LastName = "de la Cruz",
                    Company = "Space X",
                    SPIERole = "SPIE Member",
                    JobTitle = "Research Engineer",
                    PictureFileName = "albertzhang.jpg"
                }
            };
        }

        /// <summary>
        /// Retrieve the specified profile by ID number. 
        /// </summary>
        /// <param name="ID">Associated ID to User</param>
        /// <returns>If ID was valid, a profile. Otherwise, a null value.</returns>
        public Profile GetProfile(int ID)
        {
            return ProfileList.Where(p => p.ID == ID).FirstOrDefault();
        }

        /// <summary>
        /// Retrieve profiles by the single name input.
        /// It can match against first or last name. 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Profile> GetProfilesByFirstNameOrLastName(string name)
        {
            return ProfileList.Where(person =>
                                        person.FirstName.ToUpper().Contains(name.ToUpper()) ||
                                        person.LastName.ToUpper().Contains(name.ToUpper())).ToList();
        }

        /// <summary>
        /// Retrieve profiles by first name and last name.
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <returns>
        /// If first name and last names matchs, profile(s) will be returned. 
        /// Otherwise, a null value.</returns>
        public List<Profile> GetProfilesByFullName(string fName, string lName)
        {
            return ProfileList.Where(person =>
                                        person.FirstName.ToUpper().Contains(fName.ToUpper()) &&
                                        person.LastName.ToUpper().Contains(lName.ToUpper())).ToList();
        }

        /// <summary>
        /// Randomly selects up to three profiles to display on the Home Page.
        /// </summary>
        /// <returns></returns>
        public List<Profile> GetRandomProfiles()
        {
            List<Profile> profiles = new List<Profile>();
            //Determine that Profile List is not without memory
            if (ProfileList != null)
            {
                int limit = 3;
                IEnumerable<int> sequence = Enumerable.Range(0, ProfileList.Count - 1).OrderBy(n => n * n * (new Random()).Next());
                //If limit is higher than 
                if (sequence.Count() < 3)
                {
                    limit = sequence.Count();
                }
                IEnumerable<int> result = sequence.Distinct().Take(limit);
                foreach (int index in result)
                {
                    profiles.Add(ProfileList[index]);
                }
            }
            return profiles;
        }
    }
}
