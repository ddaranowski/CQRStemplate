using CQRSFluentAndAutomapper.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRSMediatR.Api.Infractructure;

public class FlowConfiguration : IEntityTypeConfiguration<Flow>
{
    public void Configure(EntityTypeBuilder<Flow> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasMany(u => u.Channels)
            .WithOne()
            .HasForeignKey(r => r.FlowId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}