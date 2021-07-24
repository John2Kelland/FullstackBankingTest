using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radancy_Bank_Challenge.Services;
using Radancy_Bank_Challenge.Utilities;
using Radancy_Bank_Challenge.Models;

namespace Radancy_Bank_Challenge.UnitTests
{
    [TestClass]
    public class AccountUnitTests
    {
        [TestMethod]
        public void UniqueAccountId()
        {
            // arrange - specify global properties required for verifying accounts
            GlobalData.UserAccounts = new List<UserAccount>(); GlobalData.ActiveSystemUser = "test_user";
            // arrange - add an account to the list stored in GlobalData
            GlobalData.UserAccounts.Add(new UserAccount(GlobalData.ActiveSystemUser, "1234567890", "test_account"));
            // arrange - create a new account that does not share an ID with the account currently stored in GlobalData
            UserAccount userAccount = new UserAccount(GlobalData.ActiveSystemUser, "0987654321", "test_account");

            // act - call the unique account ID validation service (references GlobalData)
            bool uniqueAccountId = UserAccountServiceCore.ValidateUniqueAccountID(userAccount); 

            // assert - the validation service should have returned true
            Assert.IsTrue(uniqueAccountId);
        }

        [TestMethod]
        public void DuplicateAccountId()
        {
            // arrange - specify global properties required for verifying accounts
            GlobalData.UserAccounts = new List<UserAccount>(); GlobalData.ActiveSystemUser = "test_user";
            // arrange - add an account to the list stored in GlobalData
            GlobalData.UserAccounts.Add(new UserAccount(GlobalData.ActiveSystemUser, "1234567890", "test_account"));
            // arrange - create a new account that shares an ID with the account currently stored in GlobalData
            UserAccount userAccount = new UserAccount(GlobalData.ActiveSystemUser, "1234567890", "test_account");

            // act - call the unique account ID validation service (references GlobalData)
            bool uniqueAccountId = UserAccountServiceCore.ValidateUniqueAccountID(userAccount);

            // assert - the validation service should have returned false
            Assert.IsFalse(uniqueAccountId);
        }

        [TestMethod]
        public void AccountBalanceAboveMinimumValue()
        {
            // arrange - specify a balance above the required minimum value
            double balance = 150.00;
            // arrange - create a new user account with the specified balance
            UserAccount userAccount = new UserAccount("test_user", "1234567890", "test_account", balance);

            // act - call the minimum account balance validation service
            bool validBalance = UserAccountServiceCore.ValidateSufficientBalance(userAccount);

            // assert - the validation service should have returned true
            Assert.IsTrue(validBalance);
        }

        [TestMethod]
        public void AccountBalanceBelowMinimumValue()
        {
            // arrange - specify a balance below the required minimum value
            double balance = 50.00;
            // arrange - create a new user account with the specified balance
            UserAccount userAccount = new UserAccount("test_user", "1234567890", "test_account", balance);

            // act - call the minimum account balance validation service
            bool validBalance = UserAccountServiceCore.ValidateSufficientBalance(userAccount);

            // assert - the validation service should have returned false
            Assert.IsFalse(validBalance);
        }

        [TestMethod]
        public void AccountBalanceMatchesMinimumValue()
        {
            // arrange - specify a balance equal to the required minimum value
            double balance = 100.00;
            // arrange - create a new user account with the specified balance
            UserAccount userAccount = new UserAccount("test_user", "1234567890", "test_account", balance);

            // act - call the minimum account balance validation service
            bool validBalance = UserAccountServiceCore.ValidateSufficientBalance(userAccount);

            // assert - the validation service should have returned true
            Assert.IsTrue(validBalance);
        }
    }
}
