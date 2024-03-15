using Domain.Entities;
using Domain.Utils.ErrorMessages;
using FluentAssertions;

namespace Tests.Domain.Entities
{
    public class CustomerTest
    {
        [Fact]
        [Trait("Customer", "Deve retornar erro quando nome for vazio ou nulo")]
        public void Customer_ShouldReturnErrorWhenNameIsNullOrEmpty()
        {
            var customer = Customer.Create(string.Empty, "12365478910", "teste@teste.com");
            customer.Errors.Any(x => x.Code == 40000 && x.Message == DomainErrorMessages.NameIsRequired).Should().BeTrue();
        }

        [Fact]
        [Trait("Customer", "Deve retornar erro quando documento for vazio ou nulo")]
        public void Customer_ShouldReturnErrorWhenDocumentIsNullOrEmpty()
        {
            var customer = Customer.Create("Teste", string.Empty, "teste@teste.com");
            customer.Errors.Any(x => x.Code == 40000 && x.Message == DomainErrorMessages.DocumentIsNotValid).Should().BeTrue();
        }

        [Fact]
        [Trait("Customer", "Deve retornar erro quando documento não for CPF")]
        public void Customer_ShouldReturnErrorWhenDocumentLengthIsNotValid()
        {
            var customer = Customer.Create("Teste", "12365478a12", "teste@teste.com");
            customer.Errors.Any(x => x.Code == 40000 && x.Message == DomainErrorMessages.DocumentIsNotValid).Should().BeTrue();
        }

        [Fact]
        [Trait("Customer", "Deve retornar erro quando email for vazio ou nulo")]
        public void Customer_ShouldReturnErrorWhenEmailIsNullOrEmpty()
        {
            var customer = Customer.Create("Teste", "12365478212", string.Empty);
            customer.Errors.Any(x => x.Code == 40000 && x.Message == DomainErrorMessages.EmailIsRequired).Should().BeTrue();
        }

        [Fact]
        [Trait("Customer", "Deve retornar erro quando email for vazio ou nulo")]
        public void Customer_ShouldReturnErrorWhenEmailIsNotValid()
        {
            var customer = Customer.Create("Teste", "12365478212", "teste.com.br");
            customer.Errors.Any(x => x.Code == 40000 && x.Message == DomainErrorMessages.EmailIsNotValid).Should().BeTrue();
        }
    }
}
