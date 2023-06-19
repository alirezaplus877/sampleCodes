using Application.Services;
using AutoMapper;
using Dto.SwStar;
using Dto.SwStar.Customer;
using Microsoft.AspNetCore.Mvc;
using Presentation.webApi.Models;
using Presentation.webApi.Models.Customer;
using ProxyService.SwStar;
using Utility;

namespace Presentation.webApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerProxy _customerProxy;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerProxy customerProxy,
            ICustomerService customerService,IMapper mapper)
        {
            _customerProxy = customerProxy;
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpPost("AddCustomer")]
        public Response AddCustomer(CustomerViewModel model)
        {
            var customer = _mapper.Map<CustomerDto>(model);
            customer.Id = model.Id;
            return _customerProxy.AddCustomer(customer);
        }

        [HttpPost("Edit")]
        public async Task<Response> Edit(long Id, CustomerViewModel model)
        {
            var customer = _mapper.Map<CustomerDto>(model);
            customer.Id= Id;
            return await _customerService.updateCustomer(customer);
        }

        [HttpPost("SetStatus")]
        public async Task<Response> SetStatus(CustomerSetStatusViewModel model)
        {
            return await _customerService.SetActiveOrDeactive(model.Id, model.Status);
        }

        [HttpPost("SetExpireTime")]
        public async Task<Response> SetCustomerExpireTime(SetCustomerExpireTimeViewModel model)
        {
            return await _customerService.SetCusotmerExpireTime(model.Id, model.ExpireDateTime);
        }
    }
}
