using TransactionFlow.Domain.DomainExpections;

namespace TransactionFlow.Domain.Entities
{
    public class Account
    {
        public long Id { get; private set; }
        public decimal Balance { get; private set; }

        public Account(long id, decimal balance)
        {
            this.Id = id;
            this.Balance = balance;
        }

        public bool HasBalanceToTransaction(decimal value)
        {
            return this.Balance >= value;
        }

        public void Debit(decimal value)
        {
            if (this.Balance < value) throw new NoBalanceAccountTransactionException("Transação cancelada por falta de saldo!");

            this.Balance -= value;
        }

        public void Credit(decimal value)
        {
            this.Balance += value;
        }


    }
}
