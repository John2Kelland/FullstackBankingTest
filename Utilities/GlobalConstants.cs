using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radancy_Bank_Challenge.Utilities
{
    public class GlobalConstants
    {
        public static int MinimumAccountBalance {
            get {
                return 100;
            }
        }

        public static double MaximumWithdrawalPercentage
        {
            get
            {
                return 0.9;
            }
        }

        public static int MaximumDeposit
        {
            get
            {
                return 10000;
            }
        }

        public class ErrorMessages
        {
            public static string UNEXPECTEDNEWUSERFAILURE { get { return "An unexpected exception has occurred. The new user could not be added to the system."; } }
            public static string UNEXPECTEDNEWACCOUNTFAILURE { get { return "An unexpected exception has occurred. The new account could not be added."; } }
            public static string UNEXPECTEDACCOUNTUPDATEFAILURE { get { return "An unexpected exception has occurred. The account could not be updated."; } }
            public static string UNEXPECTEDACCOUNTDELETIONFAIlURE { get { return "An unexpected exception has occurred. The account could not be deleted."; } }
            public static string INVALIDUSERCREDENTIALS   { get { return "The provided credentials were not recognized. Please ensure you are using the correct username and password!"; } }
            public static string UNAUTHORIZEDACTIONATTEMPT { get { return "Please sign in to your profile before attempting that action. Thank you!"; } }
            public static string INVALIDEMAILFORMAT { get { return "Please verify the format of your email. Thank you!"; } }
            public static string DUPLICATEACCOUNTID { get { return "Please ensure that all accounts have unique ID numbers. Thank you!"; } }
            public static string INSUFFICIENTACCOUNTBALANCE { get { return "Accounts must maintain a balance of at least $100."; } }
        }
    }
}
