#pragma warning disable IDE0073 // The file header is missing or not located at the top of the file
/** THIS IS AUTOGENERATED BY CONJURE EFX **/
#pragma warning restore IDE0073 // The file header is missing or not located at the top of the file

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Entities.AspnetUsersInRole" />
    /// </summary>
    public partial class AspnetUsersInRoleMap
        : IEntityTypeConfiguration<Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Entities.AspnetUsersInRole>
    {
        /// <summary>
        /// Configures the entity of type <see cref="Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Entities.AspnetUsersInRole" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Entities.AspnetUsersInRole> builder)
        {
            #region Generated Configure

            // table
            builder.ToTable("aspnet_UsersInRoles", "dbo");

            // key
            builder.HasKey(t => new {
                t.UserId,
                t.RoleId
            });
            

            // properties
            builder.Property(t => t.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasColumnType("uniqueidentifier")
                ;
            builder.Property(t => t.RoleId)
                .IsRequired()
                .HasColumnName("RoleId")
                .HasColumnType("uniqueidentifier")
                ;

            // relationships
            builder.HasOne(t => t.AspnetRole)
                .WithMany(t => t.AspnetUsersInRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__aspnet_Us__RoleI__4E88ABD4")
                ;
            builder.HasOne(t => t.AspnetUser)
                .WithMany(t => t.AspnetUsersInRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__aspnet_Us__UserI__4D94879B")
                ;

            #endregion // Generated Configure
        }
    }
}
