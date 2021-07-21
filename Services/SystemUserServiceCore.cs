using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radancy_Bank_Challenge.Utilities;
using Radancy_Bank_Challenge.Models;

namespace Radancy_Bank_Challenge.Services
{
    public class SystemUserServiceCore
    {
        #region System User Modification Services

        public bool AddSystemUser(string username, string password, string email)
        {
            bool userAdded = false;

            try
            {
                GlobalData.SystemUsers.Add(new SystemUser(username, password, email));

                userAdded = true;
            }
            catch
            {
                // something with ex.Message perhaps
            }

            return userAdded;
        }

        #endregion

        #region System User Validation Rules

        public bool ValidateUserCredentials(string username, string password)
        {
            bool validUser = false;

            if (GlobalData.SystemUsers.Select(x => x.Username).Contains(username))
            {
                string systemPassword = GlobalData.SystemUsers.Where(x => x.Username.Equals(username)).FirstOrDefault().Password;
                if (systemPassword.Equals(password)) { validUser = true; }
            }

            return validUser;
        }

        #endregion
    }
}
