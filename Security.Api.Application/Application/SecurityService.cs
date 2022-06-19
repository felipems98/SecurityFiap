using Security.Api.Domain.Dto;
using Security.Api.Domain.Enums;
using Security.Api.Domain.Models;
using Security.Api.Infraestructure.Repositories;
using Security.Api.Infraestructure.TestRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Security.Api.Application
{
    public class SecurityService
    {
        public LoginResponseDto ValidateLogin(LoginRequestDto inLogin)
        {
            LoginResponseDto response = new LoginResponseDto();
            //Search the username in the base, if exist,
            string tempUserName = "zezinho123";
            string tempPassword = "shavascaassada";
            string tempSalt = "Bjwji";
            string tempHash = "1b3f75b2f36404e68569311354e66722cb6c935c8ac33f8e5c7c253cf0b9cc6b";

            UserLogin checkLogin = UserLoginRepository.Get(inLogin.UserName);

            //If the user name is correct
           if (checkLogin != null)
            {

                // * Check on DB the salt for this user name
                // * Concatenate in the end of the received password
                // * Generate a sha-265 hash to compare with de hash in DB
                string tempCheckPass = inLogin.Password + checkLogin.SaltCode;
                if (GenerateHash(tempCheckPass) == checkLogin.HashPass)
                {
                    response.ReturnCode = (int)ReturnCodes.Valid_Login;
                    response.Message = ReturnCodes.Valid_Login.ToString();

                    //Getting User Info by UserId
                    User user = UserRepository.Get(checkLogin.UserId);
                    response.UserInfo.Name = user.Name;
                    response.UserInfo.LastName = user.LastName;
                    response.UserInfo.Active = user.Active;
                    //Gettin Permissions by userId
                    List<Permission> permissions = PermissionRepository.Get(checkLogin.UserId);
                    foreach(var _perm in permissions)
                    {
                        response.Permissions.Add(_perm.PermissionId);
                    }

                    return response;
                }


            }

            response.ReturnCode = (int)ReturnCodes.Invalid_Login_Or_Username;
            response.Message = ReturnCodes.Invalid_Login_Or_Username.ToString();
            response.UserInfo = null;

            return response;

        }

        public string GenerateHash(string pass)
        {

            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(pass));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();

        }


    }
}

