using CQRSFluentAndAutomapper.Models;
using CQRSMediatR.Api.Application;
using CQRSMediatR.Api.Application.Flows.Queries;
using CQRSMediatR.Api.DTOs;
using CQRSMediatR.Api.Infractructure;
using CQRSMediatR.Api.Services;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSFluentAndAutomapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlowsController : ControllerBase
    {
     
        private readonly ILogger<FlowsController> _logger;
        private readonly IFlowService _flowService;
        private readonly IMediator _mediator;
        private readonly IValidator<CreateFlowRequest> _validator;

        public FlowsController(ILogger<FlowsController> logger, 
            IFlowService flowService, 
            IMediator mediator, IValidator<CreateFlowRequest> validator)
        {
            _logger = logger;
            _flowService = flowService;
            _mediator = mediator;
            _validator = validator;
        }


        
        [HttpGet(Name = "GetFlows")]
        public async Task<IEnumerable<Flow>> Get()
        {
            var allFlows = await _flowService.GetAllFlows();
            return allFlows;
        }


        [HttpPost]

        public async Task<ActionResult> CreateNewFlow([FromBody] CreateFlowRequest flowRequest)
        {
            ValidationResult result = await _validator.ValidateAsync(flowRequest);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            await _mediator.Send(flowRequest);

            return Created();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FlowDto>> GetFlow(int id)
        {
            var query = new GetFlowByIdRequest { FlowId = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }


    // Handler
}
