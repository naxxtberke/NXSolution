using NX.Libs.CompressionLib.Interfaces;
using NX.Libs.CompressionLib.Services;
using NX.Libs.CoreLib.Extensions;
using NX.Libs.CoreLib.Helper;
using NX.Libs.MemoryCacheLib.Services;
using System.Text;

bool berke = "true".IsTrue();


//ILoggerService loggerService = new FileLoggerService("");


//loggerService.Log(LogState.Information, DateTime.Now.ToString());



ICompressionService compressionService = new GzipCompressionService();


Encoding enc = Encoding.UTF8;
byte[] hello = compressionService.Compress(ByteExtensions.GetByteArray("Hello World", enc));

Console.WriteLine(string.Join(' ', hello));


Console.WriteLine(StringExtensions.GetByteToString(compressionService.Decompress(hello), enc));


Console.WriteLine(FilterHelper.Filter("berke", t => t.Length >= 5 || t.StartsWith("")));


Console.ReadKey();


