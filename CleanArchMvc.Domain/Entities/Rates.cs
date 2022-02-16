using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Rates : Entity
    {
        public string Name { get; private set; }

        public Rates(string name)
        {
            ValidateDomain(name);
        }

        public Rates(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }
        public ICollection<Transaction> Transaction { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name.Name is required");

            DomainExceptionValidation.When(name.Length < 3,
               "Invalid name, too short, minimum 3 characters");

            Name = name;
        }
    }
}
