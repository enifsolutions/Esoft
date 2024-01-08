namespace BankApplication.Models.Customer
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Nic { get; set; }
        public DateTime Dob { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}
