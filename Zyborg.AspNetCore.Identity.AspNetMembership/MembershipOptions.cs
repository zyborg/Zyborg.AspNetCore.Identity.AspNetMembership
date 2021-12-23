// Zyborg ASP.NET Core Identity Storage Provider for ASP.NET Membership Database.
// Copyright (C) Zyborg.

namespace Zyborg.AspNetCore.Identity.AspNetMembership;

public class MembershipOptions
{
    public string? ApplicationName { get; set; }

    public string? LoweredApplicationName => ApplicationName?.ToLower();
}
