// Zyborg ASP.NET Core Identity Storage Provider for ASP.NET Membership Database.
// Copyright (C) Zyborg.

using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Zyborg.AspNetCore.Identity.AspNetMembership;

public class MembershipPasswordHasher : IPasswordHasher<MembershipUser>
{
    public const int SaltSizeBytes = 128 / 8;  // 128 bits

    public string HashPassword(MembershipUser user, string password)
    {
        return HashSaltedPassword(null, password);
    }

    public PasswordVerificationResult VerifyHashedPassword(MembershipUser user, string hashedPassword, string providedPassword)
    {
        var passparts = user.PasswordHash?.Split(":", 2);
        if (passparts == null || passparts.Length < 2)
        {
            return PasswordVerificationResult.Failed;
        }

        var saltBytes = Convert.FromBase64String(passparts[0]);
        var hashedNew = HashSaltedPassword(saltBytes, providedPassword);

        return hashedPassword == hashedNew
            ? PasswordVerificationResult.Success
            : PasswordVerificationResult.Failed;
    }

    private string HashSaltedPassword(byte[]? saltBytes, string password)
    {
        // Salting and hashing compatible with Membership default password hashing algo:
        //    * 128-bit salt
        //    * Unicode encoding of string password
        //    * SHA1-hashing

        if (saltBytes == null)
            saltBytes = RandomNumberGenerator.GetBytes(SaltSizeBytes);
        var passBytes = Encoding.Unicode.GetBytes(password);
        var totalData = new byte[saltBytes.Length + passBytes.Length];
        Buffer.BlockCopy(saltBytes, 0, totalData, 0, saltBytes.Length);
        Buffer.BlockCopy(passBytes, 0, totalData, saltBytes.Length, passBytes.Length);

        var hashBytes = SHA1.HashData(totalData);
        var saltB64 = Convert.ToBase64String(saltBytes);
        var hashB64 = Convert.ToBase64String(hashBytes);

        // We encode the generated salt and computed hash as a single string
        return $"{saltB64}:{hashB64}";
    }
}
