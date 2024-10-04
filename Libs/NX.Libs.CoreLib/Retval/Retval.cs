
namespace NX.Libs.CoreLib.Retval
{
    public class Retval : IRetval
    {
        public RetvalStatus Status { get; set; } = RetvalStatus.Success;
        public string? Explanation { get; set; } = null;
        public CustomException? Exception { get; set; } = null;

        public Retval() { }
        public Retval(RetvalStatus status, string? explanation = null)
        {
            Status = status;
            Explanation = explanation;
        }
        public Retval(Exception exception, string? explanation = null)
        {
            Status = RetvalStatus.Exception;
            Explanation = explanation;
            Exception = new(exception);
        }
    }

    public class Retval<T> : Retval, IRetval<T>
    {
        public T? Data { get; set; } = default;

        public Retval() { }
        public Retval(T data, string? explanation = null) : base(RetvalStatus.Success, explanation) { Data = data; }
        public Retval(RetvalStatus status, T? data, string? explanation = null) : base(status, explanation) { Data = data; }
        public Retval(Exception exception, T? data, string? explanation = null) : base(exception, explanation) { Data = data; }
    }

    public class CustomException
    {
        public string? Message { get; set; } = null;
        public string? StackTrace { get; set; } = null;

        public CustomException(Exception ex)
        {
            Message = ex.Message;
            StackTrace = ex.StackTrace;
        }
    }
}
