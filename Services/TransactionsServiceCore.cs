using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radancy_Bank_Challenge.Models;
using Radancy_Bank_Challenge.Utilities;

namespace Radancy_Bank_Challenge.Services
{
    public class TransactionsServiceCore
    {
        #region Balance Modification Services

        public static bool ProcessWithdrawal(string accountId, double withdrawal, out string errorMessage)
        {
            bool transactionSuccessful = false; errorMessage = "";

            // copy the account being acted upon and pass it through validations
            UserAccount userAccount = GlobalData.UserAccounts.Where(x => x.Username.Equals(GlobalData.ActiveSystemUser) && x.AccountId.Equals(accountId)).FirstOrDefault();

            if (userAccount == null) { errorMessage = GlobalConstants.ErrorMessages.INVALIDACCOUNTID; return transactionSuccessful; }
            UserAccount testAccount = new UserAccount(userAccount.Username, userAccount.AccountId, userAccount.AccountName, userAccount.Balance);
            if (!ValidateMaximumWithdrawal(testAccount, withdrawal)) { errorMessage = GlobalConstants.ErrorMessages.EXCEEDSMAXIMUMWITHDRAWALPERCENTAGE; return transactionSuccessful; }
            if (!UserAccountServiceCore.ValidateSufficientBalance(testAccount)) { errorMessage = GlobalConstants.ErrorMessages.INSUFFICIENTACCOUNTBALANCE; return transactionSuccessful; }

            // update the balance of the account being acted upon
            try
            {
                GlobalData.UserAccounts.Where(x => x.Username.Equals(GlobalData.ActiveSystemUser) && x.AccountId.Equals(accountId)).ToList().ForEach(y => { y.Balance -= withdrawal; });
                transactionSuccessful = true;
            }
            catch { }

            return transactionSuccessful;
        }

        public static bool ProcessDeposit(string accountId, double deposit, out string errorMessage)
        {
            bool transactionSuccessful = false; errorMessage = "";

            // validate the deposit amount against the maximum permissible value
            if (!ValidateMaximumDeposit(deposit)) { errorMessage = GlobalConstants.ErrorMessages.EXCEEDSMAXIMUMDEPOSIT; return transactionSuccessful; }

            // udpate the balance of the account being acted upon
            try
            {
                GlobalData.UserAccounts.Where(x => x.Username.Equals(GlobalData.ActiveSystemUser) && x.AccountId.Equals(accountId)).ToList().ForEach(y => { y.Balance += deposit; });
                transactionSuccessful = true;
            }
            catch { }

            return transactionSuccessful;
        }
        
        #endregion

        #region Transaction Validation Rules

        public static bool ValidateMaximumWithdrawal(UserAccount userAccount, double withdrawal)
        {
            return withdrawal <= GlobalConstants.MaximumWithdrawalPercentage*userAccount.Balance;
        }

        public static bool ValidateMaximumDeposit(double deposit)
        {
            return deposit <= GlobalConstants.MaximumDeposit;
        }

        #endregion
    }
}
