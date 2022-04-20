using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace WebApi
{

    public class ResultPageCounter : IResultPageCounter
    {
        readonly IResultPageParser _resultPageParser;

        public ResultPageCounter(IResultPageParser resultPageParser)
        {
            _resultPageParser = resultPageParser;
        }

        public string CountUrlOccurence(string htmlSource, string url)
        {
            if (string.IsNullOrEmpty(htmlSource)) throw new ArgumentNullException(nameof(htmlSource));
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException(nameof(url));

            IEnumerable<string> htmls = _resultPageParser.Parse(htmlSource);

            int count = 0;
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < htmls.Count(); i++)
            {
                count++;
                if (htmls.ElementAt(i) != null && htmls.ElementAt(i).Contains(url))
                {
                    if (result.Length > 0)
                    {

                        result.Append(',');
                    }
                    result.Append(count);
                }

            }

            if(result.Length == 0) { result.Append("0"); }
            return result.ToString();
        }
    }

}
