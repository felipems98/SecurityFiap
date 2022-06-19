using Security.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Api.Infraestructure.TestRepositories
{
    public static class UserRepository
    {
        public static User Get(int userId)
        {
            var users = new List<User>();
            users.Add(new User { UserId = 1, Name = "Felipe", LastName = "Moreno Silva", Active = true });
            users.Add(new User { UserId = 2, Name = "Clecio", LastName = "Gomes Rocha da Silva", Active = true });
            users.Add(new User { UserId = 3, Name = "Denise", LastName = "Tinelli ", Active = false });
            return users.Where(x => x.UserId == userId).FirstOrDefault();
        }
    }
}
