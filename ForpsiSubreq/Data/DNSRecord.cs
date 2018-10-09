using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForpsiSubreq.Data
{
    public class DNSRecord
    {
        public string Subdomain { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public int TTL { get; set; }

        public DNSRecord(string subdomain, string text, string type, int ttl)
        {
            this.Subdomain = subdomain;
            this.Text = text;
            this.Type = type;
            this.TTL = ttl;
        }
    }
}
