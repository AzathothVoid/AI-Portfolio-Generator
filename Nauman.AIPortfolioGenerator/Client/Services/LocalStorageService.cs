using Microsoft.JSInterop;
using System.Text.Json;
using Client.Contracts;

namespace Client.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private readonly IJSRuntime _js;

        public LocalStorageService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task SetStorageValueAsync<T>(string key, T value)
        {
            await _js.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(value));
        }

        public async Task<T> GetStorageValueAsync<T>(string key)
        {
            var json = await _js.InvokeAsync<string>("localStorage.getItem", key);
            return json == null ? default : JsonSerializer.Deserialize<T>(json);
        }

        public async Task<bool> ExistsAsync(string key)
        {
            var value = await _js.InvokeAsync<string>("localStorage.getItem", key);
            return value != null;
        }

        public async Task ClearStorageAsync(List<string> keys)
        {
            foreach (var key in keys)
            {
                await _js.InvokeVoidAsync("localStorage.removeItem", key);
            }
        }
    }
}
