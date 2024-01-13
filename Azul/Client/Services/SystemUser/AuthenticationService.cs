using Azul.Shared;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Azul.Client.Services
{
    public class AuthenticationService : AuthenticationStateProvider
    {

        private readonly ISessionStorageService _sessionStorageService;
        private ClaimsPrincipal _sinInformacion = new ClaimsPrincipal(new ClaimsIdentity());

        public AuthenticationService(ISessionStorageService sessionStorageService)
        {
            _sessionStorageService = sessionStorageService;
        }

        public async Task ActualizarEstadoAutenticacion(SystemUser? sesionUsuario)
        {
            ClaimsPrincipal claimsPrincipal;
            if (sesionUsuario != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, sesionUsuario.Username),
                    new Claim(ClaimTypes.Email, sesionUsuario.Email),
                    new Claim(ClaimTypes.Role, sesionUsuario.Role)
                }, "JwtAuth"));

                await _sessionStorageService.SaveStorage("sesionUsuario", sesionUsuario);
            }
            else
            {
                claimsPrincipal = _sinInformacion;
                await _sessionStorageService.RemoveItemAsync("sesionUsuario");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sesionUsuario = await _sessionStorageService.GetStorage<SystemUser>("sesionUsuario");
            if (sesionUsuario == null)
            {
                return await Task.FromResult(new AuthenticationState(_sinInformacion));
            }

            var claimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, sesionUsuario.Username),
                    new Claim(ClaimTypes.Email, sesionUsuario.Email),
                    new Claim(ClaimTypes.Role, sesionUsuario.Role)
                }, "JwtAuth"));
            return await Task.FromResult(new AuthenticationState(claimPrincipal));
        }
    }
}
