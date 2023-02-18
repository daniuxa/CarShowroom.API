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
    public class EngineTypeConfiguration : IEntityTypeConfiguration<Engine>
    {
        /// <summary>
        /// Fluent api configuration of engine entity
        /// </summary>
        public void Configure(EntityTypeBuilder<Engine> builder)
        {
            builder.HasOne(x => x.Company).WithMany(y => y.Engines).OnDelete(DeleteBehavior.Cascade);
            builder.HasCheckConstraint("CK_Engine_EngineCapacity", "EngineCapacity > -1 AND EngineCapacity < 1000000");
            builder.HasCheckConstraint("CK_Engine_Power", "Power > -1 AND Power < 2000000");
        }
    }
}
