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

        public static bool AddSystemUser(string email, string username, string password, out string errorMessage)
        {
            bool userAdded = false; errorMessage = "";

            SystemUser newSystemUser = new SystemUser(email, username, password);

            // add a record
            try
            {
                if (GlobalData.SystemUsers != null)
                {
                    GlobalData.SystemUsers.Add(newSystemUser);
                }
                else
                {
                    List<SystemUser> systemUsers = new List<SystemUser>() { newSystemUser };
                    GlobalData.SystemUsers = systemUsers;
                }
                userAdded = true;
            }
            catch
            {
                errorMessage = GlobalConstants.ErrorMessages.UNEXPECTEDNEWUSERFAILURE;
            }

            return userAdded;
        }

        #endregion

        #region System User Validation Rules

        public static bool ValidateSystemUserEmail(string email)
        {
            bool validEmailAddress = true;

            // The address must be populated and contain the characters '@' and '.'
            if (email == null || email == "" || !email.Contains("@") || !email.Contains("."))
            {
                validEmailAddress = false;
            }

            return validEmailAddress;
        }

        public static bool ValidateUserCredentials(string username, string password)
        {
            bool validUser = false;

            if (GlobalData.SystemUsers != null)
            {
                if (GlobalData.SystemUsers.Select(x => x.Username).Contains(username))
                {
                    string systemPassword = GlobalData.SystemUsers.Where(x => x.Username.Equals(username)).FirstOrDefault().Password;
                    if (systemPassword.Equals(password)) { validUser = true; }
                }
            }

            return validUser;
        }

        #endregion
    }
}
