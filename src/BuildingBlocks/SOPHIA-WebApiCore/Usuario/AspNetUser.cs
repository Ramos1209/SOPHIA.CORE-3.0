using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace SOPHIA_WebApiCore.Usuario
{
    public class AspNetUser : IAspNetUser
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AspNetUser(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string Name => _contextAccessor.HttpContext.User.Identity.Name;

        public bool EstaAutenticado()
        {
            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> ObterClaims()
        {
            return _contextAccessor.HttpContext.User.Claims;
        }

        public HttpContext ObterContext()
        {
            return _contextAccessor.HttpContext;
        }

        public string ObterUserEmail()
        {
            return EstaAutenticado() ? _contextAccessor.HttpContext.User.GetUserEmail() : "";
        }

        public Guid ObterUserId()
        {
            return EstaAutenticado() ? Guid.Parse(_contextAccessor.HttpContext.User.GetUserId()) : Guid.Empty;
        }

        public string ObterUserToken()
        {
            return EstaAutenticado() ? _contextAccessor.HttpContext.User.GetUserToken() : "";
        }

        public bool PossuiRoles(string role)
        {
            return _contextAccessor.HttpContext.User.IsInRole(role);
        }
    }
}