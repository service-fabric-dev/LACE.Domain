namespace LACE.Domain.Model.Monitors.Logger.Abstractions
{
    /// <summary>
    /// Represents a 
    /// </summary>
    interface ILoggerAdapter
    {
        void Info(string message);
        void Warning(string message);
        void Error(string message);
    }
}
