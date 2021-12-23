// Zyborg ASP.NET Core Identity Storage Provider for ASP.NET Membership Database.
// Copyright (C) Zyborg.

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data;

namespace Zyborg.AspNetCore.Identity.AspNetMembership;

/// <summary>
/// Implements a read-only Identity RoleStore over an ASP.NET Membership data store.
/// </summary>
public class ROMembershipRoleStore : IRoleStore<MembershipRole>
{
    private readonly AspNetMembershipContext _db;
    private readonly MembershipOptions _options;

    public ROMembershipRoleStore(AspNetMembershipContext db, MembershipOptions options)
    {
        _db = db;
        _options = options;
    }

    public void Dispose()
    {
    }

    public Task<IdentityResult> CreateAsync(MembershipRole role, CancellationToken cancellationToken)
    {
        throw new NotImplementedException("the read-only role store does not support write operations");
    }

    public Task<IdentityResult> DeleteAsync(MembershipRole role, CancellationToken cancellationToken)
    {
        throw new NotImplementedException("the read-only role store does not support write operations");
    }

    public async Task<MembershipRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
    {
        var guid = Guid.Parse(roleId);
        var app = _options.ApplicationName == null
            ? await _db.AspnetApplications.FirstOrDefaultAsync()
            : await _db.AspnetApplications.FirstOrDefaultAsync(x => x.LoweredApplicationName == _options.LoweredApplicationName);
        var dbRole = await _db.AspnetRoles
            .FirstOrDefaultAsync(x => x.AspnetApplication == app && x.RoleId == guid);

        if (dbRole == null)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.
        }

        return new MembershipRole(dbRole.RoleId, dbRole.RoleName);
    }

    public async Task<MembershipRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
    {
        // ANC Identity uses UPPER normalization but AN Membership uses LOWER
        normalizedRoleName = normalizedRoleName.ToLower();

        var app = _options.ApplicationName == null
            ? await _db.AspnetApplications.FirstOrDefaultAsync()
            : await _db.AspnetApplications.FirstOrDefaultAsync(x => x.LoweredApplicationName == _options.LoweredApplicationName);
        var dbRole = await _db.AspnetRoles
            .FirstOrDefaultAsync(x => x.AspnetApplication == app && x.LoweredRoleName == normalizedRoleName);

        if (dbRole == null)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.
        }

        return new MembershipRole(dbRole.RoleId, dbRole.RoleName);
    }

    public Task<string> GetNormalizedRoleNameAsync(MembershipRole role, CancellationToken cancellationToken)
    {
        return Task.FromResult(role.RoleName.ToLower());

    }

    public Task<string> GetRoleIdAsync(MembershipRole role, CancellationToken cancellationToken)
    {
        return Task.FromResult(role.RoleId.ToString());
    }

    public Task<string> GetRoleNameAsync(MembershipRole role, CancellationToken cancellationToken)
    {
        return Task.FromResult(role.RoleName);
    }

    public Task SetNormalizedRoleNameAsync(MembershipRole role, string normalizedName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException("the read-only role store does not support write operations");
    }

    public Task SetRoleNameAsync(MembershipRole role, string roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException("the read-only role store does not support write operations");
    }

    public Task<IdentityResult> UpdateAsync(MembershipRole role, CancellationToken cancellationToken)
    {
        throw new NotImplementedException("the read-only role store does not support write operations");
    }
}
