// Zyborg ASP.NET Core Identity Storage Provider for ASP.NET Membership Database.
// Copyright (C) Zyborg.

namespace Zyborg.AspNetCore.Identity.AspNetMembership;

public class MembershipRole
{
    public MembershipRole(Guid roleId, string roleName)
    {
        RoleId = roleId;
        RoleName = roleName;
    }

    public Guid RoleId { get; }

    public string RoleName { get; }
}
