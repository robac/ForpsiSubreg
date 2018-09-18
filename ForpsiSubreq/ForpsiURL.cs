using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForpsiSubreq
{
    static class ForpsiURL
    {
        const string loginURL = @"https://subreg.forpsi.com/login.php?dip_key=";
        const string domainURL = @"https://subreg.forpsi.com/domains-dns.php?id={0}&prep=0";

        public static string getDomainURL(string id)
        {
            return String.Format(ForpsiURL.domainURL, id.ToString());
        }

        public static string getLoginURL()
        {
            return ForpsiURL.loginURL;
        }
    }
}
