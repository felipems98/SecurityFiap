using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Security.Api.Domain.Dto
{
    public class LoginResponseDto
    {
        public int ReturnCode { get; set; }
        public string Message { get; set; }
        public List<int> Permissions { get; set; } = new List<int>();
        public UserDataInfo UserInfo { get; set; } = new UserDataInfo();

        public class UserDataInfo
        {
            public int UserId { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
            public bool Active { get; set; }
        }
    }
}
