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
        /// <summary>
        /// Fluent api configuration of equipment entity
        /// </summary>
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasOne(x => x.Model).WithMany(y => y.Equipments).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Engine).WithMany(y => y.Equipments).OnDelete(DeleteBehavior.Restrict);
            builder.HasCheckConstraint("CK_Equipment_Price", "Price >= 0");

        }
    }
}
