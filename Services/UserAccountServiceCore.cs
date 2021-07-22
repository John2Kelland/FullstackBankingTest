using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radancy_Bank_Challenge.Models;
using Radancy_Bank_Challenge.Utilities;

namespace Radancy_Bank_Challenge.Services
{
    public class UserAccountServiceCore
    {
        #region User Account Modification Services

        public static bool AddUserAccount(string accountId, string accountName, double initialBalance)
        {
            bool accountAdded = false;

            UserAccount newUserAccount = new UserAccount(GlobalData.ActiveSystemUser, accountId, accountName, initialBalance);

            // add a record
            try
            {
                if (GlobalData.UserAccounts != null)
                {
                    GlobalData.UserAccounts.Add(newUserAccount);
                }
                else
                {
                    List<UserAccount> userAccounts = new List<UserAccount>() { newUserAccount };
                    GlobalData.UserAccounts = userAccounts;
                }
                accountAdded = true;
            }
            catch { }

            return accountAdded;
        }

        public static bool UpdateUserAccount(string accountId, string accountName)
        {
            bool accountUpdated = false;

            try
            {
                GlobalData.UserAccounts.Where(x => x.Username.Equals(GlobalData.ActiveSystemUser) && x.AccountId.Equals(accountId)).ToList().ForEach(y => { y.AccountName = accountName; });
                accountUpdated = true;
            }
            catch { }

            return accountUpdated;
        }

        public static bool DeleteUserAccount(string accountId)
        {
            bool accountDeleted = false;

            try
            {
                GlobalData.UserAccounts.RemoveAll(x => x.Username.Equals(GlobalData.ActiveSystemUser) && x.AccountId.Equals(accountId));
                accountDeleted = true;
            }
            catch { }

            return accountDeleted;
        }

        #endregion

        #region User Account Validation Rules

        public static bool ValidateUniqueAccountID(string accountID)
        {
            bool uniqueAccountID = true;

            return uniqueAccountID;
        }

        public static bool ValidateSufficientBalance(double balance)
        {
            return balance >= 100;
        }

        #endregion
    }
}
