using Application.Services;
using AutoMapper;
using Dto.SwStar.Merchant;
using Dto.SwStar.Product;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PEC.Dto;
using Pigi.MDbLogging;
using Presentation.webApi.Models;
using Utility.Constant;
using Utility.helpers;

namespace Presentation.webApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class SwMerchantController : ControllerBase, ILoggable
    {
        public IServiceProvider ServiceProvider { get; }
        public ISwMerchantService SwMerchantService { get; }
        public IMapper Mapper { get; }
        public IMdbLogger<SwMerchantController> Logger { get; }

        public SwMerchantController(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            SwMerchantService = serviceProvider.GetRequiredService<ISwMerchantService>();
            Mapper = serviceProvider.GetRequiredService<IMapper>();
            Logger = serviceProvider.GetRequiredService<IMdbLogger<SwMerchantController>>();
        }


        [HttpPost("AddSwMerchant")]
        public async Task<IActionResult> AddSwMerchant(SwMerchantViewModel model)
        {
            try
            {
                Logger.Log(TraceIdExplore.TraceId, $"Start SwMerchantController's action AddSwMerchant", JsonConvert.SerializeObject(model));

                var dto = Mapper.Map<SwMerchantDto>(model);
                var report = await SwMerchantService.AddSwMerchantAsync(dto);
                Logger.Log(TraceIdExplore.TraceId, $"End SwMerchantController's action AddSwMerchant", JsonConvert.SerializeObject(report));

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
                Logger.Log(TraceIdExplore.TraceId, $"Exception on SwMerchantController's action AddSwMerchant", JsonConvert.SerializeObject(ex), ex);

                return Ok(new MessageModel<bool>
                {
                    Data = false,
                    message = ex.Message,
                    status = -2
                });
            }
        }


        [HttpPost("UpdateSwMerchant")]
        // [LoggingAspect]
        public async Task<IActionResult> UpdateSwMerchant(SwMerchantViewModel model)
        {

            try
            {
                Logger.Log(TraceIdExplore.TraceId, $"Start SwMerchantController's action UpdateSwMerchant", JsonConvert.SerializeObject(model));
                var dto = Mapper.Map<SwMerchantDto>(model);
                var report = await SwMerchantService.UpdateSwMerchantAsync(dto);
                Logger.Log(TraceIdExplore.TraceId, $"End SwMerchantController's action UpdateSwMerchant", JsonConvert.SerializeObject(report));

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
                Logger.Log(TraceIdExplore.TraceId, $"Exception on SwMerchantController's action UpdateSwMerchant", JsonConvert.SerializeObject(ex), ex);

                return Ok(new MessageModel<bool>
                {
                    Data = false,
                    message = ex.Message,
                    status = -2
                });
            }
        }


        [HttpGet("MerchantActivation")]
        //[LoggingAspect]
        public async Task<IActionResult> MerchantActivation(long Id)
        {
            try
            {
                Logger.Log(TraceIdExplore.TraceId, $"Start SwMerchantController's action MerchantActivation", JsonConvert.SerializeObject(Id));

                var report = await SwMerchantService.MerchantActivation(Id);
                Logger.Log(TraceIdExplore.TraceId, $"End SwMerchantController's action MerchantActivation", JsonConvert.SerializeObject(Id));

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
            catch (Exception e)
            {
                Logger.Log(TraceIdExplore.TraceId, $"Exception on SwMerchantController's action MerchantActivation", JsonConvert.SerializeObject(e), e);

                return Ok(new MessageModel<bool>
                {
                    Data = false,
                    message = e.Message,
                    status = -2
                });
            }
        }

        [HttpGet("MerchantDeactivation")]
        //[LoggingAspect]
        public async Task<IActionResult> MerchantDeactivation(long Id)
        {
            try
            {
                var report = await SwMerchantService.MerchantDeactivation(Id);
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
            catch (Exception e)
            {
                Logger.Log(TraceIdExplore.TraceId, $"Exception on SwMerchantController's action MerchantDeactivation", JsonConvert.SerializeObject(e), e);
                return Ok(new MessageModel<bool>
                {
                    Data = false,
                    message = e.Message,
                    status = -2
                });
            }

        }

        [HttpGet("GetMerchantById")]
        //[LoggingAspect]
        public async Task<IActionResult> GetMerchantById(long Id)
        {
            try
            {
                var report = await SwMerchantService.GetMerchantById(Id);
                if (report != null)
                {
                    return Ok(new _Response<SwMerchantDto>
                    {
                        status = StatusConstants.success,
                        Data=report
                        
                    });
                }
                else
                {
                    return Ok(new _Response
                    {
                        status = StatusConstants.UnSuccess
                    });
                }

            }
            catch (Exception e)
            {
                Logger.Log(TraceIdExplore.TraceId, $"Exception on SwMerchantController's action getmerchant by id", JsonConvert.SerializeObject(e), e);

                return Ok(new MessageModel<bool>
                {
                    Data = false,
                    message = e.Message,
                    status = -2
                });
            }
        }

        [HttpPost("SetExpireTimeMerchant")]
        //[LoggingAspect]
        public async Task<IActionResult> SetExpireTimeMerchant(SetExpireTimeMerchantDto model)
        {
            try
            {
                var report = await SwMerchantService.SetExpireTimeMerchant(model);
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
            catch (Exception e)
            {
                Logger.Log(TraceIdExplore.TraceId, $"Exception on SwMerchantController's action SetExpireTimeMerchant", JsonConvert.SerializeObject(e), e);

                return Ok(new MessageModel<bool>
                {
                    Data = false,
                    message = e.Message,
                    status = -2
                });
            }
        }




        //[HttpPost("HaveSwMerchantByNationalCode")]
        //public async Task<IActionResult> HaveSwMerchantByNationalCode(string nationalcode)
        //{

        //    var report = await SwMerchantService.GetSwMerchantByNationalCodeAsync(nationalcode);
        //    if (report.status == 0)
        //    {
        //        return Ok(true);

        //    }
        //    else
        //    {
        //        return Ok(false);
        //    }
        //}
    }
}
