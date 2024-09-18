namespace NX.Libs.CoreLib.Extensions
{
    public class TryCatchExtensions
    {
        public static void Execute(Action action, Action<Exception>? customErrorHandler = null)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                customErrorHandler(ex);
            }
        }
        public static T? Execute<T>(Func<T> func, Action<Exception>? customErrorHandler = null)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                customErrorHandler(ex);
                return default;
            }
        }
        public class Options
        {
            public bool ThrowException { get; set; }
        }
    }
}
