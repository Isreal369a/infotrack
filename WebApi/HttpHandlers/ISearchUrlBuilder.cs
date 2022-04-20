using System;

namespace WebApi
{
    public interface ISearchUrlBuilder
    {
        Uri Build(string searchWords);
    }
}