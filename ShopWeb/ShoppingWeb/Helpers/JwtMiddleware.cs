using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShoppingWeb.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Text;
namespace ShoppingWeb.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AuthSettings _authSettings;
        public JwtMiddleware(RequestDelegate next, IOptions< AuthSettings> authSettings)
        {
            _next = next;
            _authSettings = authSettings.Value;
        }
        public async Task Invoke( HttpContext context,IUserService service )
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token!= null)
            {
                AttachUserToContext(context,service,token);
            }
            await _next(context);
        }
        private void AttachUserToContext(HttpContext context, IUserService service, string? token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_authSettings.Secret);
            tokenHandler.ValidateToken(token,new TokenValidationParameters
            {
                ValidateIssuerSigningKey= true,
                IssuerSigningKey= new SymmetricSecurityKey(key),
                ValidateIssuer=false,
                ValidateAudience=false,
                ClockSkew=TimeSpan.Zero
            },
            out var validatedToken
            );
            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.FirstOrDefault(c => c.Type == "sub").Value);
            context.Items["User"] = service.GetById(userId);
        }
    }
}
