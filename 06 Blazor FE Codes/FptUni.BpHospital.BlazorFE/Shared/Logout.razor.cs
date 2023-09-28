using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace FptUni.BpHospital.BlazorFE.Shared;

public partial class Logout
{
    #region [ Properties - Inject ]
    [Inject]
    public AuthenticationStateProvider AuthenticationProvider { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync()
    {
        await this.LogoutAsync();
    }
    #endregion

    #region [ Methods -  ]
    private async Task LogoutAsync()
    {
        var AuthenticationProvider = (AuthenticationProvider)this.AuthenticationProvider;
        await AuthenticationProvider.UpdateAuthenticationStateAsync(null);
        NavigationManager.NavigateTo("/");
    }
    #endregion
}
