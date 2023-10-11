using TransactionFlow.Data.Mocks;
using TransactionFlow.Data.Repository;
using TransactionFlow.Service;


var transactionPending = TransactionStaticMock.Instance.Transactions;
// IN FUTURE USE IOC
var transactionFlowService = new TransactionFlowService(new AccountQueryRepository(),
    new AccountCommandRepository(),
    new TransactionCommandRepository(),
    new BalanceAccountHistoryCommandRepository());

Parallel.ForEach(transactionPending, transaction => {

    try
    {
        transactionFlowService.ExecuteTransaction(transaction);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
});
BalanceAccountHistoryStaticMock.Instance.History.ForEach(c => Console.WriteLine(c.ToString()));
