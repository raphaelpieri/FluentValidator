using System;
using FluentValidator.FluentValidator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentValidator.Test
{
    [TestClass]
    public class FluentValidatorTests
    {
        private readonly Customer _customer = new Customer();

        [TestMethod]
        public void IsRequired()
        {
            new ValidationContract<Customer>(_customer).IsRequired(x => x.Name);
            ValidateIfCustomerIsValid();
        }

        [TestMethod]
        public void HasMinLength()
        {
            _customer.Name = "R";
            new ValidationContract<Customer>(_customer).HasMinLenght(x => x.Name, 10);
            ValidateIfCustomerIsValid();
        }

        [TestMethod]
        public void HasMaxLength()
        {
            _customer.Name = "Raphael De Pieri";
            new ValidationContract<Customer>(_customer).HasMaxLenght(x => x.Name, 1);
            ValidateIfCustomerIsValid();
        }

        [TestMethod]
        public void IsFixedLenght()
        {
            _customer.Name = "Raphael De Pieri";
            new ValidationContract<Customer>(_customer).IsFixedLenght(x => x.Name, 5);
            ValidateIfCustomerIsValid();
        }

        [TestMethod]
        public void IsEmail()
        {
            _customer.Name = "This is not an e-mail";
            new ValidationContract<Customer>(_customer).IsEmail(x => x.Name);
            ValidateIfCustomerIsValid();
        }

        [TestMethod]
        public void IsUrl()
        {
            _customer.Name = "This is not an URL";
            new ValidationContract<Customer>(_customer).IsUrl(x => x.Name);
            ValidateIfCustomerIsValid();
        }

        private void ValidateIfCustomerIsValid()
        {
            Assert.IsFalse(_customer.IsValid());
        }
    }
    public class Customer : Notifiable
    {
        public string Name { get; set; }
    }
}
