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


Exception b = new Exception();




MemoryCacheManager<BaseClass> memoryCacheManager = new(TimeSpan.FromMilliseconds(10));

Sport sport = new()
{
    Id = 0,
    Name = "Tester0",
    Denden = "b"
};
Sport sport1 = new()
{
    Id = 2,
    Name = "12312312",
    Denden = "bb"

};
Sport sport2 = new()
{
    Id = 2,
    Name = "12312312312",
    Denden = "bb"

};

Tourments tourments = new()
{
    Id = 2,
    Surname = "Tester2"
};
memoryCacheManager.AddRange("Sports", sport, sport1, sport2);
memoryCacheManager.Add("Tourments", tourments);

memoryCacheManager.Update<Tourments>("Sports", t => t.Id == 2, t =>
{
    t.Surname = "Berke";
});





Console.ReadKey();


class BaseClass
{
    public int Id { get; set; }
}

class Sport : BaseClass
{
    public string Name { get; set; }
    public string Denden { get; set; }
}

class Tourments : BaseClass
{
    public string Surname { get; set; }
}

