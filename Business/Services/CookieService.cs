using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Business.Services
{
    public class CookieService : ICookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string CookieKey = "CurrentUserId";

        public CookieService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void GuardarUsuario(Guid userId)
        {
            var context = _httpContextAccessor.HttpContext;
            if (context == null) return;

            var cookieOptions = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(7),
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Lax
            };
            context.Response.Cookies.Append(CookieKey, userId.ToString(), cookieOptions);
        }

        public Guid? ObtenerUsuario()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context == null) return null;
            if (context.Request.Cookies.TryGetValue(CookieKey, out string userIdString))
            {
                if (Guid.TryParse(userIdString, out Guid userIdGuid))
                {
                    return userIdGuid;
                }
            }
            return null;
        }
    }
}
