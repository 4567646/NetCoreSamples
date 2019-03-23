using NetCoreDemo.Core.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreDemo.Services.Security
{
    public interface IEncryptionService: ISingletonDependency
    {
        string HashPassword(string password);

        bool VerifyHashedPassword(string hashedPassword, string password);

        string Encrypt(string plainText, string key);

        string Decrypt(string cypherText, string key);
    }
}
