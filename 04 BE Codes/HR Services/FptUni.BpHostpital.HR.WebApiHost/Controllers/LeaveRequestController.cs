﻿using FptUni.BpHospital.Common;
using System.Threading.Tasks;
using System;
using FptUni.BpHostpital.HR.Services;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShareLibrary.WebApiProviders;

namespace FptUni.BpHostpital.HR.WebApiHost;

public class LeaveRequestController : BaseWebApiController<LeaveRequest, ILeaveRequestService, HrDbContext>
{
    #region [ CTor ]
    public LeaveRequestController(ILogger<LeaveRequestController> logger, ILeaveRequestService logicProvider) : base(logger, logicProvider)
    {
    }
    #endregion

    #region [ Methods - List ]
    [HttpPost(nameof(UrlConstant.GetListByUserId))]
    public virtual async Task<IActionResult> GetListByUserIdAsync([FromBody] GetByUserIdFromAndEndDateModel model)
    {
        try
        {
            var result = await this._service.GetListByUserIdAsync(model.UserId, model.FromDate, model.EndDate);

            if (result is null || result.Count == 0)
            {
                return NotFound();
            }

            return Ok(result);

        } catch (ArgumentNullException ex)
        {
            this._logger.LogError(ex.Message);
            return BadRequest();
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
    #endregion
}
