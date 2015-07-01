using System.ComponentModel.DataAnnotations;

namespace ArduinoControl.Models
{
    public class IdentityBasicView
    {
        [Required, Display(Name = "User Name")]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress), StringLength(50)]
        [Display(Name = "Email address")]
        public string Email { get; set; }
    }
}