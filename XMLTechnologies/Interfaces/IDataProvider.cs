using System.Collections.Generic;

namespace XMLTechnologies.Interfaces
{
    /// <summary>
    /// Provides source of URLs
    /// </summary>
    /// <typeparam name="T">Parameter type of source</typeparam>
    public interface IDataProvider<out T>
    {
        string GetSource { get; }

        IEnumerable<T> GetData();
    }
}
