using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PaymentApplication.Repositories
{
    public class CreditCardRepository : IRepository
    {
        public void Insert(CreditCard creditCard)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(@".\Transactions.xml");

                XmlElement root = xmlDoc.DocumentElement;

                XmlNode transaction = xmlDoc.CreateElement("Payment");

                XmlNode creditCardNumber = xmlDoc.CreateElement("CreditCardNumber");
                XmlAttribute creditCardNumberAttribute = xmlDoc.CreateAttribute("Type");
                creditCardNumberAttribute.Value = "String";
                creditCardNumber.Attributes.Append(creditCardNumberAttribute);
                creditCardNumber.InnerText = creditCard.CreditCardNumber;

                XmlNode cardHolder = xmlDoc.CreateElement("CardHolder");
                XmlAttribute cardHolderAttribute = xmlDoc.CreateAttribute("Type");
                cardHolderAttribute.Value = "String";
                cardHolder.Attributes.Append(cardHolderAttribute);
                cardHolder.InnerText = creditCard.CardHolder;

                XmlNode expirationDate = xmlDoc.CreateElement("ExpirationDate");
                XmlAttribute expirationDateAttribute = xmlDoc.CreateAttribute("Type");
                expirationDateAttribute.Value = "DateTime";
                expirationDate.Attributes.Append(expirationDateAttribute);
                expirationDate.InnerText = creditCard.ExpirationDate.ToString();

                XmlNode amount = xmlDoc.CreateElement("Amount");
                XmlAttribute amountAttribute = xmlDoc.CreateAttribute("Type");
                amountAttribute.Value = "Decimal";
                amount.Attributes.Append(amountAttribute);
                amount.InnerText = creditCard.Amount.ToString();

                XmlNode createDate = xmlDoc.CreateElement("CreateDate");
                XmlAttribute createDateAttribute = xmlDoc.CreateAttribute("Type");
                createDateAttribute.Value = "DateTime";
                createDate.Attributes.Append(createDateAttribute);
                createDate.InnerText = DateTime.Now.ToString();

                transaction.AppendChild(creditCardNumber);
                transaction.AppendChild(cardHolder);
                transaction.AppendChild(expirationDate);
                transaction.AppendChild(amount);
                transaction.AppendChild(createDate);

                root.AppendChild(transaction);

                xmlDoc.Save(@".\Transactions.xml");

                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine(@"--- XML File successfully updated in \bin\Debug\netcoreapp2.1\Transactions.xml file");
            }
            catch(Exception ex)
            {
                Console.WriteLine("--- An error ocurred regarding the XML Data Save : " + ex.Message);
            }
        }
    }
}
