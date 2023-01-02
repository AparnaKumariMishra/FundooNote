using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer;
using RepositoryLayer.Entity;

namespace RepositoryLayer.Interface
{
    public interface IUserRepo
    {
        public UserEntity UserRegistration(UserRegistrationModel UserRepo);
        public string UserLogin(UserLoginModel loginModel);
        public string ForgotPassword(string email);
        public bool ResetUserPassword(string email, string password, string confirmPassword);
    }
        
        
}
