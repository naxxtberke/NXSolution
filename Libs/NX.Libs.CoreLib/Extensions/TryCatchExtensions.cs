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
                (customErrorHandler ?? DefaultErrorHandler)(ex);
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
                (customErrorHandler ?? DefaultErrorHandler)(ex);
                return default;
            }
        }
        private static void DefaultErrorHandler(Exception ex)
        {
            // Varsayılan hata işleme işlemleri (loglama, uyarı vb.)
            Console.WriteLine($"Hata oluştu: {ex.Message}");
        }
    }
}
