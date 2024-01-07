using StoreServices.Api.ShoppingCart.RemoteInterfaces;
using StoreServices.Api.ShoppingCart.RemoteModels;
using System.Text.Json;

namespace StoreServices.Api.ShoppingCart.RemoteServices
{
    public class BooksService : IBooksService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<BooksService> _logger;

        public BooksService(IHttpClientFactory httpClient, ILogger<BooksService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
            
        public async Task<(bool result, RemoteBookMaterial book, string errorMessage)> GetBook(Guid BookId)
        {
            try
            {
                var client = _httpClient.CreateClient("Books");
                var response = await client.GetAsync($"api/books/{BookId}");
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<RemoteBookMaterial>(content, options);
                    return (true, result, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception exception)
            {
                _logger?.LogError(exception.ToString());
                return (false, null, exception.Message);
            }
        }
    }
}
