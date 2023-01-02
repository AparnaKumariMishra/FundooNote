using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;

namespace BusinessLayer.Service
{
    public class UserBussiness : IUserBussiness
    {
        private readonly IUserRepo userRepo;
        public UserBussiness(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }
        public UserEntity UserRegistration(UserRegistrationModel UserRepo)
        {
            try
            {
                return this.userRepo.UserRegistration(UserRepo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
            public string UserLogin(UserLoginModel user)
            {
                try
                {
                    return this.userRepo.UserLogin(user);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
       

        public string ForgotPassword(string email)
        {
            try
            {
                return this.userRepo.ForgotPassword(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool ResetUserPassword(string email, string password, string confirmPassword)
        {
            try
            {
                return this.userRepo.ResetUserPassword(email, password, confirmPassword);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}