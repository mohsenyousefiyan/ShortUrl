using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using ShortUrlAddress.Core.Entities.Entities;
using ShortUrlAddress.Infrastructures.DAL.EfCore.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShortUrlAddress.Infrastructures.DAL.EfCore.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UrlInfo> UrlInfos { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UrlInfoConfiguration());
        }

     
    }
}
