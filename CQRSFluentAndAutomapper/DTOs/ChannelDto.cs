using CQRSFluentAndAutomapper.Models;

namespace CQRSMediatR.Api.DTOs;

public class ChannelDto
{
    public ChannelEnum ChannelType { get; set; }

    public CountryEnum Country { get; set; }

    public int Priority { get; set; }
}