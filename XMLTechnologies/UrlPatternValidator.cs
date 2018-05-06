using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using XMLTechnologies.Interfaces;

namespace XMLTechnologies
{
    public class UrlPatternValidator<TSource, TResult> : IValidator<TSource, TResult>
    {
        private ILogger logger;

        public UrlPatternValidator(ILogger logger)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            this.logger = logger;
        }

        public IEnumerable<TResult> ValidUrls(IEnumerable<TSource> urls)
        {
            foreach (var url in urls)
            {
                if (IsMatchUrlPattern((dynamic)url))
                {
                    yield return (dynamic)url;
                }
                else
                {
                    logger.Error("Wrong string.");
                    logger.Log($"String {url} is not match the URL pattern");
                    continue;
                }
            }
        }

        public bool IsMatchUrlPattern(TSource input)
        {
            Regex regex = new Regex(@"(http://|https://)", RegexOptions.IgnoreCase);
            if (!regex.IsMatch((dynamic)input))
            {
                return false;
            }

            return true;
        }
    }
}
