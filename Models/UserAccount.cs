using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radancy_Bank_Challenge.Models
{
    public class UserAccount
    {
        public UserAccount(string username, int accountId, string accountName)
        {
            this.Username = username;
            this.AccountId = accountId;
            this.AccountName = accountName;
            this.Balance = 100;
        }

        public UserAccount(string username, int accountId, string accountName, double balance)
        {
            this.Username = username;
            this.AccountId = accountId;
            this.AccountName = accountName;
            this.Balance = balance;
        }

        public string Username { get; set; }

        public int AccountId { get; set; }

        public string AccountName { get; set; }

        public double Balance { get; set; }
    }
}
