using TransactionFlow.Data.Mocks;
using TransactionFlow.Domain.Entities;
using TransactionFlow.Domain.IRepository;

namespace TransactionFlow.Data.Repository
{
    public class TransactionCommandRepository : ITransactionCommandRepository
    {
        public bool CompleteTransaction(Transaction transaction)
        {
            var transactionDb = TransactionStaticMock.Instance.Transactions.FirstOrDefault(t => t.Id == transaction.Id);
            transactionDb.IsCompleted = true;
            return true;
        }
    }
}
