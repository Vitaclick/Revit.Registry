﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Reg.Domain.Entities;

namespace Reg.DataAccess.Contexts
{
  public class RegDbContext : DbContext
  {
    public DbSet<Project> Projects { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Log> Logs { get; set; }
    public RegDbContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      var connection =
        @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RegTest;Integrated Security=True;Pooling=False";
      builder.UseSqlServer(connection);
    }

    // TODO: logging that model was delete instead
    // delete logs if corresponding model was removed
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Model>()
        .HasMany<Log>(m => m.Logs)
        .WithOne(l => l.Model)
        .HasForeignKey(l => l.ModelId)
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
