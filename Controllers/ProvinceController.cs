using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace Presentation.webApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ProvinceController : ControllerBase
    {
        public IServiceProvider _serviceProvider { get; }
        public IProvinceService ProvinceService { get; }
        public IMapper Mapper { get; }
        public ProvinceController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            ProvinceService = _serviceProvider.GetRequiredService<IProvinceService>();
            Mapper = _serviceProvider.GetRequiredService<IMapper>();
        }


        [HttpGet("GetProvinceList")]
        //[LoggingAspect]
        public async Task<Response> GetProvinceList()
        {
            return await ProvinceService.GetIProvinceList();
        }
    }
}
