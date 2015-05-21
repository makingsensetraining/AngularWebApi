namespace Hiperion.Repositories.Interfaces
{
    #region References

    using System.Collections.Generic;
    using Domain;

    #endregion

    public interface IUserRepository
    {
        IList<User> GetAllValues();

        void SaveOrUpdateUser(User user);

        void DeleteUser(int id);

        bool Login(string userName, string password);
    }
}