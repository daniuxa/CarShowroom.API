using CarShowroom.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarShowroom.Dal.TypeConfigurations
{
    /// <summary>
    /// Fluent api configuration of engine entity
    /// </summary>
    public class EngineTypeConfiguration : IEntityTypeConfiguration<Engine>
    {

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public void Configure(EntityTypeBuilder<Engine> builder)
        {
            builder.HasOne(x => x.Company).WithMany(y => y.Engines).OnDelete(DeleteBehavior.Cascade);
            builder.HasCheckConstraint("CK_Engine_EngineCapacity", "EngineCapacity > -1 AND EngineCapacity < 1000000");
            builder.HasCheckConstraint("CK_Engine_Power", "Power > -1 AND Power < 2000000");
        }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
