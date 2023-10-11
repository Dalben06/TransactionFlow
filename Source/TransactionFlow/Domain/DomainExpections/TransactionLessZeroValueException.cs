namespace TransactionFlow.Domain.DomainExpections
{
    public class TransactionLessZeroValueException : Exception
    {
        public TransactionLessZeroValueException() { }

        public TransactionLessZeroValueException(string message)
            : base(message) { }

        public TransactionLessZeroValueException(string message, Exception inner)
            : base(message, inner) { }
    }
}
