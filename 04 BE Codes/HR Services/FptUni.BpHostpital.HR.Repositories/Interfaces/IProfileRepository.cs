﻿using System.Threading.Tasks;
using FptUni.BpHostpital.HR.Utils;
using ShareLibrary.Repositories;

namespace FptUni.BpHostpital.HR.Repositories;

public interface IProfileRepository : IBaseRepository<Profile, HrDbContext>
{
    #region [ Methods - Single ]
    Task<Profile> GetSingleByUserIdAsync(string userId);
    #endregion
}
