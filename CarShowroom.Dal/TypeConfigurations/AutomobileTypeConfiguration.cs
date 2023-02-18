﻿using CarShowroom.Dal.Entities;
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
    /// Fluent api configuration of automobile entity
    /// </summary>
    public class AutomobileTypeConfiguration : IEntityTypeConfiguration<Automobile>
    {
        public void Configure(EntityTypeBuilder<Automobile> builder)
        {
            builder.HasOne(x => x.Brand).WithMany(y => y.Automobiles).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Model).WithMany(y => y.Automobiles).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Equipment).WithMany(y => y.Automobiles).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
