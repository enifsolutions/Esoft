namespace BankApplication.Models.Accounts
{
    public class CreateAccountModel
    {
        public int Id { get; set; }
        public int AccId { get; set; }
        public string AccHolder { get; set; }
        public DateTime OpenDate { get; set; }
        public decimal OpenAmount { get; set; }
        public string Currency { get; set; }
        public string BranchCode { get; set; }
        public string AppUser { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
