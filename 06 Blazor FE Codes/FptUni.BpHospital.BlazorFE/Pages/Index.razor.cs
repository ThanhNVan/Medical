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

        var customAuthStateProvider = (AuthenticationProvider)AuthenticationStateProvider;
        await customAuthStateProvider.UpdateAuthenticationStateAsync(response);
        NavigationManager.NavigateTo("/fetchdata", true);
        return;
    }
    #endregion
}
