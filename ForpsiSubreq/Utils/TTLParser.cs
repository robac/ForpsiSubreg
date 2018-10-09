using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForpsiSubreq
{
    public class TTLParser
    {
        public static readonly char[] units = { 'm', 'h', 'd', 'w' };
        IDictionary<char, int> unitsToSeconds = new Dictionary<char, int>();

        public TTLParser()
        {
            unitsToSeconds['m'] = 60;
            unitsToSeconds['h'] = 60*60;
            unitsToSeconds['d'] = 60*60*24;
            unitsToSeconds['w'] = 60*60*24*7;
        }

        private int parseInt(string value, string originalValue)
        {
            int result;
            if ( ! Int32.TryParse(value, out result))
            {
                throw new Exception("Invalid TTL value: " + originalValue);
            }
            else
            {
                if (result < 1)
                {
                    throw new Exception("Invalid TTL value: " + originalValue);
                }
            }

            return result;
        }

        public int parse(string value)
        {
            value = value.Trim();
            if (value.Length == 0)
                throw new Exception("Invalid TTL value: " + value);

            Char last = value[value.Length - 1];

            if ( ! char.IsDigit(last))
            {
                last = char.ToLower(last);
                if (Array.IndexOf(TTLParser.units, last) == -1)
                {
                    throw new Exception("Invalid TTL value: " + value);
                }
                else
                {
                    return this.parseInt(value.Substring(0, value.Length - 1), value) * unitsToSeconds[last];
                }
            }
            else
            {
                return this.parseInt(value, value);
            }
        }
    }
}
