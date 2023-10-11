using TransactionFlow.Domain.Entities;

namespace TransactionFlow.Domain.IRepository
{
    public interface IAccountQueryRepository
    {
        Account GetAccountById(long id);
    }
}
