namespace BankApplication.Models.Accounts
{
    public class CreateTransactionTypeModel
    {
        public int Id { get; set; }
        public int TransactionTypeId { get; set; }
        public string TransactionType { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public string ModifiedUser { get; set; }
    }
}
