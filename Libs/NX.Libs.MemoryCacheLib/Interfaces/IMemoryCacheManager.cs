namespace NX.Libs.MemoryCacheLib.Interfaces
{
    public interface IMemoryCacheManager<TValue>
    {
        void Add(string key, TValue value);
        void AddRange(string key, params TValue[] values);
        IEnumerable<TValue>? Get(string key);
        void Update<T>(string key, Func<T, bool> filter, Action<T> updateAction) where T : TValue;
        void Remove(string key, Func<TValue, bool> filter);
        IEnumerable<TValue>? SafeDelete(string key);
        void Delete(string key);
    }
}
