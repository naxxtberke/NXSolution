namespace TestConsoleApp.Logger
{
    public enum LogState
    {
        Success,
        Information,
        Warning,
        Error,
        Exception,
    }
    public interface ILoggerService
    {
        public void Log(LogState logState, params string[] messages);
        public Task LogAsync(LogState logState, params string[] messages);
    }
}
