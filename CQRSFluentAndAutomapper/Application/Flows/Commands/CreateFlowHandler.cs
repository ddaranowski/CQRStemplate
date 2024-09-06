using AutoMapper;
using CQRSFluentAndAutomapper.Models;
using CQRSMediatR.Api.Infractructure;
using CQRSMediatR.Api.Services;
using MediatR;

namespace CQRSMediatR.Api.Application.Flows.Queries;

public class CreateFlowHandler : IRequestHandler<CreateFlowRequest>
{
    private readonly IFlowService _flowService;
    private readonly IMapper _mapper;

    public CreateFlowHandler(IFlowService flowService, IMapper mapper)
    {
        _flowService = flowService;
        _mapper = mapper;
    }

 

    public async Task Handle(CreateFlowRequest flowRequest, CancellationToken cancellationToken)
    {
        //var newFlow = new Flow()
        //{
        //    Name = flowRequest.Name,
        //    ApplicationId = flowRequest.ApplicationId,
        //    Channels = flowRequest.Channels.Select(channel =>
        //        new Channel
        //        {
        //            ChannelType = channel.ChannelType,
        //            Country = channel.Country,
        //            Priority = channel.Priority
        //        }).ToList()
        //};

        var newFlow = _mapper.Map<Flow>(flowRequest);

        await _flowService.AddFlow(newFlow);
    }
}