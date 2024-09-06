using CQRSMediatR.Api.DTOs;
using CQRSMediatR.Api.Services;
using MediatR;

namespace CQRSMediatR.Api.Application.Flows.Queries;

public class GetFlowByIdHandler : IRequestHandler<GetFlowByIdRequest, FlowDto>
{
    private readonly IFlowService _flowService;

    public GetFlowByIdHandler(IFlowService flowService)
    {
        _flowService = flowService;
    }

    public async Task<FlowDto> Handle(GetFlowByIdRequest request, CancellationToken cancellationToken)
    {
        var flow = await _flowService.GetFlowById(request.FlowId);

        if (flow == null)
            return null;

        return new FlowDto
        {
            Name = flow.Name,
            ApplicationId = flow.ApplicationId,
            Channels = flow.Channels.Select(channel => new ChannelDto
            {
                ChannelType = channel.ChannelType,
                Country = channel.Country,
                Priority = channel.Priority
            }).ToList()
        };
    }


}