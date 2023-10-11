using TransactionFlow.Domain.Entities;

namespace TransactionFlow.Data.Mocks
{
    internal class TransactionStaticMock
    {
        private static TransactionStaticMock _instance = null;
        internal static TransactionStaticMock Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TransactionStaticMock();
                }
                return _instance;
            }
        }

        public Transaction[] Transactions { get; set; }

        public TransactionStaticMock()
        {
            InstanceTransactions();
        }

        private void InstanceTransactions()
        {
            this.Transactions = new Transaction[] {
                   new Transaction {Id= 1,Timespan =DateTime.Parse("09/09/2023 14:15:00"), SourceAccountId = 938485762, DestinationAccountId= 2147483649, Value= 150},
                   new Transaction {Id= 2,Timespan =DateTime.Parse("09/09/2023 14:15:05"), SourceAccountId = 2147483649, DestinationAccountId= 210385733, Value= 149},
                   new Transaction {Id= 3,Timespan =DateTime.Parse("09/09/2023 14:15:29"), SourceAccountId = 347586970, DestinationAccountId= 238596054, Value= 1100},
                   new Transaction {Id= 4,Timespan =DateTime.Parse("09/09/2023 14:17:00"), SourceAccountId = 675869708, DestinationAccountId= 210385733, Value= 5300},
                   new Transaction {Id= 5,Timespan =DateTime.Parse("09/09/2023 14:18:00"), SourceAccountId = 238596054, DestinationAccountId= 674038564, Value= 1489},
                   new Transaction {Id= 6,Timespan =DateTime.Parse("09/09/2023 14:18:20"), SourceAccountId = 573659065, DestinationAccountId= 563856300, Value= 49},
                   new Transaction {Id= 7,Timespan =DateTime.Parse("09/09/2023 14:19:00"), SourceAccountId = 938485762, DestinationAccountId= 2147483649, Value= 44},
                   new Transaction {Id= 8,Timespan =DateTime.Parse("09/09/2023 14:19:01"), SourceAccountId = 573659065, DestinationAccountId= 675869708, Value= 150},
            };
        }

    }
}
