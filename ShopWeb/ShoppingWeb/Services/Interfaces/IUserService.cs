﻿using ShoppingWeb.Models;
using ShoppingWeb.ViewModel;

namespace ShoppingWeb.Services.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate( AuthenticateRequest request );

        User Get(int id);

               

    }
}
