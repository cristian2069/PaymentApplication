using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApplication
{
    public class ExpensivePaymentService : IPaymentService
    {
        public void ProcessPaymentService(CreditCard creditCard)
        {
            try
            {
                //throw new Exception();
                Console.WriteLine(creditCard.ValidateTransaction() == string.Empty ? "--- Expensive Payment has been processed successfully…" : creditCard.ValidateTransaction());
            }
            catch (Exception ex)
            {
                //unreachable code, only logic for repeating with CheapPaymentService
                Console.WriteLine("--- An error ocurred processing the Expensive Payment Service. Trying to process the Cheap Payment Service..");
                CheapPaymentService cps = new CheapPaymentService();
                cps.ProcessPaymentService(creditCard);
            }
            finally
            {
                Console.WriteLine("--- Thank you for using our services!");
            }
        }
    }
}
