using Azul.Shared;

namespace Azul.Client.Services
{
    public interface ISystemUserService
    {
        public Task<IList<SystemUser>> GetAll();
        public Task<HttpResponseMessage> Login(LoginDTO login);
    }
}
