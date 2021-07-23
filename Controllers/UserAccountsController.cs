using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radancy_Bank_Challenge.Models;
using Radancy_Bank_Challenge.Utilities;
using System.Net.Http.Headers;
using Radancy_Bank_Challenge.Services;

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
            if (GlobalData.UserAccounts == null)
            {
                GlobalData.UserAccounts = new List<UserAccount>();
            }

            return GlobalData.UserAccounts.Where(x => x.Username.Equals(GlobalData.ActiveSystemUser));
        }

        [HttpPost]
        public IActionResult Post([FromBody] string userAccountDetails)
        {
            if (String.IsNullOrEmpty(GlobalData.ActiveSystemUser)) { return BadRequest(GlobalConstants.ErrorMessages.UNAUTHORIZEDACTIONATTEMPT); }

            string[] details = userAccountDetails.Split(",");

            string accountId = details[0].Split("AccountID:")[1];
            string accountName = details[1].Split("AccountName:")[1];
            string initialBalance = details[2].Split("InitialBalance:")[1];

            if (String.IsNullOrEmpty(accountId) || String.IsNullOrEmpty(accountName))
            {
                return BadRequest(GlobalConstants.ErrorMessages.REQUIREDFIELDSMISSING);
            }

            if (String.IsNullOrEmpty(initialBalance))
            {
                if (UserAccountServiceCore.AddUserAccount(accountId, accountName, null, out string errorMessage))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(errorMessage);
                }
            }
            else
            {
                if (UserAccountServiceCore.AddUserAccount(accountId, accountName, Convert.ToDouble(initialBalance), out string errorMessage))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(errorMessage);
                }
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] string userAccountDetails)
        {
            if (String.IsNullOrEmpty(GlobalData.ActiveSystemUser)) { return BadRequest(GlobalConstants.ErrorMessages.UNAUTHORIZEDACTIONATTEMPT); }

            string[] details = userAccountDetails.Split(",");

            string accountId = details[0].Split("AccountID:")[1];
            string accountName = details[1].Split("AccountName:")[1];

            if (String.IsNullOrEmpty(accountId)) { return BadRequest(GlobalConstants.ErrorMessages.REQUIREDFIELDSMISSING); }

            if (accountName.Equals("deleterequest")) 
            {
                if (this.Delete(accountId, out string deleteErrorMessage))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(deleteErrorMessage);
                }
            }

            if (String.IsNullOrEmpty(accountName)) { return BadRequest(GlobalConstants.ErrorMessages.REQUIREDFIELDSMISSING); }

            if (UserAccountServiceCore.UpdateUserAccount(accountId, accountName, out string errorMessage))
            {
                return Ok();
            }
            else
            {
                return BadRequest(errorMessage);
            }
        }

        public bool Delete(string accId, out string errorMessage)
        {
            bool deletionSuccessful = false; errorMessage = "";

            if (UserAccountServiceCore.DeleteUserAccount(accId, out string deletionServiceErrorMessage))
            {
                deletionSuccessful = true;
            }
            else
            {
                errorMessage = deletionServiceErrorMessage;
                deletionSuccessful = false;
            }

            return deletionSuccessful;
        }
    }
}
