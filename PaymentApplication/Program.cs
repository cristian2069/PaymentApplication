using log4net;
using System;

namespace PaymentApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            CreditCard creditCard1 = new CreditCard("12341234123412", "Cristian", new DateTime(2018,12,12), null, 20);
            ProcessPaymentController.ProcessPayment(creditCard1);

            Console.WriteLine("---------------------------------------------------");

            CreditCard creditCard2 = new CreditCard("1234123412341234", "Cristian", new DateTime(2019, 12, 12), null, 50);
            ProcessPaymentController.ProcessPayment(creditCard2);
        }
    }
}
