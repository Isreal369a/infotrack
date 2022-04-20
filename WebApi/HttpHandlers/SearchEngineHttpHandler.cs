using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApi
{
    public class SearchEngineHttpHandler : ISearchEngineHttpHandler
    {        
        private readonly HttpClient HttpClient;

        private readonly ILogger<SearchEngineHttpHandler> _logger;
        private readonly IConfiguration _configuration;

        public SearchEngineHttpHandler(HttpClient httpClient, ILogger<SearchEngineHttpHandler> logger, IConfiguration configuration)
        {
            HttpClient = httpClient;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<string> Search(Uri searchUrl)
        {
            string result = string.Empty;
            try
            {
                var message = new HttpRequestMessage();
                message.Method = HttpMethod.Get;
                message.RequestUri = searchUrl;

                if (!string.IsNullOrEmpty(_configuration.GetValue<string>("SearchEngine:Cookie")))
                {
                    message.Headers.Add("Cookie", _configuration.GetValue<string>("SearchEngine:Cookie"));
                }
                
                HttpResponseMessage responseMessage = await HttpClient.SendAsync(message);
                responseMessage.EnsureSuccessStatusCode();
                result = await responseMessage.Content.ReadAsStringAsync();
                
            }
            catch (Exception ex)
            {
                _logger.LogError("Error calling search engine", ex.Message);
            }
            

            return result;

        }

    }
}
