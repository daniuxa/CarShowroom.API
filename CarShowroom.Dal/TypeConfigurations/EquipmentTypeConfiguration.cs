using CarShowroom.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Dal.TypeConfigurations
{
    public class EquipmentTypeConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasOne(x => x.Model).WithMany(y => y.Equipments);
            builder.HasOne(x => x.Engine).WithMany(y => y.Equipments);
            builder.HasCheckConstraint("CK_Equipment_Price", "EngineCapacity >= 0");

        }
    }
}
