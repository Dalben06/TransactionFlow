namespace TransactionFlow.Domain.IRepository
{
    public interface IBalanceAccountHistoryCommandRepository
    {
        void AddHistory(long accountId, decimal newBalance);
    }
}
