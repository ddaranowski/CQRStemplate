using CQRSFluentAndAutomapper.Models;
using CQRSMediatR.Api.DTOs;
using MediatR;

namespace CQRSMediatR.Api.Application.Flows.Queries;


public record CreateFlowRequest(
    string Name, 
    string ApplicationId,
    List<ChannelDto> Channels) 
    : IRequest;