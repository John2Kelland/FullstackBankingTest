using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radancy_Bank_Challenge.Models;

namespace Radancy_Bank_Challenge.Utilities
{
    public class GlobalData
    {
        public static List<SystemUser> SystemUsers { get; set; }

        public static List<UserAccount> UserAccounts { get; set; }

        public static string ActiveSystemUser { get; set; }
    }
}
