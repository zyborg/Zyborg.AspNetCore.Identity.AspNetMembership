// Zyborg ASP.NET Core Identity Storage Provider for ASP.NET Membership Database.
// Copyright (C) Zyborg.

namespace Zyborg.AspNetCore.Identity.AspNetMembership;

public class MembershipUser
{
    public MembershipUser(Guid userId, string userName)
    {
        UserId = userId;
        UserName = userName;
    }

    public Guid UserId { get; }

    public string UserName { get; }

    public string? PasswordHash { get; set; }

    public string? Email { get; set; }
}
