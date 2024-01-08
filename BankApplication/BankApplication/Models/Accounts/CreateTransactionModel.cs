namespace BankApplication.Models.Accounts
{
    public class CreateTransactionModel
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int TransactionTypeId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public int AccId { get; set; }
        public string BankCode { get; set; }
        public string BranchCode { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}
