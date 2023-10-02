using FptUni.BpHostpital.HR.Utils;
using ShareLibrary.Repositories;

namespace FptUni.BpHostpital.HR.Repositories;

public interface IUserRepository : IBaseRepository<User, HrDbContext>
{
}
