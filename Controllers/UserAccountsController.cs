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
    public class UserAccountsController : ControllerBase
    {
        private readonly ILogger<UserAccountsController> _logger;

        public UserAccountsController(ILogger<UserAccountsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<UserAccount> Get()
        {
            List<UserAccount> userAccounts = new List<UserAccount>();
            userAccounts.Add(new UserAccount("John2K", 1002347991, "Sample Account", 2000));

            // figure out how to handle zero user accounts
            // UserAccount[] filteredUserAccounts = GlobalData.UserAccounts.Where(x => x.Username.Equals(GlobalData.ActiveSystemUser)).ToArray() ?? new UserAccount[1];

            return userAccounts;
        }

        [HttpPost]
        public IActionResult Post([FromBody] string userAccountDetails)
        {

            GlobalData.UserAccounts.Add(new UserAccount("John2K", 83742983, "Test Account"));

            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] string userAccountDetails)
        {
            // update a record

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] string userAccountDetails)
        {
            // delete a record

            return Ok();
        }
    }
}
