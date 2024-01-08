using System.ComponentModel.DataAnnotations;

namespace BankApplication.Models.User
{
    public class UserViewModel
    {
        [Key]
        public long userid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string createduser { get; set; }
        public string action { get; set; }
        
    }
}
