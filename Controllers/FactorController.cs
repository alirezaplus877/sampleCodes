using Application.Services;
using AutoMapper;
using Dto.SwStar.Faktor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pigi.MDbLogging;
using Presentation.webApi.Models;
using Presentation.webApi.Models.Factor;
using Utility.Constant;
using Utility.helpers;

namespace Presentation.webApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class FactorController : ControllerBase, ILoggable
    {
        public IServiceProvider ServiceProvider { get; }
        public IFactorService FactorService { get; }
        public IMapper Mapper { get; }
        public IMdbLogger<FactorController> Logger { get; }

        public FactorController(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            FactorService = serviceProvider.GetRequiredService<IFactorService>();
            Mapper = serviceProvider.GetRequiredService<IMapper>();
            Logger = serviceProvider.GetRequiredService<IMdbLogger<FactorController>>();
        }


        [HttpPost("AddFactor")]
        public async Task<IActionResult> AddFactor(FactorViewModel model)
        {
            try
            {
                Logger.Log(TraceIdExplore.TraceId, $"Start FactorController's action AddFactor", JsonConvert.SerializeObject(model));

                var dto = Mapper.Map<FactorDto>(model);
                var report = await FactorService.AddFactorAsync(dto);
                Logger.Log(TraceIdExplore.TraceId, $"End FactorController's action AddFactor", JsonConvert.SerializeObject(report));

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
                Logger.Log(TraceIdExplore.TraceId, $"Exception on FactorController's action AddFactor", JsonConvert.SerializeObject(ex), ex);

                return Ok(new _Response
                {
                    status = StatusConstants.UnSuccess
                });
            }
        }


        [HttpPost("UpdateFactor")]
        public async Task<IActionResult> UpdateFactor(FactorViewModel model)
        {
            try
            {
                if (model.Id == null || model.Id <= 0)
                {
                    return Ok(new _Response
                    {
                        status = StatusConstants.FactorIdNotFound
                    });
                }

                Logger.Log(TraceIdExplore.TraceId, $"Start FactorController's action UpdateFactor", JsonConvert.SerializeObject(model));

                var dto = Mapper.Map<FactorDto>(model);
                var report = await FactorService.UpdateFactorAsync(dto);
                Logger.Log(TraceIdExplore.TraceId, $"End FactorController's action UpdateFactor", JsonConvert.SerializeObject(report));

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
                Logger.Log(TraceIdExplore.TraceId, $"Exception on FactorController's action UpdateFactor", JsonConvert.SerializeObject(ex), ex);

                return Ok(new _Response
                {
                    status = StatusConstants.UnSuccess
                });
            }
        }

        [HttpGet("GetFactorById")]
        public async Task<IActionResult> GetFactorById([FromBody] long id)
        {
            try
            {
                Logger.Log(TraceIdExplore.TraceId, $"Start FactorController's action GetFactorById", JsonConvert.SerializeObject(id));

                var report = await FactorService.GetFactorById(id);
                Logger.Log(TraceIdExplore.TraceId, $"End FactorController's action GetFactorById", JsonConvert.SerializeObject(report));

                if (report.status == 0)
                {
                    return Ok(new _Response<FactorViewModel>
                    {
                        Data = Mapper.Map<FactorViewModel>(report.Data),
                        status = report.status
                    });
                }
                else
                {
                    return Ok(new _Response<FactorViewModel>
                    {
                        Data = null,
                        status = report.status
                    });
                }

            }
            catch (Exception ex)
            {
                Logger.Log(TraceIdExplore.TraceId, $"Exception on FactorController's action GetFactorById", JsonConvert.SerializeObject(ex), ex);

                return Ok(new _Response
                {
                    status = StatusConstants.UnSuccess
                });
            }
        }

        [HttpPost("EnableFactorById")]
        public async Task<IActionResult> EnableFactorById([FromBody] long id)
        {
            try
            {
                Logger.Log(TraceIdExplore.TraceId, $"Start FactorController's action EnableFactorById", JsonConvert.SerializeObject(id));

                var report = await FactorService.EnableFactorById(id);
                Logger.Log(TraceIdExplore.TraceId, $"End FactorController's action EnableFactorById", JsonConvert.SerializeObject(report));

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
                Logger.Log(TraceIdExplore.TraceId, $"Exception on FactorController's action EnableFactorById", JsonConvert.SerializeObject(ex), ex);

                return Ok(new _Response
                {
                    status = StatusConstants.UnSuccess
                });
            }
        }

        [HttpPost("DisableFactorById")]
        public async Task<IActionResult> DisableFactorById([FromBody] long id)
        {
            try
            {
                Logger.Log(TraceIdExplore.TraceId, $"Start FactorController's action DisableFactorById", JsonConvert.SerializeObject(id));

                var report = await FactorService.DisableFactorById(id);
                Logger.Log(TraceIdExplore.TraceId, $"End FactorController's action DisableFactorById", JsonConvert.SerializeObject(report));

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
                Logger.Log(TraceIdExplore.TraceId, $"Exception on FactorController's action DisableFactorById", JsonConvert.SerializeObject(ex), ex);

                return Ok(new _Response
                {
                    status = StatusConstants.UnSuccess
                });
            }
        }

    }
}
