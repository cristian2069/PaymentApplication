using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApplication
{
    public class PremiumPaymentService : IPaymentService
    {
        public void ProcessPaymentService(CreditCard creditCard)
        {
            int attempts = 0;
            while(attempts < 3)
            {
                try
                {
                    attempts++;
                    //throw new Exception();
                    Console.WriteLine("--- Premium Payment has been processed successfully…");

                    //Assuming that the payment was processed up to this point, exit the loop
                    break;
                }
                catch(Exception ex)
                {
                    //unreachable code, only logic for repeating with CheapPaymentService
                    Console.WriteLine($"--- An error occured processing the Premium Payment Service on attempt {attempts}");

                }
            }

            Console.WriteLine("--- Thank you for using our services!");
        }
    }
}
