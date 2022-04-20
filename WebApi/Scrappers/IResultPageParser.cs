using System.Collections.Generic;

namespace WebApi
{
    public interface IResultPageParser
    {
        IEnumerable<string> Parse(string htmlSource);
    }
}