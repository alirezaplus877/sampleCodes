using Application.Services;
using AutoMapper;
using Dto.SwStar.Merchant;
using Dto.SwStar.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pigi.MDbLogging;
using Presentation.webApi.Models;
using Utility.Constant;
using Utility.helpers;

namespace Presentation.webApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ProductController : ControllerBase, ILoggable
    {
        private readonly IMdbLogger<ProductController> _logger;
        public IServiceProvider ServiceProvider { get; }
        public IProductService ProductService { get; }
        public IMapper Mapper { get; }
        public ProductController(IServiceProvider serviceProvider, IMdbLogger<ProductController> logger)
        {
            ServiceProvider = serviceProvider;
            ProductService = serviceProvider.GetRequiredService<IProductService>();
            Mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = logger;
        }

        [HttpPost("AddProduct")]
        //[LoggingAspect]
        public async Task<IActionResult> AddProduct(ProductDto model)
        {
            try
            {
                _logger.Log(TraceIdExplore.TraceId, $"Start AddProductController's action AddProduct", JsonConvert.SerializeObject(model));

                var id = await ProductService.AddProduct(model);
                _logger.Log(TraceIdExplore.TraceId, $"end AddProductController's action AddProduct", JsonConvert.SerializeObject(model));

                if (id > 0)
                {

                    return Ok(new _Response
                    {
                        status = StatusConstants.success
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
                _logger.Log(TraceIdExplore.TraceId, $"excep AddProductController's action AddProduct", JsonConvert.SerializeObject(model),e);

                return Ok(new MessageModel<bool>
                {
                    Data = false,
                    message = e.Message,
                    status = -2
                });
            }
        }

        [HttpPost("UpdateProduct")]
        // [LoggingAspect]
        public async Task<IActionResult> UpdateProduct(ProductDto model)
        {
            try
            {

           
            _logger.Log(TraceIdExplore.TraceId, $"Start ProductController's action updateProduct", JsonConvert.SerializeObject(model));

            var id = await ProductService.UpdateProduct(model);
            _logger.Log(TraceIdExplore.TraceId, $"end ProductController's action updateProduct", JsonConvert.SerializeObject(model));

            if (id > 0)
            {
                return Ok(new _Response
                {
                    status = StatusConstants.success
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
                _logger.Log(TraceIdExplore.TraceId, $"excep ProductController's action updateProduct", JsonConvert.SerializeObject(model),e);

                return Ok(new _Response
                {
                    status = StatusConstants.UnSuccess
                });
            }
        }

        [HttpGet("ProductActivation")]
        //[LoggingAspect]
        public async Task<IActionResult> ProductActivation( long Id)
        {
            try
            {

                var report = await ProductService.ProductActivation(Id);
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
                _logger.Log(TraceIdExplore.TraceId, $"exception ProductController's action ProductActivation", JsonConvert.SerializeObject(Id),e);

                return Ok(new MessageModel<bool>
                {
                    Data = false,
                    message = e.Message,
                    status = -2
                });
            }
        }

        [HttpGet("ProductDeactivation")]
        //[LoggingAspect]
        public async Task<IActionResult> ProductDeactivation( long Id)
        {
            try
            {
                var report = await ProductService.ProductDeactivation(Id);
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
                _logger.Log(TraceIdExplore.TraceId, $"exception ProductController's action ProductdeActivation", JsonConvert.SerializeObject(Id), e);

                return Ok(new MessageModel<bool>
                {
                    Data = false,
                    message = e.Message,
                    status = -2
                });
            }
        }

        [HttpGet("GetProductById")]
        //[LoggingAspect]
        public async Task<IActionResult> GetProductById(long Id)
        {
            try
            {
                var report = await ProductService.GetProductById(Id);
                if (report != null)
                {
                    return Ok(new _Response<ProductDto>
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
                _logger.Log(TraceIdExplore.TraceId, $"exception ProductController's action GetProductById", JsonConvert.SerializeObject(Id), e);

                return Ok(new MessageModel<bool>
                {
                    Data = false,
                    message = e.Message,
                    status = -2
                });
            }
        }

        [HttpPost("AddProductCategory")]
        //[LoggingAspect]
        public async Task<IActionResult> AddProductCategory(ProductCategoryDto model)
        {
            try
            {
                _logger.Log(TraceIdExplore.TraceId, $"Start ProductCategoryController's action AddProductCategory", JsonConvert.SerializeObject(model));

                var report = await ProductService.AddProductCategory(model);
                _logger.Log(TraceIdExplore.TraceId, $"end ProductCategoryController's action AddProductCategory", JsonConvert.SerializeObject(model));

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
                _logger.Log(TraceIdExplore.TraceId, $"exception ProductController's action AddProductCategory", JsonConvert.SerializeObject(model), e);

                return Ok(new MessageModel<bool>
                {
                    Data = false,
                    message = e.Message,
                    status = -2
                });
            }
        }

        [HttpGet("ProductCategoryActivation")]
        //[LoggingAspect]
        public async Task<IActionResult> ProductCategoryActivation( int Id)
        {
            try
            {
                var report = await ProductService.ProductCategoryActivation(Id);
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
                _logger.Log(TraceIdExplore.TraceId, $"exception ProductController's action ProductCategoryActivation", JsonConvert.SerializeObject(Id), e);

                return Ok(new MessageModel<bool>
                {
                    Data = false,
                    message = e.Message,
                    status = -2
                });
            }
        }
        [HttpGet("ProductCategoryDectivation")]
        //[LoggingAspect]
        public async Task<IActionResult> ProductCategoryDectivation(int Id)
        {
            try
            {
                var report = await ProductService.ProductCategoryDectivation(Id);
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
                _logger.Log(TraceIdExplore.TraceId, $"exception ProductController's action ProductCategoryDectivation", JsonConvert.SerializeObject(Id), e);

                return Ok(new MessageModel<bool>
                {
                    Data = false,
                    message = e.Message,
                    status = -2
                });
            }
        }

        [HttpPost("AddProviderRequest")]
        //[LoggingAspect]
        public async Task<IActionResult> AddProviderRequest(ProviderRequestDto model)
        {
            try
            {
                _logger.Log(TraceIdExplore.TraceId, $"Start ProductController's action AddProviderRequest", JsonConvert.SerializeObject(model));

                var report = await ProductService.AddProviderRequest(model);
                if (report.status == 0)
                {
                    return Ok(new _Response
                    {
                        status =0
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
                _logger.Log(TraceIdExplore.TraceId, $"exception ProductController's action AddProviderRequest", JsonConvert.SerializeObject(model), e);

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
