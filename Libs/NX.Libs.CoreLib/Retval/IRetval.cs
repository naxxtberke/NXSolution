namespace NX.Libs.CoreLib.Retval
{
    public interface IRetval
    {
        RetvalStatus Status { get; }
        string? Explanation { get; }
    }
    public interface IRetval<out T> : IRetval
    {
        T? Data { get; }
    }
}
