using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CQRSFluentAndAutomapper.Models
{
    public class Flow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Channel> Channels { get; private set; }
    }


    public class FlowConfiguration : IEntityTypeConfiguration<Flow>
    {
        public void Configure(EntityTypeBuilder<Flow> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasMany(u => u.Channels)
                .WithOne()
                .HasForeignKey(r => r.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
