using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalTaskManager.Models;
using System.Web.Security;
using PersonalTaskManager.Repository;

namespace PersonalTaskManager.Services
{
    public class UserServices
    {
        private IRepository repository;

        public UserServices(IRepository Repository)
        {
            this.repository = Repository;
        }
        public User CurrentUser
        {
            get
            {
                return repository.GetUser(HttpContext.Current.User.Identity.Name);
            }
        }

        public bool RegistrationUser(string Login, string Password)
        {
            if (repository.GetUser(Login) != null)
                return false;
            User user = new User() { Login = Login, Password = Password };
            repository.CreateUser(user);
            return LoginUser(Login, Password); ;

        }
        public bool LoginUser(string Login, string Password)
        {
            User user = repository.GetUser(Login);
            if (user != null && user.Password == Password)
            {
                FormsAuthentication.SetAuthCookie(user.Login, true);
                return true;
            }
            else return false;
        }

        public void LogoffUser()
        {
            FormsAuthentication.SignOut();
        }


    }
}