namespace CQRSMediatR.Api.DTOs;

public class FlowDto
{
    public string Name { get; set; }
    public string ApplicationId { get; set; }
    public List<ChannelDto> Channels { get; set; }

}