using Application.Services;
using AutoMapper;
using Dto.SwStar;
using Dto.SwStar.Request;
using Microsoft.AspNetCore.Mvc;
using Pigi.MDbLogging;
using Presentation.webApi.Models;
using Utility;

namespace Presentation.webApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ProviderRequestController : ControllerBase
    {
        public IServiceProvider _serviceProvider { get; }
        public IProviderRequestService ProviderRequestService { get; }
        public IMapper Mapper { get; }
        public ProviderRequestController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            ProviderRequestService = _serviceProvider.GetRequiredService<IProviderRequestService>();
            Mapper = _serviceProvider.GetRequiredService<IMapper>();
        }


        [HttpPost("AddProviderRequest")]
        //[LoggingAspect]
        public async Task<IActionResult> AddProviderRequest(ProviderRequestViewModel model)
        {
            try
            {
                var dto = Mapper.Map<ProviderRequestDto>(model);
                var report = await ProviderRequestService.AddProviderRequestAsync(dto);
                if (report.status == 0)
                {
                    return Ok(new Response
                    {
                        status = report.status
                    });
                }
                else
                {
                    return Ok(new Response
                    {
                        status = report.status
                    });
                }

            }
            catch (Exception e)
            {

                return Ok(new MessageModel<bool>
                {
                    Data = false,
                    message = e.Message,
                    status = -2
                });
            }
        }

    }
}
