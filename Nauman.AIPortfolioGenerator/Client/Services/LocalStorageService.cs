using Client.Contracts;
using Hanssens.Net;

namespace Client.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private LocalStorage _storage;
        public LocalStorageService()
        {
            var config = new LocalStorageConfiguration()
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = "AI.PORTFOLIOGEN"
            };
            _storage = new LocalStorage(config);       
        }
        public void ClearStorage(List<string> keys)
        {
            foreach(var key in keys)
            {
                _storage.Remove(key);
            }
        }

        public bool Exists(string key)
        {
            return _storage.Exists(key);
        }

        public T GetStorageValue<T>(string key)
        {
            try
            {
                return _storage.Get<T>(key);
            }
            catch (ArgumentNullException)
            {
                return default(T);
            }
        }

        public void SetStorageValue<T>(string key, T value)
        {
            _storage.Store(key, value);
            _storage.Persist();
        }
    }
}
