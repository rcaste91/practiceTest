using Microsoft.VisualStudio.TestTools.UnitTesting;
using practiceTest.Service;
using practiceTest.Core;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject
{
    [TestClass]
    public class UserTest
    {

        [TestMethod]
        public async Task TestGetAllUsers()
        {
            List<User> users = new List<User>();

            IUserService userService = new ServiceConnect();
            users = await userService.GetAllUsers();

            Assert.IsNotNull(users);

        }

        [TestMethod]
        public async Task TestFilterUsers()
        {
            List<User> users = new List<User>();
            string name = "Leanne Graham";
            string username = "";
            string email = "";

            IUserService userService = new ServiceConnect();
            users = await userService.GetUserByNames(name,username,email);

            Assert.IsNotNull(users);
        }


    }
}
