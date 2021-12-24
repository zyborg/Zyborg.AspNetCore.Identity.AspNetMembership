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

    public DateTime? LastActivityDate { get; set; }

    public bool IsApproved { get; set; }

    public bool IsLockedOut { get; set; }

    public DateTime? CreateDate { get; set; }
    public DateTime? LastLoginDate { get; set; }
    public DateTime? LastPasswordChangedDate{ get; set; }
    public DateTime? LastLockoutDate { get; set; }

    public int? FailedPasswordAttemptCount { get; set; }
    public DateTime? FailedPasswordAttemptWindowStart { get; set; }

    public string? Comment { get; set; }
}
