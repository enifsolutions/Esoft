namespace BankApplication.Models.Accounts
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public int AccTypeId { get; set; }
        public string AccType { get; set; }
        public string AccTypeCode { get; set; }
        public decimal InterestRate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}
