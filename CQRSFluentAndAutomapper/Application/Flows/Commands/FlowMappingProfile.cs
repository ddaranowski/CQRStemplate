using AutoMapper;
using CQRSFluentAndAutomapper.Models;
using CQRSMediatR.Api.DTOs;
using CQRSMediatR.Api.Infractructure;

namespace CQRSMediatR.Api.Application.Flows.Queries;

public class FlowMappingProfile : Profile
{
    public FlowMappingProfile()
    {
        // Define mapping from CreateFlowRequest to Flow
        CreateMap<CreateFlowRequest, Flow>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ApplicationId, opt => opt.MapFrom(src => src.ApplicationId))
            .ForMember(dest => dest.Channels, opt => opt.MapFrom(src => src.Channels));

        // Define mapping from ChannelDto to Channel
        CreateMap<ChannelDto, Channel>();

        CreateMap<Flow, FlowDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ApplicationId, opt => opt.MapFrom(src => src.ApplicationId))
            .ForMember(dest => dest.Channels, opt => opt.MapFrom(src => src.Channels));

        // Mapping from Channel to ChannelDto
        CreateMap<Channel, ChannelDto>();
    }
}