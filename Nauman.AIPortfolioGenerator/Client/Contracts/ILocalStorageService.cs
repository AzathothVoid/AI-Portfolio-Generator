namespace Client.Contracts
{
    public interface ILocalStorageService
    {
        Task SetStorageValueAsync<T>(string key, T value);
        Task<T> GetStorageValueAsync<T>(string key);
        Task<bool> ExistsAsync(string key);
        Task ClearStorageAsync(List<string> keys);
    }
}
