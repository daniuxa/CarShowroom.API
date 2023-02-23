using CarShowroom.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarShowroom.Dal.TypeConfigurations
{
    /// <summary>
    /// Fluent api configuration of automobile entity
    /// </summary>
    public class AutomobileTypeConfiguration : IEntityTypeConfiguration<Automobile>
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public void Configure(EntityTypeBuilder<Automobile> builder)
        {
            builder.HasOne(x => x.Brand).WithMany(y => y.Automobiles).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Model).WithMany(y => y.Automobiles).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Equipment).WithMany(y => y.Automobiles).OnDelete(DeleteBehavior.Restrict);
        }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
