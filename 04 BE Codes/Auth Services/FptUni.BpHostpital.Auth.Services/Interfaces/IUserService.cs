using FptUni.BpHostpital.Auth.Utils;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using FptUni.BpHospital.Common.DTOs;

namespace FptUni.BpHostpital.Auth.Services;

public interface IUserService
{
    Task<UserSession> SignInAsync(SignInModel model);

    Task<IdentityResult> SignUpAsync(SignUpModel model);

    Task<RenewTokenResponseModel> RenewTokenAsync(RenewTokenModel model);
}
