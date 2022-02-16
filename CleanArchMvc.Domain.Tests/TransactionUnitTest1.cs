using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class TransactionUnitTest1
    {
        [Fact]
        public void CreateTrtansaction_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Transaction("B2009", -21.23, "USD");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateTrtansaction_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Transaction("2009", 21.23, "USD");

            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

     

    }
}
