using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FptUni.BpHostpital.HR.Repositories;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.Services;

namespace FptUni.BpHostpital.HR.Services;

public class OccupationService : BaseServices<Occupation, IOccupationRepository, HrDbContext>, IOccupationService
{
    #region [ CTor ]
    public OccupationService(ILogger<OccupationService> logger, IOccupationRepository repository, IEncriptionProvider encriptionProvider) : base(logger, repository, encriptionProvider)
{
}
    #endregion
}
