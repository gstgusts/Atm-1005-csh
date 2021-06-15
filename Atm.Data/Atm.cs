using System;
using System.Collections.Generic;
using System.Linq;

namespace Atm.Data
{
    public class Atm
    {
        const string AccountNotSet = "Current account is not set";

        public Atm(int balance, List<Customer> customers)
        {
            _balance = balance;
            _customers = customers;
        }

        private int _balance;

        private List<Customer> _customers = new List<Customer>();

        private Customer _currentCustomer;

        private Account _currentAccount;

        public bool Start(Card card, int pin)
        {
            if(card.IsPinValid(pin))
            {
                var customer = _customers.FirstOrDefault(c => c.Id == card.Customer.Id);

                if(customer == null) {
                    return false;
                }

                _currentCustomer = customer;
                return true;
            } else
            {
                return false;
            }
        }

        public void SetAccount(string number)
        {
            if(_currentCustomer == null)
            {
                return;
            }

            _currentAccount = _currentCustomer.Accounts.FirstOrDefault(a => a.Number == number);
        }

        public void Exit()
        {
            _currentCustomer = null;
            _currentAccount = null;
        }

        public double PeekBalance()
        {
            if(_currentAccount == null)
            {
                throw new ArgumentNullException(AccountNotSet);
            }

            return _currentAccount.Balance;
        }

        public WithdrawResultEnum Withdraw(int amount)
        {
            if(amount <= 0)
            {
                throw new ArgumentException("Invalid amount");
            }

            if(_balance < amount)
            {
                return WithdrawResultEnum.NoMoneyInAtm;
            }

            if(_currentAccount == null)
            {
                throw new ArgumentNullException(AccountNotSet);
            }

            var result = _currentAccount.Withdraw(amount);

            if(result == WithdrawResultEnum.TakeYourMoney)
            {
                _balance -= amount;
            }

            return result;
        }
    }
}
