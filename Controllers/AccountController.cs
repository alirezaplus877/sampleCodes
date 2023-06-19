using Application.Services;
using AutoMapper;
using Dto.SwStar.Account;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pigi.MDbLogging;
using Presentation.webApi.Models.Account;
using System.Threading.Tasks;
using Utility;
using Utility.Constant;
using Utility.helpers;

namespace Presentation.webApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AccountController : ControllerBase, ILoggable
    {
        #region Fields
        private readonly IMdbLogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public AccountController(
            IMdbLogger<AccountController> logger, IAccountService AccountRepository, IMapper mapper)
        {
            _accountService = AccountRepository;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region Activation
        [HttpPost("Activation")]
        public async Task<Response> Activation(AccountActivationViewModel model)
        {
            Response resp = null;

            try
            {
                _logger.Log(TraceIdExplore.TraceId, $"Start AccountController's action Activation", JsonConvert.SerializeObject(model));

                resp = await _accountService.SetActiveOrDeactive(model.Id, model.Status);
            }
            catch (Exception ex)
            {
                resp = new Response<GetAccountDto>(null, StatusConstants.UnSuccess);

                _logger.Log(TraceIdExplore.TraceId, $"Exception on AccountController's action Activation", JsonConvert.SerializeObject(ex), ex);
            }

            _logger.Log(TraceIdExplore.TraceId, $"End AccountController's action Activation", JsonConvert.SerializeObject(resp));

            return resp;
        }
        #endregion

        #region Get
        [HttpPost("Get")]
        public async Task<Response<GetAccountDto>> Get(long Id)
        {
            Response<GetAccountDto> resp = null;

            try
            {
                _logger.Log(TraceIdExplore.TraceId, $"Start AccountController's action get", JsonConvert.SerializeObject(new
                {
                    Id = Id
                }));

                resp = await _accountService.GetAccount(Id);
            }
            catch (Exception ex)
            {
                resp = new Response<GetAccountDto>(null, StatusConstants.UnSuccess);

                _logger.Log(TraceIdExplore.TraceId, $"Exception on AccountController's action get", JsonConvert.SerializeObject(ex), ex);
            }

            _logger.Log(TraceIdExplore.TraceId, $"End AccountController's action get", JsonConvert.SerializeObject(resp));

            return resp;
        }
        #endregion

        #region Insert
        [HttpPost("Insert")]
        public async Task<Response<AddAccountDto>> Insert(InsertAccountViewModel model)
        {
            Response<AddAccountDto> resp = null;

            try
            {
                _logger.Log(TraceIdExplore.TraceId, $"Start AccountController's action Insert", JsonConvert.SerializeObject(model));

                var dto = _mapper.Map<AddAccountDto>(model);

                resp = await _accountService.InsertAccount(dto);

                _logger.Log(TraceIdExplore.TraceId, $"End AccountController's action Insert", JsonConvert.SerializeObject(resp));
            }
            catch (Exception ex)
            {
                resp = new Response<AddAccountDto>(null, StatusConstants.UnSuccess);

                _logger.Log(TraceIdExplore.TraceId, $"Exception on AccountController's action Insert", JsonConvert.SerializeObject(ex), ex);
            }

            return resp;
        }
        #endregion

        #region Edit
        [HttpPost("Edit")]
        public async Task<Response> Edit(EditAccountViewModel model)
        {
            Response resp = null;

            try
            {
                _logger.Log(TraceIdExplore.TraceId, $"Start AccountController's action Edit", JsonConvert.SerializeObject(model));

                var entity = _mapper.Map<EditAccountDto>(model);
                resp = await _accountService.EditAccount(entity);

                _logger.Log(TraceIdExplore.TraceId, $"End AccountController's action Edit", JsonConvert.SerializeObject(resp));
            }
            catch (Exception ex)
            {
                resp = new Response(StatusConstants.UnSuccess);

                _logger.Log(TraceIdExplore.TraceId, $"Exception on AccountController's action Edit", JsonConvert.SerializeObject(ex), ex);
            }

            return resp;
        }
        #endregion

        [HttpPost("GetAccountType")]
        public async Task<Response> GetAccountType()
        {
            return await _accountService.GetAllAccountType();
        }
    }
}

