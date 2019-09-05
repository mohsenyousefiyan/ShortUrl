using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShortUrlAddress.Core.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrlAddress.Infrastructures.DAL.EfCore.Configs
{
    public class UrlInfoConfiguration : IEntityTypeConfiguration<UrlInfo>
    {
        public void Configure(EntityTypeBuilder<UrlInfo> builder)
        {
            builder.ToTable("Tbl_UrlInfo");

            #region PropertyConfigs

            builder.HasKey(x => x.Id)
               .HasName("ID");

            builder.Property(x => x.ClientIPAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
           
            builder.Property<int>("ViewCount");

            builder.HasIndex(x => x.ShortUrlCode)
                .HasName("IX_ShortUrlCode");

            #endregion
        }
    }
}
