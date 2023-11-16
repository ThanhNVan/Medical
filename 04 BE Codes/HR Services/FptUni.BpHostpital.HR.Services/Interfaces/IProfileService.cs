using System.Threading.Tasks;
using FptUni.BpHostpital.HR.Utils;
using ShareLibrary.Services;

namespace FptUni.BpHostpital.HR.Services;

public interface IProfileService : IBaseService<Profile>
{
    #region [ Methods - Single ]
    Task<Profile> GetSingleByUserIdAsync(string userId);
    #endregion
}
