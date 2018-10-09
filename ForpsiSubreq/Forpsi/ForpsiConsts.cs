using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForpsiSubreq
{
    static class ForpsiConsts
    {
        const string loginURL = @"https://subreg.forpsi.com/login.php?dip_key=";
        const string domainURL = @"https://subreg.forpsi.com/domains-dns.php?id={0}&prep=1";
        const int defaultTTL = 1800;

        public static string getDomainURL(string id)
        {
            return String.Format(ForpsiConsts.domainURL, id.ToString());
        }

        public static string getLoginURL()
        {
            return ForpsiConsts.loginURL;
        }

        public static int getDefaultTTL()
        {
            return ForpsiConsts.defaultTTL;
        }


    }
}
