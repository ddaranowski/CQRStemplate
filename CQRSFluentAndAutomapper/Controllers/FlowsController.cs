using CQRSFluentAndAutomapper.Models;
using Microsoft.AspNetCore.Mvc;

namespace CQRSFluentAndAutomapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlowsController : ControllerBase
    {
     
        private readonly ILogger<FlowsController> _logger;
        private readonly IFlowService _flowService;

        public FlowsController(ILogger<FlowsController> logger, 
            IFlowService flowService)
        {
            _logger = logger;
            _flowService = flowService;
        }

        [HttpGet(Name = "GetFlows")]
        public async Task<IEnumerable<Flow>> Get()
        {
            var allFlows = await _flowService.GetAllFlows();
            return allFlows;
        }


        [HttpPost]
        public async Task<ActionResult> CreateNewFlow([FromBody] FlowDto flowRequest)
        {
            var newFlow = new Flow()
            {
                Name = flowRequest.Name
            };

            await _flowService.AddFlow(newFlow);

            return Created();
        }


        public class FlowDto
        {
            public string Name { get; set; }
        }
    }
}
