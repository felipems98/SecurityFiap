using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Security.Api.Domain.Models;

namespace Security.Api.Infraestructure.Repositories
{
    public static class UserLoginRepository
    {
        public static UserLogin Get(string username)
        {
            var LoginInfo = new List<UserLogin>();
            LoginInfo.Add(new UserLogin { UserId = 1, UserName = "batman", /*Password: Teste01*/HashPass = "a324d48aefa29cdab29a5909863251d5108dcc56a6ec63690c95881b7e6634c9",SaltCode = "Klnio" });
            LoginInfo.Add(new UserLogin { UserId = 2, UserName = "robin", /*Password: Teste02*/HashPass = "cc2874a579fa0b6e1bfad201e06542c0848fab5978549c8100206ba3e948894f", SaltCode = "DeFvE" });
            LoginInfo.Add(new UserLogin { UserId = 3, UserName = "batgirl", /*Password: Teste02*/HashPass = "dc5598a59ac5725863ce3a707e669fd8fd924c865877ce8bc2cc21f11c4d1346", SaltCode = "KYkip" });
            return LoginInfo.Where(x => x.UserName == username).FirstOrDefault();
        }
    }
}
