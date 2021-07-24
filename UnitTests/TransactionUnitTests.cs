using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radancy_Bank_Challenge.Services;
using Radancy_Bank_Challenge.Models;

namespace Radancy_Bank_Challenge.UnitTests
{
    [TestClass]
    public class TransactionUnitTests
    {
        [TestMethod]
        public void MaximumWithdrawalNotExceeded()
        {
            // arrange - create a new user account
            UserAccount userAccount = new UserAccount("test_user", "1234567890", "test_account", 10000);
            // arrange - specify a withdrawal that does not exceed the maximum value
            double withdrawal = 8500.00;

            // act - call the maximum withdrawal validation service
            bool validWithdrawal = TransactionsServiceCore.ValidateMaximumWithdrawal(userAccount, withdrawal);

            // assert - the validation service should have returned true
            Assert.IsTrue(validWithdrawal);
        }

        [TestMethod]
        public void MaximumWithdrawalExceeded()
        {
            // arrange - create a new user account
            UserAccount userAccount = new UserAccount("test_user", "1234567890", "test_account", 10000);
            // arrange - specify a withdrawal that exceeds the maximum value
            double withdrawal = 9500.00;

            // act - call the maximum withdrawal validation service
            bool validWithdrawal = TransactionsServiceCore.ValidateMaximumWithdrawal(userAccount, withdrawal);

            // assert - the validation service should have returned false
            Assert.IsFalse(validWithdrawal);
        }

        [TestMethod]
        public void MaximumWithdrawalMatched()
        {
            // arrange - create a new user account
            UserAccount userAccount = new UserAccount("test_user", "1234567890", "test_account", 10000);
            // arrange - specify a withdrawal that equals the maximum value
            double withdrawal = 9000.00;

            // act - call the maximum withdrawal validation service
            bool validWithdrawal = TransactionsServiceCore.ValidateMaximumWithdrawal(userAccount, withdrawal);

            // assert - the validation service should have returned true
            Assert.IsTrue(validWithdrawal);
        }

        [TestMethod]
        public void MaximumDepositNotExceeded()
        {
            // arrange - specify a deposit that does not exceed the maximum value
            double deposit = 9000.00;

            // act - call the maximum deposit validation service
            bool validDeposit = TransactionsServiceCore.ValidateMaximumDeposit(deposit);

            // assert - the validation service should have returned true
            Assert.IsTrue(validDeposit);
        }

        [TestMethod]
        public void MaximumDepositExceeded()
        {
            // arrange - specify a deposit that exceeds the maximum value
            double deposit = 11000.00;

            // act - call the maximum deposit validation service
            bool validDeposit = TransactionsServiceCore.ValidateMaximumDeposit(deposit);

            // assert - the validation service should have returned false
            Assert.IsFalse(validDeposit);
        }

        [TestMethod]
        public void MaximumDepositMatched()
        {
            // arrange - specify a deposit that matches the maximum value
            double deposit = 10000.00;

            // act - call the maximum deposit validation service
            bool validDeposit = TransactionsServiceCore.ValidateMaximumDeposit(deposit);

            // assert - the validation service should have returned true
            Assert.IsTrue(validDeposit);
        }
    }
}