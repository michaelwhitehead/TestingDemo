using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestingDemo.Demo_2
{
    public interface IRepository : IDisposable
    {
        IList<IUserModel> Users { get; set; }

        IList<IUserModel> ActiveUsers();

        Task<IList<IUserModel>> ActiveUsersAsync();

        IUserModel SearchById(int id);

        IList<IUserModel> Search(string address);

        bool Add(IUserModel model);

        bool AddUser<T>(T user);

        void Save();
    }

    public interface IUserModel
    {
        int Id { get; set; }

        string Username { get; set; }

        IAddress Address { get; set; }
    }

    public interface IAddress
    {
        string Street { get; set; }
    }
}
