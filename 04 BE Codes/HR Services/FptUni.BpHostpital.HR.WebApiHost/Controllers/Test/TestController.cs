using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FptUni.BpHostpital.HR.WebApiHost;

public class TestController : ControllerBase
{
	#region [ Properties - Fields ]
	public readonly IDbContextFactory<HrDbContext> _dbContextFactory;
	#endregion

	#region [ CTor ]
	public TestController(IDbContextFactory<HrDbContext> dbContextFactory)
	{
        this._dbContextFactory = dbContextFactory;
    }
	#endregion


}
