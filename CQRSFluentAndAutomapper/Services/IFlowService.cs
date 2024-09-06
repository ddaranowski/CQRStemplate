using CQRSFluentAndAutomapper.Models;

namespace CQRSMediatR.Api.Services;

public interface IFlowService
{
    Task<int> AddFlow(Flow flow);
    Task<List<Flow>> GetAllFlows();
    Task<Flow?> GetFlowById(int flowId);
}