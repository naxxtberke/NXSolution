
namespace TestConsoleApp.Logger
{
    public class FileLoggerService : ILoggerService
    {
        private readonly string _messageFormat;
        private readonly string _path;
        private readonly bool _addSpaceNewRow;

        public FileLoggerService(string path, string messageFormat = "{0},{1},{2}", bool addSpaceNewRow = true)
        {
            _path = path;
            _messageFormat = messageFormat ?? "{0},{1},{2}";
            _addSpaceNewRow = addSpaceNewRow;
        }

        public void Log(LogState logState, params string[] messages)
        {
            using StreamWriter writer = new(_path, true);
            if (_addSpaceNewRow) writer.WriteLine(string.Empty);
            writer.WriteLine(string.Format(_messageFormat, messages));
        }

        public async Task LogAsync(LogState logState, params string[] messages)
        {
            using StreamWriter writer = new(_path, true);
            if (_addSpaceNewRow) await writer.WriteLineAsync(string.Empty);
            await writer.WriteLineAsync(string.Format(_messageFormat, messages));
        }
    }
}
