using Blazored.SessionStorage;
using FptUni.BpHospital.Common.DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FptUni.BpHospital.BlazorFE;

public class AuthenticationProvider : AuthenticationStateProvider
{
    #region [ Fields ]
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
    private readonly ISessionStorageService _session;
    private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsPrincipal());
    private readonly ILogger<AuthenticationProvider> _logger;
    #endregion

    #region [ CTor ]
    public AuthenticationProvider(JwtSecurityTokenHandler jwtSecurityTokenHandler,
                                    ISessionStorageService session,
                                  ILogger<AuthenticationProvider> logger)
    {
        this._jwtSecurityTokenHandler = jwtSecurityTokenHandler;
        this._session = session;
        this._logger = logger;
    }
    #endregion

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var userSession = await _session.GetItemAsync<UserSession>("UserSession");
            if (userSession == null)
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }

            var savedToken = userSession.AccessToken;
            var tokenContent = this._jwtSecurityTokenHandler.ReadJwtToken(savedToken);
            var user = new ClaimsPrincipal(new ClaimsIdentity(tokenContent.Claims, "Jwt"));

            return await Task.FromResult(new AuthenticationState(user));
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return await Task.FromResult(new AuthenticationState(_anonymous));
        }
    }

    public async Task UpdateAuthenticationState(UserSession? userSession)
    {
        var claimsPrincipal = default(ClaimsPrincipal);

        if (userSession != null) // sign in 
        {
            var savedToken = userSession.AccessToken;
            var tokenContent = this._jwtSecurityTokenHandler.ReadJwtToken(savedToken);

            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(tokenContent.Claims));

            userSession.ExpiryTimeStamp = DateTime.UtcNow.AddSeconds(userSession.ExpriesIn);

            await _session.SetItemAsync("UserSession", userSession);
        } else
        { // sign out
            claimsPrincipal = _anonymous;
            await _session.RemoveItemAsync("UserSession");
        }

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }

    public async Task<string> GetToken()
    {
        var result = string.Empty;

        try
        {
            var userSession = await _session.GetItemAsync<UserSession>(nameof(UserSession));
            if (userSession != null && DateTime.UtcNow < userSession.ExpiryTimeStamp)
            {
                result = userSession.AccessToken;
            }

            return result;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            throw;
        }
    }
}
