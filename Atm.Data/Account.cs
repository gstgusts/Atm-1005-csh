using System;
using System.Collections.Generic;
using System.Text;

namespace Atm.Data
{
    public class Account
    {
        public Account(string number, double balance)
        {
            Number = number;
            Balance = balance;
        }

        public string Number { get; private set; }
        public double Balance { get; private set; }

        public WithdrawResultEnum Withdraw(int amount)
        {
            if(Balance < amount)
            {
                return WithdrawResultEnum.NotEnoughtMoney;
            }

            Balance -= amount;

            return WithdrawResultEnum.TakeYourMoney;
        } 
    }
}
