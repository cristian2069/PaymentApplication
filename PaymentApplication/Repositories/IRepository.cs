using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApplication.Repositories
{
    interface IRepository
    {
        void Insert(CreditCard creditCard);
    }
}
