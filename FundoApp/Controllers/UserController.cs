using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FundoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBussiness userBussiness;
        public UserController(IUserBussiness userBussiness)
        {
            this.userBussiness = userBussiness;
        }
        [HttpPost("UserRegister")]
        public ActionResult Registration(UserRegistrationModel registration)
        {
            try
            {
                var responce = this.userBussiness.UserRegistration(registration);
                if (responce != null)
                {
                    return this.Ok(new { success = true, message = "Register Succesfull", data = responce });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Register failed" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("UserLogin")]
        public IActionResult UserLogin(UserLoginModel userLoginModel)
        {
            try
            {
                var response = this.userBussiness.UserLogin(userLoginModel);
                if (response != null)
                {
                    return this.Ok(new { success = true, message = "login Successful", data = response });
                }
                else
                {
                    return this.Ok(new { success = false, message = "login failed" });

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route(" ForgotPassword")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                var response = this.userBussiness.ForgotPassword(email);
                if (response != null)
                {
                    return this.Ok(new { success = true, message = "Mail sent", data = response });
                }
                else
                {
                    return this.Ok(new { success = false, message = "invalid mail" });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

            [HttpPost]
            [Route("ResetUserPassword")]
            public IActionResult ResetUserPassword(string email, string password, string confirmPassword)
            {
                try
                {
                    var response = this.userBussiness.ResetUserPassword( email,  password, confirmPassword);
                    if (response != null)
                    {
                        return this.Ok(new { success = true, message = "please Reset  UserPassword", data = response });
                    }
                    else
                    {
                        return this.Ok(new { success = false, message = "UserPassword Not set" });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
    }
}
