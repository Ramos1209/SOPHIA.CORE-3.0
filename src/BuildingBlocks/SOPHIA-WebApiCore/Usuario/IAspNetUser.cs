using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace SOPHIA_WebApiCore.Usuario
{
    public interface IAspNetUser
    {
        string Name { get; }

        Guid ObterUserId();
        string ObterUserEmail();
        string ObterUserToken();
        bool EstaAutenticado();
        bool PossuiRoles(string role);
        IEnumerable<Claim> ObterClaims();
        HttpContext ObterContext();
    }
}
