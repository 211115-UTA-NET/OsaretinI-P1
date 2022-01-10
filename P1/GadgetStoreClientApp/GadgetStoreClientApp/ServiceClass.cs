using System;
using System.Net.Mime;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
namespace GadgetStoreClientApp
{
    public class ServiceClass
    {

        private readonly HttpClient _httpClient = new();

        public ServiceClass(Uri serverUri)
        {
            _httpClient.BaseAddress = serverUri;

        }

        public async Task<string> SubmitMoveAsync(string playerName, string move)
        {
          ///  SubmittedMove theMove = new()
           // {
          //      PlayerName = playerName,
          //      Move = move
         //   };

            HttpRequestMessage request = new(HttpMethod.Post, "/test");
           // request.Content = new StringContent(JsonSerializer.Serialize(theMove),
           //     Encoding.UTF8, MediaTypeNames.Application.Json);

            //could use _httpClient.PostAsync instead, would be a little more succinct

            HttpResponseMessage response = null;
            try
            {
                response = await _httpClient.SendAsync(request);
            }
            catch (HttpRequestException ex)
            {
                //throw new UnexpectedServerBehaviorException("network error", ex);
            }

            var result = await response.Content.ReadFromJsonAsync<string>();
            return result!;
        }
    }
}

