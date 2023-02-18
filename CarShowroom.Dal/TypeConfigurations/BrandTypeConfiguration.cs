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
    /// <summary>
    /// Fluent api configuration of brand entity
    /// </summary>
    public class BrandTypeConfiguration : IEntityTypeConfiguration<Brand>
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasOne(x => x.Company).WithMany(y => y.Brands).OnDelete(DeleteBehavior.Cascade);
        }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
