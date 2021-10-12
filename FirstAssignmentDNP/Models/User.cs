using System.Collections.Generic;

namespace Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SecurityLevel { get; set; }
        public string Role { get; set; }
        public Family Family { get; set; }
    }
    
}