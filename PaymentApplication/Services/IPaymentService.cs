using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApplication
{
    interface IPaymentService
    {
         //creditCard is an unused object in the future implementations, but i passed it for the business logic
         void ProcessPaymentService(CreditCard creditCard);
    }
}
