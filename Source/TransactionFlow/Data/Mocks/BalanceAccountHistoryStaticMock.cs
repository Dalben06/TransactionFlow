using TransactionFlow.Domain.Entities;

namespace TransactionFlow.Data.Mocks
{
    internal class BalanceAccountHistoryStaticMock
    {
        private static BalanceAccountHistoryStaticMock _instance = null;
        internal static BalanceAccountHistoryStaticMock Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BalanceAccountHistoryStaticMock();
                }
                return _instance;
            }
        }

        public List<BalanceAccountHistory> History { get; set; }

        public BalanceAccountHistoryStaticMock()
        {
            InstanceAccounts();
        }

        private void InstanceAccounts()
        {
            this.History = new List<BalanceAccountHistory> {
                   new BalanceAccountHistory(938485762, 180),
                   new BalanceAccountHistory(347586970, 1200),
                   new BalanceAccountHistory(2147483649, 0),
                   new BalanceAccountHistory(675869708, 4900),
                   new BalanceAccountHistory(238596054, 478),
                   new BalanceAccountHistory(573659065, 787),
                   new BalanceAccountHistory(210385733, 10),
                   new BalanceAccountHistory(674038564, 400),
                   new BalanceAccountHistory(563856300, 1200),
            };
        }
    }
}
