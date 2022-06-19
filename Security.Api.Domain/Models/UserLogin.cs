using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Api.Domain.Models
{
    public class UserLogin
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string HashPass { get; set; }
        public string SaltCode { get; set; }
    }
}
