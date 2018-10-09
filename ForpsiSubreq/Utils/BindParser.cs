using ForpsiSubreq.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ForpsiSubreq.Utils
{
    static class BindParser
    {

        public static bool isAllowedType(string type)
        {
            switch (type.ToUpper())
            {
                case "TXT":
                case "A":
                case "CNAME":
                    return true;
                default:
                    return false;
            }
        }

        public static DNSRecord ParseLine(string line)
        {
            var parts = Regex.Matches(line, @"[\""].+?[\""]|[^ ]+")
                            .Cast<Match>()
                            .Select(m => m.Value)
                            .ToList();

            string subdomain;
            string type;
            string text;
            int ttl;
            TTLParser ttlParser = new TTLParser();

            //i.e.: "wiky            IN A            212.80.80.8"
            if ((parts.Count == 4) && ((string)parts[1].ToUpper() == "IN"))
            {
                subdomain = (string)parts[0];
                type = (string)parts[2];
                text = (string)parts[3];
                ttl = ForpsiConsts.getDefaultTTL();
            }
            //i.e.:"nospam3         30M     IN A            212.80.80.119y"
            else
                if ((parts.Count == 5) && ((string)parts[2].ToUpper() == "IN"))
                {
                    subdomain = (string)parts[0];
                    ttl = ttlParser.parse((string)parts[1]);
                    type = (string)parts[3];
                    text = (string)parts[4];
                }
                else  throw new Exception("Chyba"); 

            string[] allowedTypes = { "A", "CNAME", "TXT"};

            //if not in allowed tyes
            if (! BindParser.isAllowedType(type))
            {
                throw new Exception("Chyba");
            }

            if (subdomain[subdomain.Length-1] == '.')
            {
                throw new Exception("Chyba");
            }

            if ((type.ToUpper() == "TXT") && (text[0] == '\"'))
            {
                text = text.Substring(1, text.Length - 2);
            }

            return new DNSRecord(subdomain, text, type, ttl);
        }
    }
}
