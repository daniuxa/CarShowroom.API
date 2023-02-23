using CarShowroom.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarShowroom.Dal.TypeConfigurations
{
    /// <summary>
    /// Fluent api configuration of equipment entity
    /// </summary>
    public class EquipmentTypeConfiguration : IEntityTypeConfiguration<Equipment>
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasOne(x => x.Model).WithMany(y => y.Equipments).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Engine).WithMany(y => y.Equipments).OnDelete(DeleteBehavior.Restrict);
            builder.HasCheckConstraint("CK_Equipment_Price", "Price >= 0");

        }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
