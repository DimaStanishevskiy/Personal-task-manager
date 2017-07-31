using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PersonalTaskManager.Services;
using PersonalTaskManager.Repository;
using PersonalTaskManager.Models;

namespace PersonalTaskManager.Controllers
{

    public class UserController : ApiController
    {

        UserServices userServices = new UserServices(new MSSQLRepository());

        [HttpPost]
        public bool Registration(User user)
        {
            return userServices.RegistrationUser(user.Login, user.Password);
        }
        [HttpPost]
        [Route("api/user/login")]
        public bool Login(User user)
        {
            if (user.Login == null || user.Password == null)
                return false;
            return userServices.LoginUser(user.Login, user.Password);
        }
        [HttpPost]
        public void Logoff()
        {
            userServices.LogoffUser();
        }
    }
}
