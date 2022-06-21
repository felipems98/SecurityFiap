
namespace Security.Api.Domain.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }
      
    }
}
