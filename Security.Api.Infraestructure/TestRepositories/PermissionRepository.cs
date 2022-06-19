using Security.Api.Domain.Enums;
using Security.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Api.Infraestructure.TestRepositories
{
    public static class PermissionRepository
    {
        public static List<Permission> Get(int userId)
        {
            var PermissionsInfo = new List<Permission>();
            PermissionsInfo.Add(new Permission { UserId = 1, PermissionId = (int)PermissionsEnum.Payment});
            PermissionsInfo.Add(new Permission { UserId = 1, PermissionId = (int)PermissionsEnum.Change_Info});
            PermissionsInfo.Add(new Permission { UserId = 2, PermissionId = (int)PermissionsEnum.Payment });
            PermissionsInfo.Add(new Permission { UserId = 3, PermissionId = (int)PermissionsEnum.Payment });
            return PermissionsInfo.Where(x => x.UserId == userId).ToList();
        }
    }
}
