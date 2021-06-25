using CleanArch.Domain.Entities;
using CleanArch.Domain.Validations;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArch.Domain.Tests
{
    public class CategoryTests
    {
        [Fact]
        public void CreateCategory_WithValidArguments_ReturnValidObject()
        {
            Action act = () => new Category(1, "Books");

            act.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_WithNegativeId_ThrowDomainExceptionValidation()
        {
            Action act = () => new Category(-1, "Books");

            act.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id");
        }

        [Fact]
        public void CreateCategory_WithNameLessThanThree_ThrowDomainExceptionValidation()
        {
            Action act = () => new Category(1, "Bo");

            act.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Name must have at least 3 characters");
        }

        [Fact]
        public void CreateCategory_WithEmptyName_ThrowDomainExceptionValidation()
        {
            Action act = () => new Category(1, "");

            act.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Name cannot be null or empty");
        }

        [Fact]
        public void CreateCategory_WithNullName_ThrowDomainExceptionValidation()
        {
            Action act = () => new Category(1, null);

            act.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Name cannot be null or empty");
        }
    }
}
