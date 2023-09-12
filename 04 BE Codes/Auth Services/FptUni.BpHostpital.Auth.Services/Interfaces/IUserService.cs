using FptUni.BpHostpital.Auth.Utils;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace FptUni.BpHostpital.Auth.Services;

public interface IUserService
{
    Task<SignInSuccessModel> SignInAsync(SignInModel model);

    Task<IdentityResult> SignUpAsync(SignUpModel model);
}
