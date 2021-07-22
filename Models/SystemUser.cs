using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radancy_Bank_Challenge.Models
{
    public class SystemUser
    {
        #region Constructor

        public SystemUser(string email, string username, string password)
        {
            this.Email = email;
            this.Username = username;
            this.Password = password;
        }

        #endregion

        #region Properties

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        #endregion
    }
}
