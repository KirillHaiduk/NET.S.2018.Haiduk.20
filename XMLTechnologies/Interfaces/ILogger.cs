namespace XMLTechnologies
{
    /// <summary>
    /// Logs process of validating URLs
    /// </summary>
    public interface ILogger
    {
        void Info(string message);

        void Log(string message);

        void Debug(string message);

        void Error(string message);

        void Fatal(string message);
    }
}
