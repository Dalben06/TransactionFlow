namespace TransactionFlow.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Timespan { get; set; }
        public long SourceAccountId { get; set; }
        public long DestinationAccountId { get; set; }
        public decimal Value { get; set; }
        public bool IsCompleted { get; set; }

    }
}
