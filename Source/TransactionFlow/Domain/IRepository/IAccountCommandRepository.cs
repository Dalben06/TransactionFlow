using TransactionFlow.Domain.Entities;

namespace TransactionFlow.Domain.IRepository
{
    public interface IAccountCommandRepository
    {
        bool SaveBalance(Account source);
    }
}
