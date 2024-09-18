namespace NX.Libs.CoreLib.Retval
{
    public interface IRetval
    {
        RetvalStatus Status { get; }
        string? Explanation { get; }
        Exception? Exception { get; }

    }
    public interface IRetval<out T> : IRetval
    {
        T? Data { get; }
    }
}
