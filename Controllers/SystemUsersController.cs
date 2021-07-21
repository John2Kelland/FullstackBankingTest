using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radancy_Bank_Challenge.Models;
using Radancy_Bank_Challenge.Utilities;

namespace Radancy_Bank_Challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemUsersController : ControllerBase
    {
        private readonly ILogger<SystemUsersController> _logger;

        public SystemUsersController(ILogger<SystemUsersController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] string systemUserDetails)
        {
            string[] details = systemUserDetails.Split(",");

            string email = details[0].Split("Email:")[1];
            string username = details[1].Split("Username:")[1];
            string password = details[2].Split("Password:")[1];

            if (email == "") { return BadRequest("Please enter a valid email address."); }

            SystemUser newSystemUser = new SystemUser(email, username, password);

            // add a record
            if (GlobalData.SystemUsers != null)
            {
                GlobalData.SystemUsers.Add(newSystemUser);
            }
            else
            {
                List<SystemUser> systemUsers = new List<SystemUser>() { newSystemUser };
                GlobalData.SystemUsers = systemUsers;
            }

            return Ok();
        }

        [HttpGet]
        public IEnumerable<SystemUser> Get()
        {
            List<SystemUser> systemUsers = new List<SystemUser>();
            systemUsers.Add(new SystemUser("John2K", "PasswordTest", "testemail@testemailaddress.com"));

            // figure out how to handle zero system users
            // UserAccount[] filteredSystemUsers = GlobalData.UserAccounts.Where(x => x.Username.Equals(GlobalData.ActiveSystemUser)).ToArray() ?? new UserAccount[1];

            return systemUsers;
        }
    }
}
