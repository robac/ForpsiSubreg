using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ForpsiSubreq
{
    public class ForpsiRequest
    {
        private string username;
        private string password;
        public bool logged = false;

        private HttpClientHandler handler;
        private readonly HttpClient client;

        public ForpsiRequest(string username, string password)
        {
            this.username = username;
            this.password = password;

            this.handler = new HttpClientHandler();
            this.client = new HttpClient(this.handler);
        }


        public async Task<string> PerformLogin()
        {
            var values = new Dictionary<string, string>
            {
               { "filled", "1"},
               { "login", this.username },
               { "password", this.password },
               { "x",  "60" },
               { "y", "14"  }
            };

            var content = new FormUrlEncodedContent(values);
            var response = await this.client.PostAsync(ForpsiConsts.getLoginURL(), content).ConfigureAwait(false);
            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (responseString.Contains("ARISTIA, spol. s r.o."))
                this.logged = true;
            else
                this.logged = false;

            return responseString;
        }

        public async Task<string> AddDomainRecord(string domainID, string name, string value)
        {
            if (!this.logged)
                return "chyba";

            var values = new Dictionary<string, string>
            {
                { "ak", "record_add" },
                { "name", name },
                { "type", "A" },
                { "rdata", value},
                { "ttl", "1800"}
            };

            var content = new FormUrlEncodedContent(values);
            var response = await this.client.PostAsync(ForpsiConsts.getDomainURL(domainID), content).ConfigureAwait(false);
            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return responseString;
        }

    }
}
