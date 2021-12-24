// Zyborg ASP.NET Core Identity Storage Provider for ASP.NET Membership Database.
// Copyright (C) Zyborg.

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Zyborg.AspNetCore.Identity.AspNetMembership.Membership.Data;

namespace Zyborg.AspNetCore.Identity.AspNetMembership;

public static class ServiceCollectionExtensions
{
    public static IdentityBuilder AddAspNetReadOnlyMembership(this IServiceCollection services,
        string connectionString, string? appName = null)
    {
        return AddAspNetReadOnlyMembership(services, options =>
        {
            options.ConnectionString = connectionString;
            options.ApplicationName = appName;
        });
    }

    public static IdentityBuilder AddAspNetReadOnlyMembership(this IServiceCollection services,
        Action<MembershipOptions> configureOptions)
    {
        services.AddSingleton<MembershipOptions>(services =>
        {
            var options = new MembershipOptions();
            configureOptions(options);
            return options;
        });

        services.AddScoped<IPasswordHasher<MembershipUser>, MembershipPasswordHasher>();

        services.AddTransient<IUserStore<MembershipUser>, ROMembershipUserStore>();
        services.AddTransient<IRoleStore<MembershipRole>, ROMembershipRoleStore>();

        services.AddDbContext<AspNetMembershipContext>((services, options) =>
        {
            var mo = services.GetRequiredService<MembershipOptions>();
            options.UseSqlServer(mo.ConnectionString ?? string.Empty);
        });

        return services.AddIdentity<MembershipUser, MembershipRole>();
    }
}
