using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace Presentation.webApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class SettelmentController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ISettelmentService _settelmentService;

        public SettelmentController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _settelmentService = _serviceProvider.GetRequiredService<ISettelmentService>();
        }

        [HttpPost]
        public async Task<Response> GetSettelment(long ContractId)
        {
            return await _settelmentService.GetSettelmentByContractId(ContractId);
        }
    }
}
