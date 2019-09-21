using PaymentApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApplication
{
    public static class ProcessPaymentController
    {
        public static void ProcessPayment(CreditCard creditCard)
        {
            string processErrors = creditCard.ValidateTransaction();
            if (processErrors != string.Empty)
            {
                Console.WriteLine(processErrors);
                return;
            }
            else
            {
                IPaymentService paymentService;
                if (creditCard.Amount < 21)
                {
                    paymentService = new CheapPaymentService();
                    paymentService.ProcessPaymentService(creditCard);
                }

                else if (creditCard.Amount <= 500)
                {
                    paymentService = new ExpensivePaymentService();
                    paymentService.ProcessPaymentService(creditCard);
                }

                else if (creditCard.Amount > 500)
                {
                    paymentService = new PremiumPaymentService();
                    paymentService.ProcessPaymentService(creditCard);
                }

                CreditCardRepository creditCardRepository = new CreditCardRepository();
                creditCardRepository.Insert(creditCard);
            }
        }
    }
}
