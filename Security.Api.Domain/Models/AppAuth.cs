using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Api.Domain.Models
{
    public class AppAuth
    {
        public int AppId { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
    }
}
