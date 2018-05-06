using System.Collections.Generic;

namespace XMLTechnologies.Interfaces
{
    /// <summary>
    /// Validates accepted source of URLs for matching pattern
    /// </summary>
    /// <typeparam name="T">Parameter type</typeparam>
    public interface IValidator<TSource, TResult>
    {
        IEnumerable<TResult> ValidUrls(IEnumerable<TSource> urls);

        bool IsMatchUrlPattern(TSource input);
    }
}
