using FptUni.BpHospital.HttpClientProviders;
using System.Threading.Tasks;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Components;

namespace FptUni.BpHospital.BlazorFE;

public partial class UserDetail
{
	#region [ Properties - Parametter]
	[Parameter]
	public string Id { get; set; }
    #endregion

    #region [ Properties - Inject ]
    [Inject]
    private NavigationManager NavigationManager { get; set; }

    [Inject]
    private HttpClientContext HttpClientContext { get; set; }
    #endregion

    #region [ Properties ]
    public User WorkItem { get; set; }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync()
    {

        this.WorkItem = new User();
        await this.LoadDataAsync();

    }
    #endregion

    #region [ Methods -  ]
    public async Task LoadDataAsync()
    {
        this.WorkItem = await HttpClientContext.User.GetSingleByIdAsync(this.Id);
    }    
    #endregion
}
