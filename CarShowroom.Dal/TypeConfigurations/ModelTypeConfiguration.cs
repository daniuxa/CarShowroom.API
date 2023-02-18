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
    /// Fluent api configuration of model entity
    /// </summary>
    public class ModelTypeConfiguration : IEntityTypeConfiguration<Model>
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasOne(x => x.Brand).WithMany(y => y.Models).OnDelete(DeleteBehavior.Restrict);
        }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
