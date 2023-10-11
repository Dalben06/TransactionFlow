using TransactionFlow.Domain.DomainExpections;
using TransactionFlow.Domain.DomainService;
using TransactionFlow.Domain.Entities;

namespace TransactionFlowTests
{
    [TestClass]
    public class TransactionDomainRulesTests
    {
        [TestMethod]
        public void Transaction_Falied_Transfer_To_Source_account_Not_exist_ThrowAccountNotFoundException()
        {
            // Arrange
            Account source = null;
            Account target = new Account(1, 10M);
            Transaction transaction = new Transaction() { DestinationAccountId = 1, SourceAccountId = 3458712, Id = 2, Timespan = DateTime.Now, Value = 5M };
            var domainService = new TransactionDomainRules(transaction, source, target);

            // Act and Assert
            Assert.ThrowsException<AccountNotFoundException>(() => domainService.CompleteTransation());
        }


        [TestMethod]
        public void Transaction_Falied_Transfer_To_Destination_account_Not_exist_ThrowAccountNotFoundException()
        {
            // Arrange
            Account source = new Account(1, 10M);
            Account target = null;
            Transaction transaction = new Transaction() { DestinationAccountId = 3458712, SourceAccountId = 1, Id = 2, Timespan = DateTime.Now, Value = 5M };
            var domainService = new TransactionDomainRules(transaction, source, target);

            // Act and Assert
            Assert.ThrowsException<AccountNotFoundException>(() => domainService.CompleteTransation());
        }

        [TestMethod]
        public void Transaction_Completed_Should_be_Falied_ThrowTransactionCompletedException()
        {
            // Arrange
            Account source = new Account(1, 10M);
            Account target = new Account(2, 5M);
            Transaction transaction = new Transaction() { DestinationAccountId = 2, SourceAccountId = 1, Id = 2, Timespan = DateTime.Now, Value = 5M, IsCompleted = true };
            var domainService = new TransactionDomainRules(transaction, source, target);

            // Act and Assert
            Assert.ThrowsException<TransactionCompletedException>(() => domainService.CompleteTransation());
        }

        [TestMethod]
        public void Transaction_Should_be_Falied_Source_Account_No_Balance_Avaliable_ThrowNoBalanceAccountTransactionException()
        {
            // Arrange
            Account source = new Account(1, 4M);
            Account target = new Account(2, 5M); ;
            Transaction transaction = new Transaction() { DestinationAccountId = 2, SourceAccountId = 1, Id = 2, Timespan = DateTime.Now, Value = 5M };
            var domainService = new TransactionDomainRules(transaction, source, target);

            // Act and Assert
            Assert.ThrowsException<NoBalanceAccountTransactionException>(() => domainService.CompleteTransation());
        }

        [TestMethod]
        public void Transaction_Not_exist_ThrowNoBalanceAccountTransactionException()
        {
            // Arrange
            Account source = new Account(1, 10M);
            Account target = new Account(2, 5M);
            var domainService = new TransactionDomainRules(null, source, target);

            // Act and Assert
            Assert.ThrowsException<TransactionNotFoundException>(() => domainService.CompleteTransation());
        }


        [TestMethod]
        public void Transaction_Was_been_success_Should_Be_OK()
        {
            // Arrange
            Account source = new Account(1, 10M);
            Account target = new Account(2, 5M);
            Transaction transaction = new Transaction() { DestinationAccountId = 2, SourceAccountId = 1, Id = 2, Timespan = DateTime.Now, Value = 5M };
            var domainService = new TransactionDomainRules(transaction, source, target);

            // Act 
            domainService.CompleteTransation();
            decimal sourceShouldBeValue = 5M;
            decimal targetShouldBeValue = 10M;


            //Assert
            Assert.AreEqual(domainService.Source.Balance, sourceShouldBeValue);
            Assert.AreEqual(domainService.Destination.Balance, targetShouldBeValue);
        }


    }
}