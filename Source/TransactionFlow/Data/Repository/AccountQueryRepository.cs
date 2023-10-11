using TransactionFlow.Data.Mocks;
using TransactionFlow.Domain.Entities;
using TransactionFlow.Domain.IRepository;

namespace TransactionFlow.Data.Repository
{
    public class AccountQueryRepository : IAccountQueryRepository
    {
        public Account GetAccountById(long id) => AccountStaticMock.Instance.Accounts.FirstOrDefault(a => a.Id == id);
    }
}
