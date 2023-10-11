using TransactionFlow.Domain.DomainExpections;
using TransactionFlow.Domain.Entities;

namespace TransactionFlow.Domain.DomainService
{
    /// <summary>
    /// I Create this class for all rules bussiness transaction stay here. It's more easy for create unit test for complexy rules. exemple : assessment to cost
    /// </summary>
    public class TransactionDomainRules
    {

        public Transaction Transaction { get; private set; }
        public Account Source { get; private set; }
        public Account Destination { get; private set; }

        public TransactionDomainRules(Transaction transaction, Account source, Account destination)
        {
            this.Transaction = transaction;
            this.Source = source;
            this.Destination = destination;
        }


        // Can use Notification Pattern to notifity errors and warnings
        // In this simple case, i wanna use Exception
        public void CompleteTransation()
        {
            if (this.Transaction is null) throw new TransactionNotFoundException($"Transaction not found!");

            if (this.Source is null) throw new AccountNotFoundException("Source account not found!");

            if (this.Destination is null) throw new AccountNotFoundException("Destination account not found!");

            if (this.Transaction.IsCompleted) throw new TransactionCompletedException("Transaction was been completed!");

            if (this.Transaction.Value <= 0) throw new TransactionLessZeroValueException("Transaction value less than zero");

            if (!this.Source.HasBalanceToTransaction(Transaction.Value))
                throw new NoBalanceAccountTransactionException($"Transacao numero {Transaction.Id} foi cancelada por falta de saldo");

            // If you need more rules  
            this.Source.Debit(Transaction.Value);
            this.Destination.Credit(Transaction.Value);
            Console.WriteLine("Transacao numero {0} foi efetivada com sucesso! Novos saldos: Conta Origem:{1} | Conta Destino: {2}", Transaction.Id, Source.Balance, Destination.Balance);
        }


    }
}
