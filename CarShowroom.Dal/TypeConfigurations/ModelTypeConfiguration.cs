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
    public class ModelTypeConfiguration : IEntityTypeConfiguration<Model>
    {
        /// <summary>
        /// Fluent api configuration of model entity
        /// </summary>
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasOne(x => x.Brand).WithMany(y => y.Models).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
