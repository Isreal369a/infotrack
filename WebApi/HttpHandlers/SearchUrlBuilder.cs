using Microsoft.Extensions.Configuration;
using System;

namespace WebApi
{
    public class SearchUrlBuilder : ISearchUrlBuilder
    {
        private readonly IConfiguration configuration;

        public SearchUrlBuilder(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Uri Build(string searchWords)
        {
            string baseAddress =  configuration.GetValue<string>("SearchEngine:BaseAddress");
            string path = configuration.GetValue<string>("SearchEngine:Path");            
            string searchUrl = $"{baseAddress}{path}{searchWords}";
            var url = new Uri(searchUrl);

            return url;
        }
    }
}
