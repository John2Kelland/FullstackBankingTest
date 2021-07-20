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
    }
}
