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
            public static string UNEXPECTEDNEWUSERFAILURE { get { return "An unexpected exception has occurred. The new user could not be added to the system"; } }
            public static string INVALIDUSERCREDENTIALS   { get { return "The provided credentials were not recognized. Please ensure you are using the correct username and password!"; } }
        }
    }
}
