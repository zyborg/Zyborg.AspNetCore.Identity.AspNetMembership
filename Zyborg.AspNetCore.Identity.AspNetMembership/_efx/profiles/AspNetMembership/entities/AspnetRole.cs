#pragma warning disable IDE0073 // The file header is missing or not located at the top of the file
/** THIS IS AUTOGENERATED BY CONJURE EFX **/
#pragma warning restore IDE0073 // The file header is missing or not located at the top of the file

using System;
using System.Collections.Generic;

namespace Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Entities
{
    /// <summary>
    /// Entity class representing data for table 'aspnet_Roles'
    /// </summary>
    public partial class AspnetRole
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AspnetRole"/> class.
        /// </summary>
        public AspnetRole()
        {
            #region Generated Constructor

            AspnetUsersInRoles = new HashSet<AspnetUsersInRole>();

            #endregion // Generated Constructor
        }

        #region Generated Properties

        /// <summary>
        /// Gets or sets the property value representing column 'ApplicationId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'ApplicationId'.
        /// </value>
        public Guid ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'RoleId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'RoleId'.
        /// </value>
        public Guid RoleId { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'RoleName'.
        /// </summary>
        /// <value>
        /// The property value representing column 'RoleName'.
        /// </value>
        public string RoleName { get; set; } = default!;

        /// <summary>
        /// Gets or sets the property value representing column 'LoweredRoleName'.
        /// </summary>
        /// <value>
        /// The property value representing column 'LoweredRoleName'.
        /// </value>
        public string LoweredRoleName { get; set; } = default!;

        /// <summary>
        /// Gets or sets the property value representing column 'Description'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Description'.
        /// </value>
        public string? Description { get; set; }

        #endregion // Generated Properties

        #region Generated Relationships

        /// <summary>
        /// Gets or sets the navigation property for entity <see cref="AspnetApplication" />.
        /// </summary>
        /// <value>
        /// The the navigation property for entity <see cref="AspnetApplication" />.
        /// </value>
        /// <seealso cref="ApplicationId" />
        public AspnetApplication? AspnetApplication { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="AspnetUsersInRole" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="AspnetUsersInRole" />.
        /// </value>
        public virtual ICollection<AspnetUsersInRole> AspnetUsersInRoles { get; set; }

        #endregion // Generated Relationships
    }
}