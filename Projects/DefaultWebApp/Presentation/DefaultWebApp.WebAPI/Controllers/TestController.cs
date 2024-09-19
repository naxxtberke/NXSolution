using Microsoft.AspNetCore.Mvc;
using NX.Libs.CoreLib.Extensions;
using NX.Libs.CoreLib.Retval;

namespace DefaultWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpPost]
        public IActionResult Test()
        {
            TestMethod();
            IRetval retval = getRetval(false, false);
            if (retval.Status == RetvalStatus.Success)
            {
                return Ok();
            }
            else
                return BadRequest();
        }

        private IRetval getRetval(bool throwException, bool log)
        {
            IRetval<int> retval = Berke(() =>
            {
                int a = 0; int b = 1;
                int toplam = a + b;
                return toplam;
            }
            , new Options() { ThrowException = false, Log = false }
            , () => Console.WriteLine("Loglandı"));

            return retval;

            //try
            //{
            //    int a = 0; int b = 1;
            //    int toplam = a + b;

            //    retval.Data = toplam;
            //    return retval;
            //}
            //catch (Exception ex)
            //{
            //    if (log) Console.WriteLine("Loglandı");
            //    if (throwException) throw;

            //    retval.Exception = ex;
            //    retval.Status = RetvalStatus.Exception;
            //    return retval;
            //}
        }

        private void TestMethod()
        {
            var test = Berke(() =>
            {
                int a = 0; int b = 1;
                int toplam = a + b;
                throw new NotImplementedException("Ahh hataa");
                return toplam;

            }, new Options() { Log = true, ThrowException = false }, () => LoggerMethod("Hello Hello"));
        }

        private void LoggerMethod(string mesaj)
        {
            Console.WriteLine($"{mesaj} , Loglandı");
        }

        private IRetval<T> Berke<T>(Func<T> func, Options opt, Action logAction)
        {
            Retval<T> retval = new();
            try
            {
                retval.Data = func();
                return retval;
            }
            catch (Exception ex)
            {
                if (opt.Log) logAction();
                if (opt.ThrowException) throw;

                retval.Exception = ex;
                retval.Status = RetvalStatus.Exception;
                return retval;
            }

        }
        private class Options
        {
            public bool ThrowException { get; set; }
            public bool Log { get; set; }
        }
    }
}
