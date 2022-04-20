using System;
using System.Threading.Tasks;

namespace WebApi
{
    public interface ISearchEngineHttpHandler
    {
        Task<string> Search(Uri searchUrl);
    }
}
