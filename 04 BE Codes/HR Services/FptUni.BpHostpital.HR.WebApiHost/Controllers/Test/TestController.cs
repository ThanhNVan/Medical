using System;
using System.Threading.Tasks;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FptUni.BpHostpital.HR.WebApiHost;

//[ApiController]
//[Route("Api/V1/[controller]")]
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

	//[HttpGet]
	public async Task<IActionResult> Test()
	{
		using var dbContext = await _dbContextFactory.CreateDbContextAsync();
		var strategy = dbContext.Database.CreateExecutionStrategy();

		try
		{
			await strategy.ExecuteAsync(async () =>
			{
                using var transaction = await dbContext.Database.BeginTransactionAsync();
				await dbContext.AddRangeAsync(DataFactory.Current.Roles);
				await dbContext.AddRangeAsync(DataFactory.Current.Departments);
				await dbContext.AddRangeAsync(DataFactory.Current.Occupations);
				await dbContext.AddRangeAsync(DataFactory.Current.Users);
				await dbContext.AddRangeAsync(DataFactory.Current.ContactPersons);
				await dbContext.AddRangeAsync(DataFactory.Current.UserRoles);
				await dbContext.AddRangeAsync(DataFactory.Current.Profiles);
				await dbContext.AddRangeAsync(DataFactory.Current.Attendances);
				await dbContext.AddRangeAsync(DataFactory.Current.LeaveRequests);
                await dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            });


			return Ok();
		} catch (Exception ex)
		{
			return BadRequest(ex.ToString());
		}
	}
}
