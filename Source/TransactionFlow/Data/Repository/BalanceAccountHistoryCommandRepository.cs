using TransactionFlow.Data.Mocks;
using TransactionFlow.Domain.IRepository;

namespace TransactionFlow.Data.Repository
{
    public class BalanceAccountHistoryCommandRepository : IBalanceAccountHistoryCommandRepository
    {
        public void AddHistory(long accountId, decimal newBalance)
        {
            BalanceAccountHistoryStaticMock.Instance.History.Add(new Domain.Entities.BalanceAccountHistory(accountId, newBalance));
        }
    }
}
