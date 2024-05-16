using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShoppingWeb.Helpers;
using ShoppingWeb.Models;
using ShoppingWeb.Services.Interfaces;
using ShoppingWeb.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace ShoppingWeb.Services.Implmentation
{
    public class UserService : IUserService
    {
        private readonly List<User> _users = new List<User>()
        {
             new User
             {
                 Id=1,
                 Email = "123456",
                 Password = "123456"
             }
        };
        private readonly AuthSettings _authSettings;
        public UserService(IOptions<AuthSettings> authSettings)
        {
            _authSettings = authSettings.Value;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest request)
        {
            //通过账号密码验证 
            var user = _users.SingleOrDefault(u => u.Email == request.Email && u.Password == request.Password);
            if (user == null)
            {
                return null;
            }
            // 创建令牌
            var token = GenerateJwtoken(user);
            //  返回用户信息
            return new AuthenticateResponse(user, token);
        }
        private string GenerateJwtoken(User user)
        {
            byte[] key = Encoding.ASCII.GetBytes(_authSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                //
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim("sub", user.Id.ToString()),
                        new Claim("email", user.Email)
                    }),
                Expires = DateTime.UtcNow.AddDays(100),
                SigningCredentials = new SigningCredentials
                (
                       new SymmetricSecurityKey(key),
                       SecurityAlgorithms.HmacSha256Signature
                ),
            };
            //token 
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }
    }
}
