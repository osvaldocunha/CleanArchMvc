using CleanArchMvc.Domain.Validation;
using System.Text.Json.Serialization;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Transaction
    {
        public string Sku { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }

        public Transaction(string sku, double amount, string currency)
        {
            DomainExceptionValidation.When(sku.IndexOfAny(new char[] { 'B', 'M', 'T', 'R' }) != -1, "Invalid Id value.");
            Sku = sku;
            Amount = amount;

            ValidateDomain(amount, currency);
        }

        private void ValidateDomain( double amount, string currency)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(currency),
                "Currency is required");

            DomainExceptionValidation.When(currency.Length < 3,
               "Invalid name, too short, minimum 3 characters");

            DomainExceptionValidation.When(amount < 0, "Invalid amount value");
            Currency = currency;
            Amount = amount;
        }

    }
}
