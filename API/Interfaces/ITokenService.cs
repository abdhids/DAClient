using System;
using API.Entitites;

namespace API.Interfaces;

public interface ITokenService //contract
{
    string CreateToken(AppUser user);
}
