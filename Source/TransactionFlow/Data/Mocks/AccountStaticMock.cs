using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionFlow.Domain.Entities;

namespace TransactionFlow.Data.Mocks
{
    internal class AccountStaticMock
    {
        private static AccountStaticMock _instance = null;
        internal static AccountStaticMock Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountStaticMock();
                }
                return _instance;
            }
        }

        public List<Account> Accounts { get; set; }

        public AccountStaticMock()
        {
            InstanceAccounts();
        }

        private void InstanceAccounts()
        {
            this.Accounts = new List<Account> {
                   new Account(938485762, 180),
                   new Account(347586970, 1200),
                   new Account(2147483649, 0),
                   new Account(675869708, 4900),
                   new Account(238596054, 478),
                   new Account(573659065, 787),
                   new Account(210385733, 10),
                   new Account(674038564, 400),
                   new Account(563856300, 1200),
            };
        }

    }
}
