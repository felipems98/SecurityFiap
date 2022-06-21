using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Security.Api.Infraestructure.Contexts
{
    public class SecurityDbContext : DbContext
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options)
        {

        }
        public SecurityDbContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => (type.Namespace != null && type.Namespace.Contains("Accreditation.Api.Infrastructure.Database.EntityConfig")))
                .Where(type => type.BaseType != null)
                .Where(type => type.Name.Length > 5);
            foreach (var type in typesToRegister)
            {
                dynamic configInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configInstance);
            }
        }
        public string GetConnectionString()
        {
            return null;
        }
    }
}
