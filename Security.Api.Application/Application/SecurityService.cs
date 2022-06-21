using Security.Api.Application.Utils;
using Security.Api.Domain.Dto;
using Security.Api.Domain.Enums;
using Security.Api.Domain.Models;
using Security.Api.Infraestructure.Repositories;
using Security.Api.Infraestructure.TestRepositories;


namespace Security.Api.Application
{
    public class SecurityService
    {
        public LoginResponseDto ValidateLogin(LoginRequestDto inLogin)
        {
            Tools toolsHandler = new Tools();   
            LoginResponseDto response = new LoginResponseDto();
            //Search the username in the base, if exist
            UserLogin checkLogin = UserLoginRepository.Get(inLogin.UserName);

            //If the user name is correct
           if (checkLogin != null)
            {
                // * Check on DB the salt for this user name
                // * Concatenate in the end of the received password
                // * Generate a sha-265 hash to compare with de hash in DB
                string tempCheckPass = inLogin.Password + checkLogin.SaltCode;
                if (toolsHandler.GenerateSha265Hash(tempCheckPass) == checkLogin.HashPass)
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
           //username not found or incorrect password
            response.ReturnCode = (int)ReturnCodes.Invalid_Login_Or_Username;
            response.Message = ReturnCodes.Invalid_Login_Or_Username.ToString();
            response.UserInfo = null;

            return response;

        }

       


    }
}

