using Azul.Shared;
using System.Net.Http;
using System.Net.Http.Json;

namespace Azul.Client.Services
{
    public class SystemUserService : ISystemUserService
    {
        private readonly HttpClient _httpClient;
        public SystemUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IList<SystemUser>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IList<SystemUser>>($"api/SystemUser");
        }

        public async Task<HttpResponseMessage> Login(LoginDTO login)
        {
            return await _httpClient.PostAsJsonAsync<LoginDTO>("/api/SystemUser/Login", login);
        }
    }
}
