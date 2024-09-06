namespace CQRSFluentAndAutomapper.Models;

public interface IFlowService
{
    Task<int> AddFlow(Flow flow);
    Task<List<Flow>> GetAllFlows(); 
}