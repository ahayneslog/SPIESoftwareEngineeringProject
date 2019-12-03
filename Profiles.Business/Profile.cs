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
        private string username;
        private string password;

        public string getUsername()
        {
            return username;
        }

        public string getPassword()
        {
            return password;
        }

        public void setUsername(string uname)
        {
            username = uname;
        }

        public void setPassword(string pw)
        {
            password = pw;
        }
    }
}
