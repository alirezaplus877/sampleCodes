using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace Presentation.webApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _productCategoryService = serviceProvider.GetRequiredService<IProductCategoryService>();
        }

        
        [HttpPost("GetProductCaegory")]
        public async Task<Response> GetProductCaegory()
        {
            return await _productCategoryService.GetAllProductCategory();
        }



    }
}
