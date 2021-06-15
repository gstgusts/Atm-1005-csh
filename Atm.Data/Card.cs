using System;
using System.Collections.Generic;
using System.Text;

namespace Atm.Data
{
    public class Card
    {
        public Card(int pin, Customer customer, string number)
        {
            _pin = pin;
            Customer = customer;
            Number = number;
        }

        private int _pin;

        public Customer Customer { get; private set; }

        public string Number { get; private set; }

        public bool IsPinValid(int pin)
        {
            return pin == _pin;
        }
    }
}
