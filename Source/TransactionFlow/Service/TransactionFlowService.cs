using TransactionFlow.Data.Repository;
using TransactionFlow.Domain.DomainExpections;
using TransactionFlow.Domain.DomainService;
using TransactionFlow.Domain.Entities;
using TransactionFlow.Domain.IRepository;

namespace TransactionFlow.Service
{
    public class TransactionFlowService
    {
        private readonly IAccountQueryRepository _accountQueryRepository;
        private readonly IAccountCommandRepository _accountCommandRepository;
        private readonly ITransactionCommandRepository _transactionCommandRepository;
        private readonly IBalanceAccountHistoryCommandRepository _balanceAccountHistoryCommandRepository;

        public TransactionFlowService(IAccountQueryRepository accountQueryRepository,
            IAccountCommandRepository accountCommandRepository,
            ITransactionCommandRepository transactionCommandRepository,
            IBalanceAccountHistoryCommandRepository balanceAccountHistoryCommandRepository)
        {
            _accountQueryRepository = accountQueryRepository;
            _accountCommandRepository = accountCommandRepository;
            _transactionCommandRepository = transactionCommandRepository;
            _balanceAccountHistoryCommandRepository = balanceAccountHistoryCommandRepository;
        }

        public void ExecuteTransaction(Transaction transaction)
        {

            if (transaction == null) throw new TransactionNotFoundException();

            var domainService = new TransactionDomainRules(transaction,
                _accountQueryRepository.GetAccountById(transaction.SourceAccountId),
                _accountQueryRepository.GetAccountById(transaction.SourceAccountId));
            domainService.CompleteTransation();

            try
            {
                using (var scope = new System.Transactions.TransactionScope())
                {
                    _accountCommandRepository.SaveBalance(domainService.Source);
                    _accountCommandRepository.SaveBalance(domainService.Destination);
                    _transactionCommandRepository.CompleteTransaction(domainService.Transaction);
                    _balanceAccountHistoryCommandRepository.AddHistory(domainService.Source.Id, domainService.Source.Balance);
                    _balanceAccountHistoryCommandRepository.AddHistory(domainService.Destination.Id, domainService.Destination.Balance);
                    scope.Complete();
                }
            }
            catch (Exception e)
            {
                // add log in original Expection :D
                throw new Exception($"It's not possible complete transaction, please try again later. {transaction.Id}");
            }

        }

    }
}
