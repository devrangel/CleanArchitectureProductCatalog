using CleanArch.Domain.Entities;
using CleanArch.Domain.Validations;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArch.Domain.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CreateProduct_WithValidArguments_ReturnValidObject()
        {
            Action act = () => new Product(1, "Product Name", "Product Description", 1.99m, 4, "Product Image");

            act.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNegativeId_ThrowDomainExceptionValidation()
        {
            Action act = () => new Product(-1, "Product Name", "Product Description", 1.99m, 4, "Product Image");

            act.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id");
        }

        [Fact]
        public void CreateProduct_WithEmptyName_ThrowDomainExceptionValidation()
        {
            Action act = () => new Product(1, "", "Product Description", 1.99m, 4, "Product Image");

            act.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Name cannot be null or empty");
        }

        [Fact]
        public void CreateProduct_WithNullName_ThrowDomainExceptionValidation()
        {
            Action act = () => new Product(1, null, "Product Description", 1.99m, 4, "Product Image");

            act.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Name cannot be null or empty");
        }

        [Fact]
        public void CreateProduct_WithNameLessThanThree_ThrowDomainExceptionValidation()
        {
            Action act = () => new Product(1, "Pr", "Product Description", 1.99m, 4, "Product Image");

            act.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Name must have at least 3 characters");
        }

        [Fact]
        public void CreateProduct_WithEmptyDescription_ThrowDomainExceptionValidation()
        {
            Action act = () => new Product(1, "Product Name", "", 1.99m, 4, "Product Image");

            act.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Description cannot be null or empty");
        }

        [Fact]
        public void CreateProduct_WithNullDescription_ThrowDomainExceptionValidation()
        {
            Action act = () => new Product(1, "Product Name", null, 1.99m, 4, "Product Image");

            act.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Description cannot be null or empty");
        }

        [Fact]
        public void CreateProduct_WithDescriptionLessThanFive_ThrowDomainExceptionValidation()
        {
            Action act = () => new Product(1, "Product Name", "Les", 1.99m, 4, "Product Image");

            act.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Description must have at least 5 characters");
        }

        [Fact]
        public void CreateCategory_WithNegativePriceValue_ThrowDomainExceptionValidation()
        {
            Action act = () => new Product(1, "Product Name", "Product Description", -1.99m, 4, "Product Image");

            act.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Price");
        }

        [Theory]
        [InlineData(-5)]
        public void CreateCategory_WithNegativeStockValue_ThrowDomainExceptionValidation(int value)
        {
            Action act = () => new Product(1, "Product Name", "Product Description", 1.99m, value, "Product Image");

            act.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Stock");
        }

        [Fact]
        public void CreateProduct_WithImageNameGreaterThan250Chars_ThrowDomainExceptionValidation()
        {
            Action act = () => new Product(1, "Product Name", "Product Description", 1.99m, 4,
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

            act.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Image name must have up to 250 characters");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_ReturnValidObject()
        {
            Action act = () => new Product(1, "Product Name", "Product Description", 1.99m, 4, null);

            act.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_ReturnValidObjectNoNullReferenceException()
        {
            Action act = () => new Product(1, "Product Name", "Product Description", 1.99m, 4, null);

            act.Should()
                .NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_ReturnValidObject()
        {
            Action act = () => new Product(1, "Product Name", "Product Description", 1.99m, 4, "");

            act.Should()
                .NotThrow<DomainExceptionValidation>();
        }
    }
}
