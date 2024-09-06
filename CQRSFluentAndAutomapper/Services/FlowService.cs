using CQRSFluentAndAutomapper.Models;
using CQRSMediatR.Api.Infractructure;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatR.Api.Services;

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

    public async Task<Flow?> GetFlowById(int flowId)
    {
        return await _dbContext.Flows
             .Include(f => f.Channels)
             .FirstOrDefaultAsync(f => f.Id == flowId);

    }
}