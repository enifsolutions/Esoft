using System.ComponentModel.DataAnnotations;

namespace BankApplication.Models.Login
{
    public class LoginViewModel
    {
        [Key]
        public string username { get; set; }
        public string password { get; set; }
    }
}
