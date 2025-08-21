namespace Client.Services.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient { get => _httpClient; }
    }
}
