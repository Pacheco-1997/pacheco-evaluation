using System;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Value_Objects;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.TestData
{
    public static class UpdateSaleHandlerTestData
    {
        private static readonly Faker Faker = new Faker("pt_BR");

        public static UpdateSaleCommand ValidCommand(Guid saleId)
        {
            var customerId = Guid.NewGuid();
            var branchId = Guid.NewGuid();
            var saleDate = Faker.Date.Recent();

            var itemFaker = new Faker<UpdateSaleItemCommand>(locale: "pt_BR")
                .RuleFor(i => i.ProductId, f => Guid.NewGuid())
                .RuleFor(i => i.Quantity, f => f.Random.Int(1, 5))
                .RuleFor(i => i.UnitPrice, f => f.Finance.Amount(10, 100))
                .RuleFor(i => i.IsCancelled, f => false);

            var items = itemFaker.Generate(3);

            return new UpdateSaleCommand
            {
                Id = saleId,
                CustomerId = customerId,
                BranchId = branchId,
                SaleDate = saleDate,
                IsCancelled = false,
                Items = items
            };
        }

        public static User ValidUser(Guid id)
        {
            return new User
            {
                Id = id,
                Name = new Name(Faker.Name.FirstName(), Faker.Name.LastName()),
                Email = Faker.Internet.Email(),
                Username = Faker.Internet.UserName(),
                Phone = Faker.Phone.PhoneNumber("(##) #####-####"),
                Password = "Senha@123",
                Role = UserRole.Customer,
                Status = UserStatus.Active,
                CreatedAt = DateTime.UtcNow
            };
        }

        public static Branch ValidBranch(Guid id)
        {
            return new Branch
            {
                Id = id,
                Name = Faker.Company.CompanyName(),
                Address = new Address(
                    Faker.Address.City(),
                    Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()),
                    Faker.Address.ZipCode(),
                    new Geolocation(Faker.Address.Latitude().ToString(), Faker.Address.Longitude().ToString())
                ),
                CreatedAt = DateTime.UtcNow
            };
        }

        public static Product ValidProduct(Guid id, decimal price)
        {
            return new Product
            {
                Id = id,
                Title = Faker.Commerce.ProductName(),
                Description = Faker.Commerce.ProductDescription(),
                Category = Faker.Commerce.Categories(1)[0],
                ImageUrl = Faker.Internet.Url(),
                UnitPrice = price,
                RatingRate = Faker.Random.Decimal(0, 5),
                RatingCount = Faker.Random.Int(0, 1000),
                CreatedAt = DateTime.UtcNow
            };
        }

        public static Sale ExistingSale(Guid saleId, Guid customerId, Guid branchId, List<UpdateSaleItemCommand> items)
        {
            var saleItems = items.Select(i =>
                (i.ProductId, "Produto Teste", i.UnitPrice, i.Quantity)
            ).ToList();

            var sale = Sale.Create(
                customerId,
                "Cliente Teste",
                branchId,
                "Filial Teste",
                DateTime.UtcNow.AddDays(-1),
                saleItems
            );

            sale.Id = saleId;
            return sale;
        }

    }
}
