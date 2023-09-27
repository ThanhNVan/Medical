using FptUni.BpHospital.Common.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;

namespace FptUni.BpHospital.BlazorFE.Pages;

public partial class Index
{
    #region [ Properties ]
    [Inject]
    public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }
    #endregion

    #region [ Field ]
    private SignInModel model = new SignInModel();
    #endregion

    #region [ Methods -  ]
    private async Task AuthenticateAsync()
    {
        var customAuthStateProvider = (AuthenticationProvider)AuthenticationStateProvider;
        NavigationManager.NavigateTo("/fetchdata", true);
    }
    #endregion
}
