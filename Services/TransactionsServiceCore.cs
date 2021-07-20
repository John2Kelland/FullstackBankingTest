using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radancy_Bank_Challenge.Utilities;

namespace Radancy_Bank_Challenge.Services
{
    public class TransactionsServiceCore
    {
        #region Balance Modification Services

        public bool ProcessDeposit(int accountID, int deposit)
        {
            bool transactionSuccessful = false;

            if (!ValidateMaximumDeposit(deposit)) { return transactionSuccessful; }

            // sql update logic to change Accounts.BALANCE based on Accounts.ACCOUNT_ID

            return transactionSuccessful;
        }

        public bool ProcessWithdrawal(int accountID, int withdrawal)
        {
            bool transactionSuccessful = false;

            // sql query logic to pull account balance from accountID
            int accountBalance = 0;

            if (!ValidateMaximumWithdrawal(accountBalance, withdrawal) ||
                !ValidateMinimumAccountBalance(accountBalance - withdrawal)) { return transactionSuccessful; }

            // sql update logic to change Accounts.BALANCE based on Accounts.ACCOUNT_ID

            return transactionSuccessful;
        }
        
        #endregion

        #region Transaction Validation Rules

        public bool ValidateMinimumAccountBalance(int remainingBalance)
        {
            return remainingBalance >= GlobalConstants.MinimumAccountBalance;
        }

        public bool ValidateMaximumWithdrawal(int accountBalance, int withdrawal)
        {
            return withdrawal <= GlobalConstants.MaximumWithdrawalPercentage*accountBalance;
        }

        public bool ValidateMaximumDeposit(int deposit)
        {
            return deposit <= GlobalConstants.MaximumDeposit;
        }

        #endregion
    }
}
