#pragma warning disable IDE0073 // The file header is missing or not located at the top of the file
/** THIS IS AUTOGENERATED BY CONJURE EFX **/
#pragma warning restore IDE0073 // The file header is missing or not located at the top of the file

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Entities.AspnetApplication" />
    /// </summary>
    public partial class AspnetApplicationMap
        : IEntityTypeConfiguration<Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Entities.AspnetApplication>
    {
        /// <summary>
        /// Configures the entity of type <see cref="Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Entities.AspnetApplication" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Entities.AspnetApplication> builder)
        {
            #region Generated Configure

            // table
            builder.ToTable("aspnet_Applications", "dbo");

            // key
            builder.HasKey(t => t.ApplicationId);

            // properties
            builder.Property(t => t.ApplicationName)
                .IsRequired()
                .HasColumnName("ApplicationName")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256)
                ;
            builder.Property(t => t.LoweredApplicationName)
                .IsRequired()
                .HasColumnName("LoweredApplicationName")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256)
                ;
            builder.Property(t => t.ApplicationId)
                .IsRequired()
                .HasColumnName("ApplicationId")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newid())")
                ;
            builder.Property(t => t.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256)
                ;

            // relationships

            #endregion // Generated Configure
        }
    }
}