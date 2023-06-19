using Application.Services;
using AutoMapper;
using Dto.SwStar.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Pigi.MDbLogging;
using Presentation.webApi.Models.Contract;
using ProxyService.SwStar;
using Repository.Repository;
using Utility;
using Utility.Constant;
using Utility.helpers;

namespace Presentation.webApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ContractController : ControllerBase, ILoggable
    {
        #region Fields
        private readonly IMdbLogger<ContractController> _logger;
        private readonly IContractService _contractService;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public ContractController(
            IMdbLogger<ContractController> logger, IContractService ContractRepository, IMapper mapper)
        {
            _contractService = ContractRepository;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region Activation
        [HttpPost("Activation")]
        public async Task<Response> Activation(ContractActivationViewModel model)
        {
            Response resp = null;

            try
            {
                _logger.Log(TraceIdExplore.TraceId, $"Start ContractController's action Activation", JsonConvert.SerializeObject(model));

                resp = await _contractService.SetActiveOrDeactive(model.Id, model.Status);
            }
            catch (Exception ex)
            {
                resp = new Response<GetContractDto>(null, StatusConstants.UnSuccess);

                _logger.Log(TraceIdExplore.TraceId, $"Exception on ContractController's action Activation", JsonConvert.SerializeObject(ex), ex);
            }

            _logger.Log(TraceIdExplore.TraceId, $"End ContractController's action Activation", JsonConvert.SerializeObject(resp));

            return resp;
        }
        #endregion

        #region Get
        [HttpPost("Get")]
        public async Task<Response<GetContractDto>> Get(long Id)
        {
            Response<GetContractDto> resp = null;

            try
            {
                _logger.Log(TraceIdExplore.TraceId, $"Start ContractController's action get", JsonConvert.SerializeObject(new
                {
                    Id = Id
                }));

                resp = await _contractService.GetContract(Id);
            }
            catch (Exception ex)
            {
                resp = new Response<GetContractDto>(null, StatusConstants.UnSuccess);

                _logger.Log(TraceIdExplore.TraceId, $"Exception on ContractController's action get", JsonConvert.SerializeObject(ex), ex);
            }

            _logger.Log(TraceIdExplore.TraceId, $"End ContractController's action get", JsonConvert.SerializeObject(resp));

            return resp;
        }
        #endregion

        #region Insert
        [HttpPost("Insert")]
        public async Task<Response<AddContractDto>> Insert(InsertContractViewModel model)
        {
            Response<AddContractDto> resp = null;

            try
            {
                _logger.Log(TraceIdExplore.TraceId, $"Start ContractController's action Insert", JsonConvert.SerializeObject(model));

                var dto = _mapper.Map<AddContractDto>(model);

                resp = await _contractService.InsertContract(dto);

                _logger.Log(TraceIdExplore.TraceId, $"End ContractController's action Insert", JsonConvert.SerializeObject(resp));
            }
            catch (Exception ex)
            {
                resp = new Response<AddContractDto>(null, StatusConstants.UnSuccess);

                _logger.Log(TraceIdExplore.TraceId, $"Exception on ContractController's action Insert", JsonConvert.SerializeObject(ex), ex);
            }

            return resp;
        }
        #endregion

        #region Edit
        [HttpPost("Edit")]
        public async Task<Response> Edit(EditContractViewModel model)
        {
            Response resp = null;

            try
            {
                _logger.Log(TraceIdExplore.TraceId, $"Start ContractController's action Edit", JsonConvert.SerializeObject(model));

                var entity = _mapper.Map<EditContractDto>(model);
                resp = await _contractService.EditContract(entity);

                _logger.Log(TraceIdExplore.TraceId, $"End ContractController's action Edit", JsonConvert.SerializeObject(resp));
            }
            catch (Exception ex)
            {
                resp = new Response(StatusConstants.UnSuccess);

                _logger.Log(TraceIdExplore.TraceId, $"Exception on ContractController's action Edit", JsonConvert.SerializeObject(ex), ex);
            }

            return resp;
        }
        #endregion

        #region ChangeState
        [HttpPost("ChangeState")]
        public async Task<Response> ChangeState(ContractChangeStateViewModel model)
        {
            Response resp = null;

            try
            {
                _logger.Log(TraceIdExplore.TraceId, $"Start ContractController's action ChangeState", JsonConvert.SerializeObject(model));

                resp = await _contractService.ChangeState(model.Id, model.StateTypeId);
            }
            catch (Exception ex)
            {
                resp = new Response<GetContractDto>(null, StatusConstants.UnSuccess);

                _logger.Log(TraceIdExplore.TraceId, $"Exception on ContractController's action ChangeState", JsonConvert.SerializeObject(ex), ex);
            }

            _logger.Log(TraceIdExplore.TraceId, $"End ContractController's action ChangeState", JsonConvert.SerializeObject(resp));

            return resp;
        }
        #endregion

        #region GetContractType
        [HttpPost("GetContractType")]
        public async Task<Response> GetContractType()
        {
            return await _contractService.GetContractStateType();
        } 
        #endregion

    }
}
