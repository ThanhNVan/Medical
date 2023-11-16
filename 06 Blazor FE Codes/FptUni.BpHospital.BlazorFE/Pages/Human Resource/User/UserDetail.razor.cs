using FptUni.BpHospital.HttpClientProviders;
using System.Threading.Tasks;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using FptUni.BpHospital.Common;
using System;

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

    #region [ Properties - Data ]
    public User WorkItem { get; set; }
    public Profile UserProfile { get; set; }
    public IList<Occupation> Occupations { get; set; }
    public IList<ContactPerson> ContactPersons { get; set; }
    public IList<UserRoleModel> UserRoleModels { get; set; }
    public IList<Attendance> Attendances { get; set; }

    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync()
    {

        this.WorkItem = new User();
        this.UserProfile = new Profile();
        this.Occupations = new List<Occupation>();
        this.ContactPersons = new List<ContactPerson>();
        this.UserRoleModels = new List<UserRoleModel>();
        this.Attendances = new List<Attendance>();
        await this.LoadDataAsync();

    }
    #endregion

    #region [ Methods -  ]
    public async Task LoadDataAsync()
    {
        this.WorkItem = await HttpClientContext.User.GetSingleByIdAsync(this.Id);
        this.Occupations = await HttpClientContext.Occupation.GetListAllAsync();
        this.WorkItem.Occupation = Occupations.FirstOrDefault(x => x.Id == this.WorkItem.OccupationId);
        this.UserProfile = await HttpClientContext.Profile.GetSingleByUserIdAsync(this.Id);
        this.UserRoleModels = await HttpClientContext.UserRole.GetListByUserIdAsync(this.Id);
        this.Attendances = await HttpClientContext.Attendance.GetListByUserIdAsync(new GetAttendanceModel() { UserId = this.Id, FromDate = DateTime.UtcNow.AddDays(-15), EndDate = DateTime.UtcNow.AddDays(1) });
        this.ContactPersons = await HttpClientContext.ContactPerson.GetListByUserIdAsync(this.Id);
    }    
    #endregion
}
