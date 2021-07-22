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
    public class TransactionsController : ControllerBase
    {
        private readonly ILogger<TransactionsController> _logger;

        public TransactionsController(ILogger<TransactionsController> logger)
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

        [HttpPut]
        public IActionResult Put([FromBody] string transactionDetails)
        {
            if (String.IsNullOrEmpty(GlobalData.ActiveSystemUser)) { return BadRequest(GlobalConstants.ErrorMessages.UNAUTHORIZEDACTIONATTEMPT); }

            string[] details = transactionDetails.Split(",");

            string accountId = details[0].Split("AccountID:")[1];
            double transactionAmount = Convert.ToDouble(details[1].Split("TransactionAmount:")[1]);
            string transactionType = details[2].Split("TransactionType:")[1];

            if (transactionType.Equals("withdrawal"))
            {
                if (TransactionsServiceCore.ProcessWithdrawal(accountId, transactionAmount, out string errorMessage))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(errorMessage);
                }
            } 
            else if (transactionType.Equals("deposit"))
            {
                if (TransactionsServiceCore.ProcessDeposit(accountId, transactionAmount, out string errorMessage))
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
                return BadRequest(GlobalConstants.ErrorMessages.UNRECOGNIZEDTRANSACTIONTYPE);
            }
        }
    }
}
