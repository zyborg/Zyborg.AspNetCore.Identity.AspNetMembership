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
public class ROMembershipUserStore : IUserPasswordStore<MembershipUser>
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
            ? await _db.AspnetApplications.FirstOrDefaultAsync()
            : await _db.AspnetApplications.FirstOrDefaultAsync(x => x.LoweredApplicationName == _options.LoweredApplicationName);
        var dbUser = await _db.AspnetUsers
            .Include(x => x.AspnetMembership)
            .FirstOrDefaultAsync(x => x.AspnetApplication == app && x.UserId == guid);

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

    public async Task<MembershipUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        // ANC Identity uses UPPER normalization but AN Membership uses LOWER
        normalizedUserName = normalizedUserName.ToLower();

        var app = _options.ApplicationName == null
            ? await _db.AspnetApplications.FirstOrDefaultAsync()
            : await _db.AspnetApplications.FirstOrDefaultAsync(x => x.LoweredApplicationName == _options.LoweredApplicationName);
        var dbUser = await _db.AspnetUsers
            .Include(x => x.AspnetMembership)
            .FirstOrDefaultAsync(x => x.AspnetApplication == app && x.LoweredUserName == normalizedUserName);

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
}
