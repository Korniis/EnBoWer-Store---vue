using ShoppingWeb.Models;

namespace ShoppingWeb.ViewModel
{
    public class AuthenticateResponse
    {
        public AuthenticateResponse( User user,string token )
        {
            Id = user.Id;
            Token = token;
            Email = user.Email;
        }


        public int Id { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }

    }
}
