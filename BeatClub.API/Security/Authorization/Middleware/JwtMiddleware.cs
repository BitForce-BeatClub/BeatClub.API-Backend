using System.Linq;
using System.Threading.Tasks;
using BeatClub.API.Security.Authorization.Handlers.Interfaces;
using BeatClub.API.Security.Authorization.Settings;
using BeatClub.API.Security.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace BeatClub.API.Security.Authorization.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtHandler handler)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = handler.ValidateToken(token);

            if (userId != null)
            {
                // On succesful JWT validation, attach info tp context
                context.Items["User"] = await userService.GetByIdAsync(userId.Value);
            }

            await _next(context);

        }
        
    }
}