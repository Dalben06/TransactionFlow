﻿namespace TransactionFlow.Domain.DomainExpections
{
    [Serializable]
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException() { }

        public AccountNotFoundException(string message)
            : base(message) { }

        public AccountNotFoundException(string message, Exception inner)
            : base(message, inner) { }
    }
}
