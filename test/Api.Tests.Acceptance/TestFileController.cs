
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Api.Tests.Acceptance
{
    public class TestFileController
    {
        private const string _processFile = "/api/File/";
        private readonly WebApplicationFactory<Program> _api;
        private readonly HttpClient _httpClient;

        public TestFileController()
        {
             _api = new WebApplicationFactory<Program>();
            _httpClient = _api.CreateClient();
        }

        [Fact]
        public async void ProcessFileSuccess()
        {
            string filePath = "C:/Users/thiago.borba/Documents/Files/File.txt";

            File.WriteAllText(filePath, "text");

            var stringContent = new StringContent(JsonSerializer.Serialize(filePath), Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync(_processFile, stringContent, new CancellationToken(canceled: false));
            
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async void ProcessFileError()
        {
            var stringContent = new StringContent(JsonSerializer.Serialize("path"), Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync(_processFile, stringContent);
            
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }
    }
}