using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System.Linq;
using System.Collections.Generic;

namespace WebApi
{
    public class AngleSharpHtmlParser : IResultPageParser
    {
        public const string RESULT_LINK_SELECTOR = "div.egMi0 a";

        public IEnumerable<string> Parse(string htmlSource)
        {
            IHtmlParser htmlParser = new HtmlParser();
            var _document = htmlParser.ParseDocument(htmlSource);
            IHtmlCollection<IElement> elems = _document.QuerySelectorAll(RESULT_LINK_SELECTOR);

            List<string> ree = elems.Select(x => x.OuterHtml).ToList();

            return ree;
        }
    }

}
