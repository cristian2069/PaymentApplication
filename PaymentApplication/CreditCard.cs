using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentApplication
{
    public class CreditCard
    {
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int? SecurityCode { get; set; }
        public decimal Amount { get; set; }

        public CreditCard(string creditCardNumber, string cardHolder, DateTime expirationDate, int? securityCode, decimal amount)
        {
            this.CreditCardNumber = creditCardNumber;
            this.CardHolder = cardHolder;
            this.ExpirationDate = expirationDate;
            this.SecurityCode = securityCode;
            this.Amount = amount;
        }

        public string ValidateTransaction()
        {
            string errors = string.Empty;

            if (CreditCardNumber.Length != 16 || !IsAllDigits(CreditCardNumber))
                errors += "--- CreditCardNumber should contain only 16 digits\n";

            if (CardHolder == null || CardHolder.Equals(string.Empty))
                errors += "--- Please provide a card holder\n";

            if (ExpirationDate < DateTime.Now)
                errors += "--- ExpirationDate cannot be a past date\n";

            if (SecurityCode != null && Math.Floor(Math.Log10(Convert.ToInt32(SecurityCode)) + 1) != 3)
                errors += "--- SecurityCode should contain only 3 digits\n";

            if (Amount <= 0)
                errors += "--- Please provice a valid amount\n";

            return errors;
        }

        private bool IsAllDigits(string cardNumber)
        {
            return cardNumber.All(char.IsDigit);
        }
    }
}
