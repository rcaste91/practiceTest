using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using practiceTest.Core;

namespace practiceTest.Service
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<List<User>> GetUserByNames(string name, string username, string email);
    }
}
