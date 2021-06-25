﻿using CleanArch.Domain.Validations;

namespace CleanArch.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id");
            ValidateDomain(name, description, price, stock, image);
            Id = id;
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name cannot be null or empty");
            DomainExceptionValidation.When(name.Length < 3, "Name must have at least 3 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description cannot be null or empty");
            DomainExceptionValidation.When(description.Length < 5, "Description must have at least 5 characters");
            DomainExceptionValidation.When(price < 0, "Invalid Price");
            DomainExceptionValidation.When(stock < 0, "Invalid Stock");
            DomainExceptionValidation.When(image?.Length > 250, "Image name must have up to 250 characters");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
    }
}
