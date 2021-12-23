#pragma warning disable IDE0073 // The file header is missing or not located at the top of the file
/** THIS IS AUTOGENERATED BY CONJURE EFX **/
#pragma warning restore IDE0073 // The file header is missing or not located at the top of the file

using System;
using System.Collections.Generic;

namespace Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Entities
{
    /// <summary>
    /// Entity class representing data for table 'aspnet_Applications'
    /// </summary>
    public partial class AspnetApplication
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AspnetApplication"/> class.
        /// </summary>
        public AspnetApplication()
        {
            #region Generated Constructor

            AspnetMemberships = new HashSet<AspnetMembership>();
            AspnetRoles = new HashSet<AspnetRole>();
            AspnetUsers = new HashSet<AspnetUser>();

            #endregion // Generated Constructor
        }

        #region Generated Properties

        /// <summary>
        /// Gets or sets the property value representing column 'ApplicationName'.
        /// </summary>
        /// <value>
        /// The property value representing column 'ApplicationName'.
        /// </value>
        public string ApplicationName { get; set; } = default!;

        /// <summary>
        /// Gets or sets the property value representing column 'LoweredApplicationName'.
        /// </summary>
        /// <value>
        /// The property value representing column 'LoweredApplicationName'.
        /// </value>
        public string LoweredApplicationName { get; set; } = default!;

        /// <summary>
        /// Gets or sets the property value representing column 'ApplicationId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'ApplicationId'.
        /// </value>
        public Guid ApplicationId { get; set; }

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
        /// Gets or sets the navigation collection for entity <see cref="AspnetMembership" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="AspnetMembership" />.
        /// </value>
        public virtual ICollection<AspnetMembership> AspnetMemberships { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="AspnetRole" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="AspnetRole" />.
        /// </value>
        public virtual ICollection<AspnetRole> AspnetRoles { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="AspnetUser" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="AspnetUser" />.
        /// </value>
        public virtual ICollection<AspnetUser> AspnetUsers { get; set; }

        #endregion // Generated Relationships
    }
}
