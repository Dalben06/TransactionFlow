using TransactionFlow.Domain.Entities;

namespace TransactionFlow.Domain.IRepository
{
    public interface ITransactionCommandRepository
    {
        public bool CompleteTransaction(Transaction transaction);
    }
}
