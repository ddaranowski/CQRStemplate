using CQRSMediatR.Api.DTOs;
using MediatR;

namespace CQRSMediatR.Api.Application.Flows.Queries;

public class GetFlowByIdRequest : IRequest<FlowDto>
{
    public int FlowId { get; set; }
}