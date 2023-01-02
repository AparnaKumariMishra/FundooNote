using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer;
using RepositoryLayer.Entity;

namespace BusinessLayer.Interface
{
    public interface IUserBussiness
    {
        public UserEntity UserRegistration(UserRegistrationModel UserRepo);
        public string UserLogin(UserLoginModel user);
        public string ForgotPassword(string email);
        public bool ResetUserPassword(string email, string password, string confirmPassword);
    }
}
