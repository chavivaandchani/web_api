using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
        public class UserDTO
        {
           
            
          //  [MinLength(2, ErrorMessage = "First name min-length is 2 letters"), MaxLength(20, ErrorMessage = "First name max-length is 20 letters")]
            public string FirstName { get; set; }
           // [MinLength(2, ErrorMessage = "Last name min-length is 2 letters"), MaxLength(20, ErrorMessage = "Last name max-length is 20 letters")]
            public string LastName { get; set; }
            //[MinLength(8, ErrorMessage = "Password min-Length is 8 letters"), MaxLength(50, ErrorMessage = "Password max-Length is 50 letters")]
            public string Password { get; set; }
            public int Id { get; set; }
            public string Name { get; set; } = null!;
    
    }
}


