namespace TransactionFlow.Domain.DomainExpections
{
    public class NoBalanceAccountTransactionException : Exception
    {
        public NoBalanceAccountTransactionException() { }

        public NoBalanceAccountTransactionException(string message)
            : base(message) { }

        public NoBalanceAccountTransactionException(string message, Exception inner)
            : base(message, inner) { }
    }
}
