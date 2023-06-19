using Application.Services;
using AutoMapper;
using Dto.SwStar.CSP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Pigi.MDbLogging;
using Presentation.webApi.Models.CSP;
using ProxyService.SwStar;
using Repository.Repository;
using Utility;
using Utility.helpers;

namespace Presentation.webApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CSPController : ControllerBase, ILoggable
    {
        #region Fields
        private readonly IMdbLogger<CSPController> _logger;
        private readonly ICSPService _cSPService;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public CSPController(
            IMdbLogger<CSPController> logger ,ICSPService cSPRepository, IMapper mapper)
        {
            _cSPService = cSPRepository;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region SetStatus
        [HttpPost("SetStatus")]
        public async Task<Response> SetStatus(CSPActivationViewModel model)
        {
            return await _cSPService.SetActiveOrDeactive(model.Id, model.Status);
        }
        #endregion

        [HttpPost("Edit")]
        public async Task<Response> Edit([FromRoute]int Id,CSPEditViewModel model)
        {
            CSPInformationDto cSP=_mapper.Map<CSPInformationDto>(model);
            cSP.Id = Id;
            var res = await _cSPService.EditCsp(cSP);
            return res;
        }

        [HttpPost("GetCSPInformation")]
        public async Task<Response> GetCSPInformation(int Id)
        {
            return await _cSPService.GetCSPInfo(Id);
        }

        #region InsertCSPInformation
        [HttpPost("InsertCSPInformation")]
        public async Task<Response<CSPInformationDto>> InsertCSPInformation(CSPInformationViewModel model)
        {
            Response<CSPInformationDto> result = null;

            try
            {
                _logger.Log(TraceIdExplore.TraceId, $"Start CSPController's action {nameof(InsertCSPInformation)}", JsonConvert.SerializeObject(model));

                var dto = _mapper.Map<CSPInformationDto>(model);

                result = await _cSPService.InsertCSPInformation(dto);

                _logger.Log(TraceIdExplore.TraceId, $"End CSPController's action {nameof(InsertCSPInformation)}", JsonConvert.SerializeObject(model));
            }
            catch (Exception ex)
            {
                _logger.Log(TraceIdExplore.TraceId, $"Exception on CSPController's action {nameof(InsertCSPInformation)}", JsonConvert.SerializeObject(ex), ex);
            }

            return result;
        } 
        #endregion
    }
}
