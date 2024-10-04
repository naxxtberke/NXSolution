namespace NX.Libs.CoreLib.Helper
{
    public static class FilterHelper
    {
        public static bool Filter<TSource>(TSource source, Func<TSource, bool> func) => func(source);
        public static bool Filter<TSource>(TSource source, params Func<TSource, bool>[] conditions)
        {
            foreach (Func<TSource, bool> condition in conditions)
            {
                if (!condition(source))
                    return false;
            }
            return true;
        }
        public static bool Filter<TSource>(TSource source, out Func<TSource, bool>? failedCondition, params Func<TSource, bool>[] conditions)
        {
            failedCondition = null;

            foreach (Func<TSource, bool> condition in conditions)
            {
                if (!condition(source))
                {
                    failedCondition = condition;
                    return false;
                }
            }
            return true;
        }
        public static bool Filter<TSource>(TSource source, List<Func<TSource, bool>> conditions) => conditions.All(condition => condition(source));
    }
}
