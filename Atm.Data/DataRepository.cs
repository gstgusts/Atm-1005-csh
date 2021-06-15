using System;
using System.Collections.Generic;
using System.Text;

namespace Atm.Data
{
    public class DataRepository
    {
        public static List<Customer> GetCustomers()
        {
            var cust1 = new Customer("111", "Gusts", "Link");
            cust1.AddAccount(new Account("111-1", 500));
            cust1.AddAccount(new Account("111-2", 200));

            var cust2 = new Customer("222", "Janis", "Ozols");
            cust2.AddAccount(new Account("222-1", 100));
            cust2.AddAccount(new Account("222-2", 50));

            var cust3 = new Customer("333", "Baiba", "Liepa");
            cust3.AddAccount(new Account("333-1", 50));
            cust3.AddAccount(new Account("333-2", 3000));

            return new List<Customer>()
            {
                cust1,
                cust2,
                cust3
            };
        }

        public static List<Card> GetCards()
        {
            var cust1 = new Customer("111", "Gusts", "Link");
            var cust2 = new Customer("222", "Janis", "Ozols");
            var cust3 = new Customer("333", "Baiba", "Liepa");

            var card1 = new Card(1111, cust1, "111");
            var card2 = new Card(2222, cust2, "222");
            var card3 = new Card(3333, cust3, "333");

            return new List<Card>()
            {
                card1,
                card2,
                card3
            };
        }
    }
}
