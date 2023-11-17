using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShareLibrary.WebApiProviders;

[Authorize(Policy = "HRManager")]
[ApiController]
[Route("Api/V1/[controller]")]
public abstract class BaseWebApiController<TEntity, TService, TContext> : ControllerBase
    where TEntity : BaseEntity
    where TContext : DbContext
    where TService : IBaseService<TEntity>
{
    #region [ Fields ]
    protected readonly ILogger<BaseWebApiController<TEntity, TService, TContext>> _logger;
    protected readonly TService _service;
    #endregion

    #region [ CTor ]
    public BaseWebApiController(ILogger<BaseWebApiController<TEntity, TService, TContext>> logger,
                                TService logicProvider)
    {

        this._logger = logger;
        this._service = logicProvider;
    }
    #endregion

    #region [ Public Methods - CRUD ]
    [HttpPost(nameof(BaseMethodUrl.Add))]
    public virtual async Task<IActionResult> AddAsync([FromBody] TEntity entity)
    {
        try
        {
            var dbEntity = await this._service.GetSingleByIdAsync(entity.Id);

            if (dbEntity != null)
            {
                var error = $"Duplicated {typeof(TEntity)}";
                this._logger.LogError(error);
                return BadRequest(error);
            }

            var result = await this._service.AddAsync(entity);

            if (result)
            {
                return Ok("Added");
            } else
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

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

    [HttpGet(nameof(BaseMethodUrl.GetSingleById) + "/{id}")]
    public virtual async Task<IActionResult> GetSingleByIdAsync(string id)
    {
        try
        {
            var result = await this._service.GetSingleByIdAsync(id);

            if (result == null)
            {
                return BadRequest("Empty");
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

    [HttpPut(nameof(BaseMethodUrl.Update))]
    public virtual async Task<IActionResult> UpdateAsync([FromBody] TEntity entity)
    {
        try
        {
            var dbEntity = await this._service.GetSingleByIdAsync(entity.Id);
            if (dbEntity == null)
            {
                return BadRequest($"Not existed {typeof(TEntity)}");
            }

            var result = await this._service.UpdateAsync(entity);
            if (result)
            {
                return Ok("Updated");
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);

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

    [HttpDelete(nameof(BaseMethodUrl.SoftDelete) + "/{id}")]
    public virtual async Task<IActionResult> SoftDeleteAsync(string id)
    {
        try
        {
            var dbEntity = await this._service.GetSingleByIdAsync(id);

            if (dbEntity == null)
            {
                var error = $"Duplicated {typeof(TEntity)}";
                this._logger.LogError(error);
                return BadRequest(error);
            }

            var result = await this._service.SoftDeleteAsync(id);

            if (result)
            {
                return Ok("Soft Deleted");
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
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

    [HttpPut(nameof(BaseMethodUrl.Recover))]
    public virtual async Task<IActionResult> RecoverAsync([FromBody] string id)
    {
        try
        {
            var dbEntity = await this._service.GetSingleByIdAsync(id);

            if (dbEntity == null)
            {
                return BadRequest($"Not existed {typeof(TEntity)}");
            }

            var result = await this._service.RecoverAsync(id);

            if (result)
            {
                return Ok("Recovered");
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
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

    [HttpDelete(nameof(BaseMethodUrl.Destroy) + "/{id}")]
    public virtual async Task<IActionResult> DestroyAsync(string id)
    {
        try
        {
            var dbEntity = await this._service.GetSingleByIdAsync(id);

            if (dbEntity == null)
            {
                return BadRequest($"Not existed {typeof(TEntity)}");
            }

            var result = await this._service.DestroyAsync(id);

            if (result)
            {
                return Ok("Destroyed");
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
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

    [HttpGet(nameof(BaseMethodUrl.GetListAll))]
    public virtual async Task<IActionResult> GetListAllAsync()
    {
        try
        {
            var result = await this._service.GetListAllAsync();
            if (result == null || result.Count() <= 0)
            {
                return NotFound("Empty");
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

    [HttpGet(nameof(BaseMethodUrl.GetListIsDeleted))]
    public virtual async Task<IActionResult> GetListIsDeletedAsync()
    {
        try
        {
            var result = await this._service.GetListIsDeletedAsync();
            if (result == null || result.Count() <= 0)
            {
                return NotFound("Empty");
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

    [HttpGet(nameof(BaseMethodUrl.GetListIsNotDeleted))]
    public virtual async Task<IActionResult> GetListIsNotDeletedAsync()
    {
        try
        {
            var result = await this._service.GetListIsNotDeletedAsync();
            if (result == null || result.Count() <= 0)
            {
                return NotFound("Empty");
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

    [HttpGet(nameof(BaseMethodUrl.CountAll))]
    public virtual async Task<IActionResult> CountAllAsync()
    {
        try
        {
            var result = await this._service.CountAllAsync();

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

    [HttpGet(nameof(BaseMethodUrl.CountIsDeleted))]
    public virtual async Task<IActionResult> CountIsDeletedAsync()
    {
        try
        {
            var result = await this._service.CountIsDeletedAsync();

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

    [HttpGet(nameof(BaseMethodUrl.CountIsNotDeleted))]
    public virtual async Task<IActionResult> CountIsNotDeletedAsync()
    {
        try
        {
            var result = await this._service.CountIsNotDeletedAsync();

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
