using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApplication
{
    public class CheapPaymentService : IPaymentService
    {
        public void ProcessPaymentService(CreditCard creditCard)
        {
            try
            {

                Console.WriteLine(creditCard.ValidateTransaction() == string.Empty ? "--- Cheap Payment has been processed successfully…" : creditCard.ValidateTransaction());

            }
            catch(Exception ex)
            {
                Console.WriteLine("--- An error occured processing the Cheap Payment Service..");
            }
            finally
            {
                Console.WriteLine("--- Thank you for using our services!");
            }

        }
    }
}
