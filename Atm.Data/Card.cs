using System;
using System.Collections.Generic;
using System.Text;

namespace Atm.Data
{
    public class Card
    {
        public Card(int pin, Customer customer)
        {
            _pin = pin;
            Customer = customer;
        }

        private int _pin;

        public Customer Customer { get; private set; }

        public bool IsPinValid(int pin)
        {
            return pin == _pin;
        }
    }
}
