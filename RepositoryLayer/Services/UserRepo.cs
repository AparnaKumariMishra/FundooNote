using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CommonLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Services
{
    public class UserRepo : IUserRepo
    {
        FundoContext fundoContext;
        private readonly IConfiguration configuration;
        public UserRepo(FundoContext fundoContext, IConfiguration configuration)
        {
            this.fundoContext = fundoContext;
            this.configuration = configuration;
        }
        public UserEntity UserRegistration(UserRegistrationModel UserRepo)
        {
            try
            {
                UserEntity User = new UserEntity();
                User.FirstName = UserRepo.FirstName;
                User.LastName = UserRepo.LastName;
                User.Email = UserRepo.Email;
                User.Password = UserRepo.Password;
                User.UserId = new UserEntity().UserId;
                fundoContext.UserTable.Add(User);
                fundoContext.SaveChanges();
                return User;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UserLogin(UserLoginModel userLogin)
        {
            try
            {
                var userEntity = this.fundoContext.UserTable.FirstOrDefault(x => x.Email == userLogin.Email);
                if (userEntity != null)
                {
                    var token = this.GenerateToken(userEntity.Email, userEntity.UserId);
                    return token;
                }
                return null;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GenerateToken(string EmailID, long userID)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration[("jwt:key")]));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Email, EmailID),
                    new Claim("userID",userID.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(tokenkey, SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public string EncryptPassword(string password)
        {
            try
            {
                byte[] enData_byte = new byte[password.Length];
                enData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(enData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64String" + ex.Message);
            }
        }
        public string DecryptPassword(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new string(decoded_char);
            return result;
        }


        public string ForgotPassword(string email)
        {
            try
            {
                var result = this.fundoContext.UserTable.FirstOrDefault(x => x.Email == email);
                if (result != null)
                {
                    var token = this.GenerateToken(result.Email, result.UserId);
                    MSMQ ms = new MSMQ();
                    ms.sendData2Queue(token,result.Email,result.FirstName);
                    return token.ToString();
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        public bool ResetUserPassword(string email,string password,string confirmPassword)
        {
            try
            {
                if (password.Equals(confirmPassword))
                {
                    var user = this.fundoContext.UserTable.Where(x => x.Email == email).FirstOrDefault();
                    string newEncryptedPassword = EncryptPassword(password);
                    user.Password = newEncryptedPassword;
                    fundoContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

   