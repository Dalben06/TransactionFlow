namespace TransactionFlow.Domain.DomainExpections
{
    public class TransactionCompletedException : Exception
    {
        public TransactionCompletedException() { }

        public TransactionCompletedException(string message)
            : base(message) { }

        public TransactionCompletedException(string message, Exception inner)
            : base(message, inner) { }
    }
}
