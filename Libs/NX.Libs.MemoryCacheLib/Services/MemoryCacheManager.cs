using NX.Libs.MemoryCacheLib.Interfaces;

namespace NX.Libs.MemoryCacheLib.Services
{
    public class MemoryCacheManager<TValue> : IMemoryCacheManager<TValue>
    {
        private readonly Dictionary<string, List<TValue>> _dictionary;
        private readonly Dictionary<string, Type> _typeMap;

        private readonly Timer _timer;
        public MemoryCacheManager(TimeSpan destroyTime)
        {
            _dictionary = [];
            _typeMap = [];
            _timer = new Timer(DestroyMemoryCache, null, destroyTime, destroyTime);
        }

        public void Add(string key, TValue value)
        {
            if (value == null)
                throw new InvalidOperationException("Value Null Olamaz!");

            Type classType = value.GetType();
            TypeMapControl(key, classType);
            DictHandler(key, value);
        }

        public void AddRange(string key, params TValue[] values)
        {
            if (values == null || values.Length == 0)
                throw new InvalidOperationException("Values Null veya Boş Olamaz!");

            Type? classType = values.First()?.GetType();
            if (classType != null)
            {

                if (!values.All(value => value != null && value.GetType() == classType))
                    throw new InvalidOperationException("Tüm öğeler aynı türde ve null olmamalıdır!");

                TypeMapControl(key, classType);

                foreach (TValue? value in values)
                {
                    if (value == null)
                        throw new InvalidOperationException("Value Null Olamaz!");
                    DictHandler(key, value);
                }
            }
        }

        public IEnumerable<TValue>? Get(string key)
        {
            if (_dictionary.TryGetValue(key, out var list))
                return new List<TValue>(list);
            return null;
        }

        public void Update<T>(string key, Func<T, bool> filter, Action<T> updateAction) where T : TValue
        {
            // Key'e karşılık gelen değerleri al
            if (_dictionary.TryGetValue(key, out List<TValue>? values) && values.Count > 0)
            {
                // values içerisindeki her öğeyi T türüne cast ederek filtreleme işlemi yapar
                foreach (T? item in values.OfType<T>().Where(filter)) // `OfType<T>()` ile T türünde olanları alır
                {
                    // Güncelleme işlemini gerçekleştir
                    updateAction(item);
                }
            }
        }

        public void Remove(string key, Func<TValue, bool> filter)
        {
            if (_dictionary.TryGetValue(key, out var values) && values.Count > 0)
            {
                // Filtreye uymayan öğeleri yeni bir listeye ekle
                var newList = values.Where(t => !filter(t)).ToList();
                _dictionary[key] = newList; // Eski listeyi yeni liste ile güncelle

                // Liste boşsa anahtarı kaldır
                if (newList.Count == 0)
                {
                    Cleaner(key);
                }
            }
        }

        public IEnumerable<TValue>? SafeDelete(string key)
        {
            if (_dictionary.TryGetValue(key, out var values))
            {
                _dictionary.Remove(key);
                _typeMap.Remove(key);
                return values;
            }
            return null;
        }

        public void Delete(string key)
        {
            if (_dictionary.Remove(key))
                _typeMap.Remove(key);
        }

        private void DictHandler(string key, TValue value)
        {
            if (!_dictionary.ContainsKey(key))
            {
                _dictionary[key] = [];
            }
            _dictionary[key].Add(value);
        }

        private void TypeMapControl(string key, Type value)
        {
            if (_typeMap.ContainsKey(key))
            {
                if (_typeMap[key] != value)
                    throw new InvalidOperationException($"Anahtar '{key}' için '{value.Name}' türünden nesneler eklenemez!");
            }
            else
                _typeMap[key] = value; // Yeni türü ekle
        }

        private void Cleaner(string key)
        {
            _dictionary.Remove(key);
            _typeMap.Remove(key);
        }
        private void DestroyMemoryCache(object? state)
        {
            _dictionary.Clear();
            _typeMap.Clear();
            Console.WriteLine("MemoryCacheManager has been cleared.");
        }
    }
}
