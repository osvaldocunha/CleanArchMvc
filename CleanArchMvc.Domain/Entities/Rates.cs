using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Rates : Entity
    {
        public Rates(int id, string from, string to, double rate)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            DomainExceptionValidation.When(rate < 0, "Invalid Id value.");
            ValidateDomain(from);
            ValidateDomain(to);
            From = from;
            To = to;
            Id = id;
        }

        public string From { get; set; }
        public string To { get; set; }
        public double Rate { get; set; }
       
       // public ICollection<Transaction> Transaction { get; set; }

        private void ValidateDomain(string val)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(val),
                "Invalid name.Name is required");

            DomainExceptionValidation.When(val.Length != 3,
               "Invalid name, too short, minimum 3 characters");
       
        }
    }
}
