#pragma warning disable IDE0073 // The file header is missing or not located at the top of the file
/** THIS IS AUTOGENERATED BY CONJURE EFX **/
#pragma warning restore IDE0073 // The file header is missing or not located at the top of the file

using System;
using System.Collections.Generic;

namespace Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Entities
{
    /// <summary>
    /// Entity class representing data for table 'vw_aspnet_UsersInRoles'
    /// </summary>
    public partial class VwAspnetUsersInRole
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VwAspnetUsersInRole"/> class.
        /// </summary>
        public VwAspnetUsersInRole()
        {
            #region Generated Constructor


            #endregion // Generated Constructor
        }

        #region Generated Properties

        /// <summary>
        /// Gets or sets the property value representing column 'UserId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'UserId'.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'RoleId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'RoleId'.
        /// </value>
        public Guid RoleId { get; set; }

        #endregion // Generated Properties

        #region Generated Relationships

        #endregion // Generated Relationships
    }
}
