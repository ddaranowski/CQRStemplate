using System.Data;
using CQRSMediatR.Api.Infractructure;

namespace CQRSFluentAndAutomapper.Models
{
    public class Flow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ApplicationId { get; set; }

        public List<Channel> Channels { get; set; } 
    }
}
