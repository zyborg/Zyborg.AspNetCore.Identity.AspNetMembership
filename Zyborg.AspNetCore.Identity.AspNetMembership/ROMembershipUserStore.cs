// Zyborg ASP.NET Core Identity Storage Provider for ASP.NET Membership Database.
// Copyright (C) Zyborg.

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data;
using Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data.Entities;

namespace Zyborg.AspNetCore.Identity.AspNetMembership;

/// <summary>
/// Implements a read-only Identity UserStore over an ASP.NET Membership data store.
/// </summary>
public class ROMembershipUserStore : IUserPasswordStore<MembershipUser>,
    IUserRoleStore<MembershipUser>
{
    private readonly AspNetMembershipContext _db;
    private readonly MembershipOptions _options;

    public ROMembershipUserStore(AspNetMembershipContext db, MembershipOptions options)
    {
        _db = db;
        _options = options;
    }

    public void Dispose()
    {
        _db.Dispose();
    }

    private MembershipUser Convert(AspnetUser dbUser, AspnetMembership? dbMemb)
    {
        if (dbMemb == null)
        {
            return new MembershipUser(dbUser.UserId, dbUser.UserName)
            {
                LastActivityDate = dbUser.LastActivityDate,
            };
        }

        var passwordHash = $"{dbMemb.PasswordSalt}:{dbMemb.Password}";

        return new MembershipUser(dbUser.UserId, dbUser.UserName)
        {
            PasswordHash = passwordHash,
            Email = dbMemb.Email,
            LastActivityDate = dbUser.LastActivityDate,
            IsApproved = dbMemb.IsApproved,
            IsLockedOut = dbMemb.IsLockedOut,
            CreateDate = dbMemb.CreateDate,
            LastLoginDate = dbMemb.LastLoginDate,
            LastPasswordChangedDate = dbMemb.LastPasswordChangedDate,
            LastLockoutDate = dbMemb.LastLockoutDate,
            FailedPasswordAttemptCount = dbMemb.FailedPasswordAttemptCount,
            FailedPasswordAttemptWindowStart = dbMemb.FailedPasswordAttemptWindowStart,
            Comment = dbMemb.Comment,
        };
    }

    public Task<IdentityResult> CreateAsync(MembershipUser user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException("the read-only user store does not support write operations");

        ////cancellationToken.ThrowIfCancellationRequested();
        ////ArgumentNullException.ThrowIfNull(user);

        ////throw new NotImplementedException();

        ////// Start of Creating User support

        //////var app = _options.ApplicationName == null
        //////    ? _db.AspnetApplications.FirstOrDefault()
        //////    : _db.AspnetApplications.FirstOrDefault(x => x.LoweredApplicationName == _options.LoweredApplicationName);

        //////if (app == null)
        //////{
        //////    app = new AspnetApplication
        //////    {
        //////        ApplicationName = _options.ApplicationName ?? String.Empty,
        //////        LoweredApplicationName = _options.LoweredApplicationName ?? String.Empty,
        //////    };
        //////}

        //////string? password = null;
        //////string? passwordSalt = null;
        //////if (user.PasswordHash != null)
        //////{
        //////    var passparts = user.PasswordHash.Split(":");
        //////}

        //////var dbUser = new AspnetUser
        //////{
        //////    AspnetApplication = app,
        //////    UserName = user.UserName,
        //////    LoweredUserName = user.UserName.ToLower(),
        //////};

        //////var dbMemb = new AspnetMembership
        //////{
        //////    AspnetApplication= app,
        //////    AspnetUser = dbUser,
        //////    CreateDate = DateTime.UtcNow,
        //////    Password = password,
        //////    PasswordSalt = passwordSalt,
        //////}
    }

    public Task<IdentityResult> DeleteAsync(MembershipUser user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException("the read-only user store does not support write operations");
    }

    public async Task<MembershipUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        var guid = Guid.Parse(userId);

        var app = _options.ApplicationName == null
            ? await _db.AspnetApplications.FirstOrDefaultAsync(
                cancellationToken: cancellationToken)
            : await _db.AspnetApplications.FirstOrDefaultAsync(
                x => x.LoweredApplicationName == _options.LoweredApplicationName,
                cancellationToken: cancellationToken);

        var dbUser = await _db.AspnetUsers
            .Include(x => x.AspnetMembership)
            .FirstOrDefaultAsync(x => x.AspnetApplication == app && x.UserId == guid,
                cancellationToken: cancellationToken);

        if (dbUser == null)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.
        }

        return Convert(dbUser, dbUser.AspnetMembership);
    }

    public async Task<MembershipUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        // ANC Identity uses UPPER normalization but AN Membership uses LOWER
        normalizedUserName = normalizedUserName.ToLower();

        var app = _options.ApplicationName == null
            ? await _db.AspnetApplications.FirstOrDefaultAsync(
                cancellationToken: cancellationToken)
            : await _db.AspnetApplications.FirstOrDefaultAsync(
                x => x.LoweredApplicationName == _options.LoweredApplicationName,
                cancellationToken: cancellationToken);

        var dbUser = await _db.AspnetUsers
            .Include(x => x.AspnetMembership)
            .FirstOrDefaultAsync(x => x.AspnetApplication == app && x.LoweredUserName == normalizedUserName,
                cancellationToken: cancellationToken);

        if (dbUser == null)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.
        }

        var memb = dbUser.AspnetMembership;
        var passwordHash = $"{memb!.PasswordSalt}:{memb.Password}";

        return new MembershipUser(dbUser.UserId, dbUser.UserName)
        {
            PasswordHash = passwordHash,
            Email = memb.Email,
        };
    }

    public Task<string> GetNormalizedUserNameAsync(MembershipUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.UserName.ToLower());
    }

    public Task<string> GetUserIdAsync(MembershipUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.UserId.ToString());
    }

    public Task<string> GetUserNameAsync(MembershipUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.UserName);
    }

    public Task SetNormalizedUserNameAsync(MembershipUser user, string normalizedName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException("the read-only user store does not support write operations");
    }

    public Task SetUserNameAsync(MembershipUser user, string userName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException("the read-only user store does not support write operations");
    }

    public Task<IdentityResult> UpdateAsync(MembershipUser user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException("the read-only user store does not support write operations");
    }

    public Task SetPasswordHashAsync(MembershipUser user, string passwordHash, CancellationToken cancellationToken)
    {
        throw new NotImplementedException("the read-only user store does not support write operations");
    }

    public Task<string?> GetPasswordHashAsync(MembershipUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.PasswordHash);
    }

    public Task<bool> HasPasswordAsync(MembershipUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
    }

    Task IUserRoleStore<MembershipUser>.AddToRoleAsync(MembershipUser user, string roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException("the read-only user store does not support write operations");
    }

    Task IUserRoleStore<MembershipUser>.RemoveFromRoleAsync(MembershipUser user, string roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException("the read-only user store does not support write operations");
    }

    async Task<IList<string>> IUserRoleStore<MembershipUser>.GetRolesAsync(MembershipUser user, CancellationToken cancellationToken)
    {
        return await _db.AspnetUsersInRoles
            .Include(x => x.AspnetRole)
            .Where(x => x.UserId == user.UserId)
            .Select(x => x.AspnetRole!.RoleName)
            .ToListAsync();
    }

    async Task<bool> IUserRoleStore<MembershipUser>.IsInRoleAsync(MembershipUser user, string roleName, CancellationToken cancellationToken)
    {
        return await _db.AspnetUsersInRoles
            .Include(x => x.AspnetRole)
            .Where(x => x.UserId == user.UserId && x.AspnetRole!.RoleName == roleName)
            .AnyAsync();
    }

    async Task<IList<MembershipUser>> IUserRoleStore<MembershipUser>.GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
    {
        var dbUsers = await _db.AspnetUsersInRoles
            .Include(x => x.AspnetUser)
                .ThenInclude(x => x!.AspnetMembership)
            .Include(x => x.AspnetRole)
            .Where(x => x.AspnetRole!.RoleName == roleName)
            .Select(x => x.AspnetUser)
            .ToListAsync(cancellationToken: cancellationToken);

        var list = new List<MembershipUser>();
        foreach (var dbUser in dbUsers)
        {
            var memb = dbUser!.AspnetMembership;
            var passwordHash = $"{memb!.PasswordSalt}:{memb.Password}";

            list.Add(new(dbUser.UserId, dbUser.UserName)
            {
                PasswordHash = passwordHash,
                Email = memb.Email,
            });
        }

        return list;
    }
}
