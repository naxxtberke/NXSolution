

using NX.Libs.CompressionLib.Interfaces;
using NX.Libs.CompressionLib.Services;
using NX.Libs.CoreLib.Extensions;
using TestConsoleApp.Logger;

bool berke = "true".isTrue();


ILoggerService loggerService = new FileLoggerService("");


loggerService.Log(LogState.Information,DateTime.Now.ToString());



ICompressionService compressionService = new GzipCompressionService();

