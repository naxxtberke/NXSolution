

namespace TestConsoleApp.Logger
{
    public class DatabaseLoggerService : ILoggerService
    {
        private readonly string _messageFormat;
        private readonly string _path;
        private readonly bool _addSpaceNewRow;

        public DatabaseLoggerService()
        {
            _messageFormat = "{0},{1},{2}";
            _path = "";
            _addSpaceNewRow = true;
        }

        public void Log(LogState logState, params string[] messages)
        {
            throw new NotImplementedException();
        }

        public Task LogAsync(LogState logState, params string[] messages)
        {
            throw new NotImplementedException();
        }
    }
}
