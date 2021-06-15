using System;
using System.Collections.Generic;
using System.Text;

namespace Atm.Data
{
    public class Customer
    {
        public Customer(string id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }

        private List<Account> _accounts = new List<Account>();

        public string Id { get; private set; }

        public string Name { get; private set; }
        
        public string Surname { get; private set; }

        public IEnumerable<Account> Accounts => _accounts;

        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }
    }
}
