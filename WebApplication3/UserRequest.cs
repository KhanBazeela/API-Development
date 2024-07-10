

namespace WebApplication3
{
    public class UserRequest
    {
      
        public string Name { get; set; }
        [StringLength(10)]
        public string Email { get; set; }
        public string Job { get; set; }
    }
}
