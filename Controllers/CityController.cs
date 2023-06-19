using Application.Services;
using AutoMapper;
using Dto.SwStar.City;
using Dto.SwStar.Request;
using Entities.SwStar;
using Microsoft.AspNetCore.Mvc;
using Presentation.webApi.Models;
using Utility;

namespace Presentation.webApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CityController : ControllerBase
    {
        public IServiceProvider _serviceProvider { get; }
        public ICityService CityService { get; }
        public IMapper Mapper { get; }
        public CityController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            CityService = _serviceProvider.GetRequiredService<ICityService>();
            Mapper = _serviceProvider.GetRequiredService<IMapper>();
        }


        [HttpPost("GetCity")]
        //[LoggingAspect]
        public async Task<Response> GetCity(int provinceId)
        {
            return await CityService.GetCity(provinceId);
        }
    }
}
