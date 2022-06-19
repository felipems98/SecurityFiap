using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Api.Domain.Models
{
    public class Permission
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }
    }
}
