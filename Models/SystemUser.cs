using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radancy_Bank_Challenge.Models
{
    public class SystemUser
    {
        #region Constructor

        public SystemUser(string username, string password, string email)
        {
            this.Username = username;
            this.Password = password;
            this.Email = email;
        }

        #endregion

        #region Properties

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        #endregion
    }
}
