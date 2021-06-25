using CleanArch.Domain.Validations;
using System.Collections.Generic;

namespace CleanArch.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id");
            ValidateDomain(name);

            Id = id;
        }

        public void UpdateName(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name cannot be null or empty");
            DomainExceptionValidation.When(name.Length < 3, "Name must have at least 3 characters");

            Name = name;
        }
    }
}
