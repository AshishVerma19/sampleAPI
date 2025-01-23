using System;
using sampleAPI.Models;

namespace sampleAPI.interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
}
