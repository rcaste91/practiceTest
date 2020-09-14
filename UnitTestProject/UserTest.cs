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

        IUserService userService;

        public UserTest()
        {
            userService = new ServiceConnect();
        }

        [TestMethod]
        public async Task TestGetAllUsers()
        {
            List<User> users = new List<User>();

            users = await userService.GetAllUsers();

            Assert.IsNotNull(users);

        }

        /*
        [TestMethod]
        public async Task TestFilterUsers()
        {
            
            List<User> users = new List<User>();
            string name = "Leanne Graham";
            string username = "";
            string email = "";

            users = await userService.GetUserByNames(name,username,email);

            Assert.IsNotNull(users);
          
        }
        */

        [TestMethod]
        public void TestDistinctCities()
        {
            List<string> cities =  userService.GetDistinctCities();

            Assert.IsNotNull(cities);
        }

        [TestMethod]
        public async Task TestFindUsersByCities()
        {
            List<User> users = await userService.GetUserByCity("Gwenborough");

            Assert.IsNotNull(users);
        }

    }
}
