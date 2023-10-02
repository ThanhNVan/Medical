﻿using FptUni.BpHostpital.HR.Repositories;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.Services;

namespace FptUni.BpHostpital.HR.Services;

public class ProfileService : BaseServices<Profile, IProfileRepository, HrDbContext>, IProfileService
{
    #region [ CTor ]
    public ProfileService(ILogger<ProfileService> logger, IProfileRepository repository, IEncriptionProvider encriptionProvider) : base(logger, repository, encriptionProvider)
    {
    }
    #endregion
}
