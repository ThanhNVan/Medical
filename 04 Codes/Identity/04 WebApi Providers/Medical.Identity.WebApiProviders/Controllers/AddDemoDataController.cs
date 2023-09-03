using Medical.Identity.DataProviders;
using Medical.Identity.EntityProviders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Medical.Identity.WebApiProviders;

//[ApiController]
//[Route("Api/V1/[controller]")]
public class AddDemoDataController : ControllerBase
{
    #region [ Fields ]
    private readonly IdentityDataContext _dataContext;
    #endregion

    #region [ CTor ]
    public AddDemoDataController(IdentityDataContext dataContext)
    {
        this._dataContext = dataContext;
    }
    #endregion

    [HttpGet]
    public async Task<IActionResult> AddSample()
    {
        try
        {
            var user = Factory.CreateUser("thanhn.van@gmail.com",
                                            "123456@Aa",
                                            "Thanh", "Van");
            var passwordHash = this._dataContext.Encription.HashWithSalt("123456@Aa", user.Id);
            user.PasswordHash = passwordHash;
            var hrManager = Factory.CreateHRManager(user.Id);
            var salesManager = Factory.CreateSalesManager(user.Id);

            using var context = await this._dataContext.User.GetContextAsync();

            // UnitOfWork
            await this._dataContext.User.AddAsync(user,context);
            await this._dataContext.UserRole.AddAsync(hrManager, context);
            await this._dataContext.UserRole.AddAsync(salesManager, context);
            await this._dataContext.UserRole.SaveChangedAsync(context);

            return Ok();

        } catch (Exception)
        {
            return BadRequest();
            throw;
        }
    }
}
