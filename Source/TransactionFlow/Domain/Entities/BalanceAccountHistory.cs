namespace TransactionFlow.Domain.Entities
{
    public class BalanceAccountHistory
    {
        public BalanceAccountHistory(long accountId, decimal balance)
        {
            AccountId = accountId;
            Balance = balance;
            BalanceAt = DateTime.UtcNow;
        }

        public long AccountId { get; private set; }
        public decimal Balance { get; private set; }
        public DateTime BalanceAt { get; private set; }

        public override string ToString()
        {
            return $"Account: {AccountId} - new Balance {Balance} - Change at {BalanceAt.ToString("dd/MM/yyyy mm:ss")} ";
        }
    }
}
