using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class CustomerModel
    {
        public CustomerModel()
        {

        }
        public int CustomerId { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Name Required")]
        public String? Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Required")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Invalid Email Address.")]
        public String? Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Required")]
        [MinLength(6, ErrorMessage ="Minimum 6 Character")]
        public String? Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Mobile Required")]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public Int64 Mobile { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Select Gender")]
        public String? Gender { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Address Required")]
        public String? Address { get; set; }
        public String? Role { get; set; }
        public int RoleId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Select State")]
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int UserStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
