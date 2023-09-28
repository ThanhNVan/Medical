using FptUni.BpHospital.Common.DTOs;
using FptUni.BpHospital.HttpClientProviders;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FptUni.BpHospital.BlazorFE.Pages;

public partial class Index
{
    #region [ Properties ]
    [Inject]
    public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public HttpClientContext HttpClientContext { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }   
    #endregion

    #region [ Field ]
    private SignInModel Model = new SignInModel();
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync() { 
        var AuthenticationProvider = (AuthenticationProvider)AuthenticationStateProvider;
        var result = await AuthenticationProvider.GetAuthenticationStateAsync();
        if (result.User.Identity != null && result.User.Identity.IsAuthenticated)
        {
            AuthenticationProvider.UpdateAuthenticationState(result);
            NavigationManager.NavigateTo("/fetchdata");
        }

        await base.OnInitializedAsync();
    }
    #endregion

    #region [ Methods -  ]
    private async Task AuthenticateAsync()
    {
        if (string.IsNullOrEmpty(Model.Email) || string.IsNullOrEmpty(Model.Password))
        {
            await JSRuntime.InvokeVoidAsync("alert", "Not Valid Input");
            return;
        }


        var response = await this.HttpClientContext.Authentication.SignInAsync(Model);
        if (response is null)
        {
            await JSRuntime.InvokeVoidAsync("alert", "Incorrect Email or Password");
            return;
        }

        var AuthenticationProvider = (AuthenticationProvider)AuthenticationStateProvider;
        await AuthenticationProvider.UpdateAuthenticationStateAsync(response);
        NavigationManager.NavigateTo("/fetchdata");
        return;
    }
    #endregion
}
