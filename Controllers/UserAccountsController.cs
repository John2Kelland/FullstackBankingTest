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
            double initialBalance = Convert.ToDouble(details[2].Split("InitialBalance:")[1]);

            // check for a unique account ID and valid initial balance
            if (!UserAccountServiceCore.ValidateUniqueAccountID(accountId)) { return BadRequest(GlobalConstants.ErrorMessages.DUPLICATEACCOUNTID); }
            if (!UserAccountServiceCore.ValidateSufficientBalance(initialBalance)) { return BadRequest(GlobalConstants.ErrorMessages.INSUFFICIENTACCOUNTBALANCE); }

            if (UserAccountServiceCore.AddUserAccount(accountId, accountName, initialBalance))
            {
                return Ok();
            }
            else
            {
                return BadRequest(GlobalConstants.ErrorMessages.UNEXPECTEDNEWACCOUNTFAILURE);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] string userAccountDetails)
        {
            if (String.IsNullOrEmpty(GlobalData.ActiveSystemUser)) { return BadRequest(GlobalConstants.ErrorMessages.UNAUTHORIZEDACTIONATTEMPT); }

            string[] details = userAccountDetails.Split(",");

            string accountId = details[0].Split("AccountID:")[1];
            string accountName = details[1].Split("AccountName:")[1];

            if (UserAccountServiceCore.UpdateUserAccount(accountId, accountName))
            {
                return Ok();
            }
            else
            {
                return BadRequest(GlobalConstants.ErrorMessages.UNEXPECTEDACCOUNTUPDATEFAILURE);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] HttpHeaders httpHeaders)
        {
            if (String.IsNullOrEmpty(GlobalData.ActiveSystemUser)) { return BadRequest(GlobalConstants.ErrorMessages.UNAUTHORIZEDACTIONATTEMPT); }

            if (UserAccountServiceCore.DeleteUserAccount("teststring"))
            {
                return Ok();
            }
            else
            {
                return BadRequest(GlobalConstants.ErrorMessages.UNEXPECTEDACCOUNTDELETIONFAIlURE);
            }
        }
    }
}
