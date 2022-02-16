using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class RatesUnitTest1
    {
        [Fact(DisplayName ="Create Rate With Valid State")]
        public void CreateRate_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Rates("EUR" ,"USD", 1.359);
            action.Should()
                 .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateRate_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Rates("EUR", "USDF", 1.359);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateRate_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Rates("EU", "USD", 13.59);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                   .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateRate_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Rates("", "USD", 1.359);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name.Name is required");
        }

        [Fact]
        public void CreateRate_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Rates("2", null,0);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
