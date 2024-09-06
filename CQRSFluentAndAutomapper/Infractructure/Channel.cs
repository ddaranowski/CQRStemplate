using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CQRSFluentAndAutomapper.Models;

namespace CQRSMediatR.Api.Infractructure;

public class Channel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id { get; set; }
    public ChannelEnum ChannelType { get; set; }

    public CountryEnum Country { get; set; }

    public int Priority { get; set; }
    public int FlowId { get; set; }
}