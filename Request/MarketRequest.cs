using System;
using System.Collections.Generic;
using System.Text;

namespace IEX
{
    public class MarketBatchRequest : IEXRequest
    {
        public const string endpoint = "market/batch?{0}{1}{2}{3}";
        public List<string> Symbols;
        public List<string> Types;
        public List<string> Options;
        public string Range;
        public MarketBatchRequest()
        {
            Types = new List<string>();
            Symbols = new List<string>();
            Options = new List<string>();
            Range = "";
        }

        public override string GetEndpoint()
        {
            string symbols = string.Join(ArgumentSeparator, Symbols);
            string types = "&" + string.Join(ArgumentSeparator, Types);
            string range = (Range.Length == 0 ? string.Empty : "&" + "range=" + Range);
            string opts = (Options.Count == 0 ? string.Empty : "&" + string.Join("&", Options));

            return String.Format(endpoint,symbols,types,range,opts);
        }

        public override Type GetResponseType()
        {
            
            return typeof(MarketBatchResponse);
        }
    }
}
