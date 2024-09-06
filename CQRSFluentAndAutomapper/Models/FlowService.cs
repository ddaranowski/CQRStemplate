using Microsoft.EntityFrameworkCore;

namespace CQRSFluentAndAutomapper.Models;

public class FlowService : IFlowService
{
    public readonly AppDbContext _dbContext;

    public FlowService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<List<Flow>> GetAllFlows()
    {
        return await _dbContext.Flows
            .Include(flow => flow.Channels).ToListAsync();

    }

    public async Task<int> AddFlow(Flow flow)
    {
        await _dbContext.Flows.AddAsync(flow);
        return await _dbContext.SaveChangesAsync();
    }
}