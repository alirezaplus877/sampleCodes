using Application.Services;
using AutoMapper;
using Dto.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pigi.MDbLogging;
using Presentation.webApi.Models;
using Presentation.webApi.Models.Installment;
using Utility.Constant;
using Utility.helpers;

namespace Presentation.webApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class InstallmentController : ControllerBase, ILoggable
    {
        public IServiceProvider ServiceProvider { get; }
        public IInstallmentService InstallmentService { get; }
        public IMapper Mapper { get; }
        public IMdbLogger<InstallmentController> Logger { get; }

        public InstallmentController(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            InstallmentService = serviceProvider.GetRequiredService<IInstallmentService>();
            Mapper = serviceProvider.GetRequiredService<IMapper>();
            Logger = serviceProvider.GetRequiredService<IMdbLogger<InstallmentController>>();
        }


        [HttpPost("AddInstallment")]
        public async Task<IActionResult> AddInstallment(InstallmentViewModel model)
        {
            try
            {
                Logger.Log(TraceIdExplore.TraceId, $"Start InstallmentController's action AddInstallment", JsonConvert.SerializeObject(model));

                var dto = Mapper.Map<InstallmentDto>(model);
                var report = await InstallmentService.AddInstallmentAsync(dto);
                Logger.Log(TraceIdExplore.TraceId, $"End InstallmentController's action AddInstallment", JsonConvert.SerializeObject(report));

                if (report.status == 0)
                {
                    return Ok(new _Response
                    {
                        status = report.status
                    });
                }
                else
                {
                    return Ok(new _Response
                    {
                        status = report.status
                    });
                }

            }
            catch (Exception ex)
            {
                Logger.Log(TraceIdExplore.TraceId, $"Exception on InstallmentController's action AddInstallment", JsonConvert.SerializeObject(ex), ex);

                return Ok(new _Response
                {
                    status = StatusConstants.UnSuccess
                });
            }
        }


        [HttpPost("UpdateInstallment")]
        public async Task<IActionResult> UpdateInstallment(InstallmentViewModel model)
        {
            try
            {
                Logger.Log(TraceIdExplore.TraceId, $"Start InstallmentController's action UpdateInstallment", JsonConvert.SerializeObject(model));

                var dto = Mapper.Map<InstallmentDto>(model);
                var report = await InstallmentService.UpdateInstallmentAsync(dto);
                Logger.Log(TraceIdExplore.TraceId, $"End InstallmentController's action UpdateInstallment", JsonConvert.SerializeObject(report));

                if (report.status == 0)
                {
                    return Ok(new _Response
                    {
                        status = report.status
                    });
                }
                else
                {
                    return Ok(new _Response
                    {
                        status = report.status
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.Log(TraceIdExplore.TraceId, $"Exception on InstallmentController's action UpdateInstallment", JsonConvert.SerializeObject(ex), ex);

                return Ok(new _Response
                {
                    status = StatusConstants.UnSuccess
                });
            }
        }

        [HttpGet("GetInstallmentById")]
        public async Task<IActionResult> GetInstallmentById([FromBody] long id)
        {
            try
            {
                Logger.Log(TraceIdExplore.TraceId, $"Start InstallmentController's action GetInstallmentById", JsonConvert.SerializeObject(id));

                var report = await InstallmentService.GetInstallmentById(id);
                Logger.Log(TraceIdExplore.TraceId, $"End InstallmentController's action GetInstallmentById", JsonConvert.SerializeObject(id));

                if (report.status == 0)
                {
                    return Ok(new _Response<InstallmentViewModel>
                    {
                        Data = Mapper.Map<InstallmentViewModel>(report.Data),
                        status = report.status
                    });
                }
                else
                {
                    return Ok(new _Response<InstallmentViewModel>
                    {
                        Data = null,
                        status = report.status
                    });
                }

            }
            catch (Exception ex)
            {
                Logger.Log(TraceIdExplore.TraceId, $"Exception on InstallmentController's action GetInstallmentById", JsonConvert.SerializeObject(ex), ex);

                return Ok(new _Response
                {
                    status = StatusConstants.UnSuccess
                });
            }
        }

        [HttpPost("EnableInstallmentById")]
        public async Task<IActionResult> EnableInstallmentById([FromBody] long id)
        {
            try
            {
                Logger.Log(TraceIdExplore.TraceId, $"Start InstallmentController's action EnableInstallmentById", JsonConvert.SerializeObject(id));

                var report = await InstallmentService.EnableInstallmentById(id);
                Logger.Log(TraceIdExplore.TraceId, $"End InstallmentController's action EnableInstallmentById", JsonConvert.SerializeObject(report));

                if (report.status == 0)
                {
                    return Ok(new _Response
                    {
                        status = report.status
                    });
                }
                else
                {
                    return Ok(new _Response
                    {
                        status = report.status
                    });
                }

            }
            catch (Exception ex)
            {
                Logger.Log(TraceIdExplore.TraceId, $"Exception on InstallmentController's action EnableInstallmentById", JsonConvert.SerializeObject(ex), ex);

                return Ok(new _Response
                {
                    status = StatusConstants.UnSuccess
                });
            }
        }

        [HttpPost("DisableInstallmentById")]
        public async Task<IActionResult> DisableInstallmentById([FromBody] long id)
        {
            try
            {
                Logger.Log(TraceIdExplore.TraceId, $"Start InstallmentController's action DisableInstallmentById", JsonConvert.SerializeObject(id));

                var report = await InstallmentService.DisableInstallmentById(id);
                Logger.Log(TraceIdExplore.TraceId, $"End InstallmentController's action DisableInstallmentById", JsonConvert.SerializeObject(report));

                if (report.status == 0)
                {
                    return Ok(new _Response
                    {
                        status = report.status
                    });
                }
                else
                {
                    return Ok(new _Response
                    {
                        status = report.status
                    });
                }

            }
            catch (Exception ex)
            {
                Logger.Log(TraceIdExplore.TraceId, $"Exception on InstallmentController's action DisableInstallmentById", JsonConvert.SerializeObject(ex), ex);

                return Ok(new _Response
                {
                    status = StatusConstants.UnSuccess
                });
            }
        }

        [HttpPost("ChangeStateInstallmentByContractId")]
        public async Task<IActionResult> ChangeStateInstallmentByContractId(ChangeStateInstallmentByContractIdViewModel model)
        {
            try
            {
                Logger.Log(TraceIdExplore.TraceId, $"Start FactorController's action ChangeStateInstallmentByContractId", JsonConvert.SerializeObject(model));

                //شرط پیدا کردن state  هم باید اضافه گردد
                var getInstallmentContract = await InstallmentService.GetInstallmentByContractId(model.ContractId);
                Logger.Log(TraceIdExplore.TraceId, $"End InstallmentController's action ChangeStateInstallmentByContractId", JsonConvert.SerializeObject(getInstallmentContract));

                if (getInstallmentContract.status != 0)
                {
                    return Ok(new _Response
                    {
                        status = StatusConstants.NotFound
                    });
                }

                var report = await InstallmentService.ChangeStateInstallmentByContractId(model.ContractId, model.StateId);
                if (report.status == 11)
                {
                    return Ok(new _Response
                    {
                        status = report.status
                    });
                }
                else
                {
                    return Ok(new _Response
                    {
                        status = report.status
                    });
                }

            }
            catch (Exception ex)
            {
                Logger.Log(TraceIdExplore.TraceId, $"Exception on InstallmentController's action ChangeStateInstallmentByContractId", JsonConvert.SerializeObject(ex), ex);

                return Ok(new _Response
                {
                    status = StatusConstants.UnSuccess
                });
            }
        }
    }
}
