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
    public class SystemUserUnitTests
    {
        [TestMethod]
        public void ValidEmail()
        {
            // arrange - specify a valid email address
            string email = "jak374@cornell.edu";

            // act - call the email validation service
            bool validEmail = SystemUserServiceCore.ValidateSystemUserEmail(email);

            // assert - the validation service should have returned true
            Assert.IsTrue(validEmail);
        }

        [TestMethod]
        public void InvalidEmail_EmptyAddress()
        {
            // arrange - specify an empty email address
            string email = "";

            // act - call the email validation service
            bool validEmail = SystemUserServiceCore.ValidateSystemUserEmail(email);

            // assert - the validation service should have returned false
            Assert.IsFalse(validEmail);
        }

        [TestMethod]
        public void InvalidEmail_MissingAtSign()
        {
            // arrange - specify an email address without the @ sign
            string email = "jak374cornell.edu";

            // act - call the email validation service
            bool validEmail = SystemUserServiceCore.ValidateSystemUserEmail(email);

            // assert - the validation service should have returned false
            Assert.IsFalse(validEmail);
        }

        [TestMethod]
        public void InvalidEmail_MissingPeriod()
        {
            // arrange - specify an email address without a period
            string email = "jak374@cornelledu";

            // act - call the email validation service
            bool validEmail = SystemUserServiceCore.ValidateSystemUserEmail(email);

            // assert - the validation service should have returned false
            Assert.IsFalse(validEmail);
        }

        [TestMethod]
        public void ValidUserCredentials()
        {
            // arrange - specify global properties required for verifying system users
            GlobalData.SystemUsers = new List<SystemUser>();
            // arrange - add a system user to the list stored in GlobalData
            GlobalData.SystemUsers.Add(new SystemUser("test_email", "test_username", "test_password"));
            // arrange - specify the correct username and password strings
            string username = "test_username", password = "test_password";

            // act - call the user credentials validation service (references GlobalData)
            bool validUser = SystemUserServiceCore.ValidateUserCredentials(username, password);

            // assert - the validation service should have returned true
            Assert.IsTrue(validUser);
        }

        [TestMethod]
        public void InvalidUserCredentials_WrongUsername()
        {
            // arrange - specify global properties required for verifying system users
            GlobalData.SystemUsers = new List<SystemUser>();
            // arrange - add a system user to the list stored in GlobalData
            GlobalData.SystemUsers.Add(new SystemUser("test_email", "test_username", "test_password"));
            // arrange - specify an incorrect username string and a correct password string
            string username = "wrong_username", password = "test_password";

            // act - call the user credentials validation service (references GlobalData)
            bool validUser = SystemUserServiceCore.ValidateUserCredentials(username, password);

            // assert - the validation service should have returned false
            Assert.IsFalse(validUser);
        }

        [TestMethod]
        public void InvalidUserCredentials_WrongPassword()
        {
            // arrange - specify global properties required for verifying system users
            GlobalData.SystemUsers = new List<SystemUser>();
            // arrange - add a system user to the list stored in GlobalData
            GlobalData.SystemUsers.Add(new SystemUser("test_email", "test_username", "test_password"));
            // arrange - specify a correct username string and an incorrect password string
            string username = "test_username", password = "wrong_password";

            // act - call the user credentials validation service (references GlobalData)
            bool validUser = SystemUserServiceCore.ValidateUserCredentials(username, password);

            // assert - the validation service should have returned false
            Assert.IsFalse(validUser);
        }
    }
}
