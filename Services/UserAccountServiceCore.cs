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

        public static bool AddUserAccount(string accountId, string accountName, double initialBalance, out string errorMessage)
        {
            bool accountAdded = false; errorMessage = "";

            UserAccount newUserAccount = new UserAccount(GlobalData.ActiveSystemUser, accountId, accountName, initialBalance);

            if (!ValidateSufficientBalance(newUserAccount)) { errorMessage = GlobalConstants.ErrorMessages.INSUFFICIENTACCOUNTBALANCE; return accountAdded; }
            if (!ValidateUniqueAccountID(newUserAccount)) { errorMessage = GlobalConstants.ErrorMessages.DUPLICATEACCOUNTID; return accountAdded; }

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
            catch { errorMessage = GlobalConstants.ErrorMessages.UNEXPECTEDNEWACCOUNTFAILURE; }

            return accountAdded;
        }

        public static bool UpdateUserAccount(string accountId, string accountName, out string errorMessage)
        {
            bool accountUpdated = false; errorMessage = "";

            try
            {
                GlobalData.UserAccounts.Where(x => x.Username.Equals(GlobalData.ActiveSystemUser) && x.AccountId.Equals(accountId)).ToList().ForEach(y => { y.AccountName = accountName; });
                accountUpdated = true;
            }
            catch 
            {
                errorMessage = GlobalConstants.ErrorMessages.UNEXPECTEDACCOUNTUPDATEFAILURE;
            }

            return accountUpdated;
        }

        public static bool DeleteUserAccount(string accountId, out string errorMessage)
        {
            bool accountDeleted = false; errorMessage = "";

            try
            {
                GlobalData.UserAccounts.RemoveAll(x => x.Username.Equals(GlobalData.ActiveSystemUser) && x.AccountId.Equals(accountId));
                accountDeleted = true;
            }
            catch 
            {
                errorMessage = GlobalConstants.ErrorMessages.UNEXPECTEDACCOUNTDELETIONFAIlURE;
            }

            return accountDeleted;
        }

        #endregion

        #region User Account Validation Rules

        public static bool ValidateUniqueAccountID(UserAccount userAccount)
        {
            return !GlobalData.UserAccounts.Where(x => x.Username.Equals(GlobalData.ActiveSystemUser)).Select(y => y.AccountId).ToList().Contains(userAccount.AccountId);
        }

        public static bool ValidateSufficientBalance(UserAccount userAccount)
        {
            return userAccount.Balance >= 100;
        }

        #endregion
    }
}
