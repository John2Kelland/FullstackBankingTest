using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radancy_Bank_Challenge.Models;
using Radancy_Bank_Challenge.Utilities;
using Radancy_Bank_Challenge.Services;

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

        [HttpPut]
        public IActionResult Put([FromBody] string systemUserDetails)
        {
            string[] details = systemUserDetails.Split(",");

            string username = details[0].Split("Username:")[1];
            string password = details[1].Split("Password:")[1];

            if (username.Equals("signoutrequest") && password.Equals("signoutrequest"))
            {
                GlobalData.ActiveSystemUser = "";
                return Ok();
            }

            if (!SystemUserServiceCore.ValidateUserCredentials(username, password))
            {
                return BadRequest(GlobalConstants.ErrorMessages.INVALIDUSERCREDENTIALS);
            }

            // the user has been validated, so set the active system user in global data
            GlobalData.ActiveSystemUser = username;

            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] string systemUserDetails)
        {
            string[] details = systemUserDetails.Split(",");

            string email = details[0].Split("Email:")[1];
            string username = details[1].Split("Username:")[1];
            string password = details[2].Split("Password:")[1];

            if (!SystemUserServiceCore.ValidateSystemUserEmail(email)) { return BadRequest("Please enter a valid email address."); }

            if (SystemUserServiceCore.AddSystemUser(email, username, password))
            {
                return Ok();
            } 
            else
            {
                return BadRequest(GlobalConstants.ErrorMessages.UNEXPECTEDNEWUSERFAILURE);
            }
        }

        [HttpGet]
        public IEnumerable<SystemUser> Get()
        {
            if (GlobalData.SystemUsers == null)
            {
                GlobalData.SystemUsers = new List<SystemUser>();
            }

            return GlobalData.SystemUsers;
        }
    }
}
