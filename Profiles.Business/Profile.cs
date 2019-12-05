using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profiles.Business
{
    public class Profile
    {
        public string FirstName;
        public string LastName;
        public string SPIERole;
        public string Company;
        public string JobTitle;
        public string PictureFileName;
        public int ID;

        //Since we are not using a database, we will use a basic username/password set up
        public string username;
        public string password;
        public string role;
    }
}
