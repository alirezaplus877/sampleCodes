using Application.Services;
using AutoMapper;
using DnsClient.Protocol;
using Dto.SwStar.CSPLicense;
using Microsoft.AspNetCore.Mvc;
using Presentation.webApi.Models;
using Presentation.webApi.Models.CSP;
using Presentation.webApi.Models.CSPLicense;
using Utility;

namespace Presentation.webApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CSPLicenseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;
        private readonly ICSPLicenseService _cSPLicenseService;

        public CSPLicenseController(IMapper mapper,IServiceProvider serviceProvider)
        {
            _mapper = mapper;
            _serviceProvider = serviceProvider;
            _cSPLicenseService = _serviceProvider.GetRequiredService<ICSPLicenseService>();
        }

        [HttpPost("AddCSPLicense")]
        public Response AddCSPLicense(AddCSPLicenseViewModel model)
        {
            CSPLicenseDto licenseDto = _mapper.Map<CSPLicenseDto>(model);
            return _cSPLicenseService.AddCspLicense(licenseDto);
        }

        [HttpPost("SetLicenseStatus")]
        public async Task<Response> SetLicenseStatus(CSPLicenseSetStatus model)
        {
            return await _cSPLicenseService.SetActiveOrDeactive(model.Id, model.Status);
        }


    }
}
