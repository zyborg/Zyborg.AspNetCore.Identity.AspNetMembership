#pragma warning disable IDE0073 // The file header is missing or not located at the top of the file
/** THIS IS AUTOGENERATED BY CONJURE EFX **/
#pragma warning restore IDE0073 // The file header is missing or not located at the top of the file

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Entities.AspnetRole" />
    /// </summary>
    public partial class AspnetRoleMap
        : IEntityTypeConfiguration<Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Entities.AspnetRole>
    {
        /// <summary>
        /// Configures the entity of type <see cref="Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Entities.AspnetRole" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Entities.AspnetRole> builder)
        {
            #region Generated Configure

            // table
            builder.ToTable("aspnet_Roles", "dbo");

            // key
            builder.HasKey(t => t.RoleId);

            // properties
            builder.Property(t => t.ApplicationId)
                .IsRequired()
                .HasColumnName("ApplicationId")
                .HasColumnType("uniqueidentifier")
                ;
            builder.Property(t => t.RoleId)
                .IsRequired()
                .HasColumnName("RoleId")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newid())")
                ;
            builder.Property(t => t.RoleName)
                .IsRequired()
                .HasColumnName("RoleName")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256)
                ;
            builder.Property(t => t.LoweredRoleName)
                .IsRequired()
                .HasColumnName("LoweredRoleName")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256)
                ;
            builder.Property(t => t.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256)
                ;

            // relationships
            builder.HasOne(t => t.AspnetApplication)
                .WithMany(t => t.AspnetRoles)
                .HasForeignKey(d => d.ApplicationId)
                .HasConstraintName("FK__aspnet_Ro__Appli__49C3F6B7")
                ;

            #endregion // Generated Configure
        }
    }
}
