#pragma warning disable IDE0073 // The file header is missing or not located at the top of the file
/** THIS IS AUTOGENERATED BY CONJURE EFX **/
#pragma warning restore IDE0073 // The file header is missing or not located at the top of the file

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Entities.AspnetUser" />
    /// </summary>
    public partial class AspnetUserMap
        : IEntityTypeConfiguration<Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Entities.AspnetUser>
    {
        /// <summary>
        /// Configures the entity of type <see cref="Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Entities.AspnetUser" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Entities.AspnetUser> builder)
        {
            #region Generated Configure

            // table
            builder.ToTable("aspnet_Users", "dbo");

            // key
            builder.HasKey(t => t.UserId);

            // properties
            builder.Property(t => t.ApplicationId)
                .IsRequired()
                .HasColumnName("ApplicationId")
                .HasColumnType("uniqueidentifier")
                ;
            builder.Property(t => t.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newid())")
                ;
            builder.Property(t => t.UserName)
                .IsRequired()
                .HasColumnName("UserName")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256)
                ;
            builder.Property(t => t.LoweredUserName)
                .IsRequired()
                .HasColumnName("LoweredUserName")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256)
                ;
            builder.Property(t => t.MobileAlias)
                .HasColumnName("MobileAlias")
                .HasColumnType("nvarchar(16)")
                .HasMaxLength(16)
                ;
            builder.Property(t => t.IsAnonymous)
                .IsRequired()
                .HasColumnName("IsAnonymous")
                .HasColumnType("bit")
                ;
            builder.Property(t => t.LastActivityDate)
                .IsRequired()
                .HasColumnName("LastActivityDate")
                .HasColumnType("datetime")
                ;

            // relationships
            builder.HasOne(t => t.AspnetApplication)
                .WithMany(t => t.AspnetUsers)
                .HasForeignKey(d => d.ApplicationId)
                .HasConstraintName("FK__aspnet_Us__Appli__1B0907CE")
                ;

            #endregion // Generated Configure
        }
    }
}
