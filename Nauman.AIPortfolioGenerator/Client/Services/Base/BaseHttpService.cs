using Client.Contracts;
using Hanssens.Net;

namespace Client.Services.Base
{
    public class BaseHttpService
    {
        protected IClient _client;
        protected readonly ILocalStorageService _localStorage;

        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException apiException)
        {
            if (apiException.StatusCode == 400)
            {
                return new Response<Guid>()
                {
                    Message = "Validation errors have occurred.",
                    ValidationErrors = apiException.Response,
                    Success = false
                };
            }
            else if (apiException.StatusCode == 404)
            {
                return new Response<Guid>()
                {
                    Message = "The requested item could not be found.",
                    Success = false
                };
            }
            else
            {
                return new Response<Guid>()
                {
                    Message = "Something went wrong, please try again.",
                    Success = false
                };
            }
        }

        protected void AddBearerToken()
        {
            var token = _localStorage.GetStorageValue<string>("token");
            if (!string.IsNullOrEmpty(token))
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
