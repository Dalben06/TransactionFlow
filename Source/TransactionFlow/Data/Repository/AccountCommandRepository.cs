using TransactionFlow.Data.Mocks;
using TransactionFlow.Domain.Entities;
using TransactionFlow.Domain.IRepository;

namespace TransactionFlow.Data.Repository
{
    public class AccountCommandRepository : IAccountCommandRepository
    {
        public bool SaveBalance(Account source)
        {
            AccountStaticMock.Instance.Accounts.Remove(source);
            AccountStaticMock.Instance.Accounts.Add(source);
            return true;
        }
    }
}
