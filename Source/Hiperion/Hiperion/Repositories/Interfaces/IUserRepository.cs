﻿namespace Hiperion.Repositories.Interfaces
{
    using System.Collections.Generic;
    using Domain;

    public interface IUserRepository
    {
        IList<User> GetAllValues();

        void SaveOrUpdateUser(User user);

        void DeleteUser(int id);
    }
}