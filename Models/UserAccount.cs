using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radancy_Bank_Challenge.Models
{
    public class UserAccount
    {
        #region Constructors

        // constructor overloading - set initial balance as 100 if a value is not provided
        public UserAccount(string username, int accountId, string accountName)
        {
            this.Username = username;
            this.AccountId = accountId;
            this.AccountName = accountName;
            this.Balance = 100;
        }

        // constructor overloading - accept the initial balance input if a value is provided
        public UserAccount(string username, int accountId, string accountName, double balance)
        {
            this.Username = username;
            this.AccountId = accountId;
            this.AccountName = accountName;
            this.Balance = balance;
        }

        #endregion

        #region Properties

        public string Username { get; set; }

        public int AccountId { get; set; }

        public string AccountName { get; set; }

        public double Balance { get; set; }

        #endregion
    }
}
