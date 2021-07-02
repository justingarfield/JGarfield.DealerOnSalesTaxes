using JGarfield.DealerOnSalesTaxes.Library.Domain;
using JGarfield.DealerOnSalesTaxes.Library.Services;
using JGarfield.DealerOnSalesTaxes.Tests.Theories;
using Moq;
using System;
using System.IO;
using Xunit;

namespace JGarfield.DealerOnSalesTaxes.Tests.Services
{
    public class ConsoleOutputReceiptServiceTests
    {
        [Fact]
        public void Constructor_Throws_ArgumentNullException_When_TaxService_Is_Null()
        {
            // Arrange
            Action action = () => new ConsoleOutputReceiptService(null);

            // Act
            var exception = Record.Exception(action);

            // Assert
            Assert.IsType<ArgumentNullException>(exception);
            Assert.Equal("taxService", ((ArgumentNullException)exception).ParamName);
        }

        [Fact]
        public void WriteReceipt_Writes_Zeros_For_Empty_ShoppingBasket()
        {
            // Arrange
            var mockTaxService = Mock.Of<ITaxService>();
            var consoleOutputReceiptService = new ConsoleOutputReceiptService(mockTaxService);
            var shoppingBasket = new ShoppingBasket();

            // Could implement another abstraction for Console and Mock it, but felt this
            // was sufficient enough for the purposes of tests in a sample project.
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            consoleOutputReceiptService.WriteReceipt(shoppingBasket);

            // Assert
            var writtenText = stringWriter.ToString();
            Assert.Contains("Sales Taxes: 0.00", writtenText);
            Assert.Contains("Total: 0.00", writtenText);
        }

        [Fact]
        public void WriteReceipt_Handles_Provided_Output1_Scenarios()
        {
            // Arrange
            var mockTaxService = ProduceMockTaxService();
            var consoleOutputReceiptService = new ConsoleOutputReceiptService(mockTaxService);
            
            var shoppingBasket = new ShoppingBasket();
            shoppingBasket.AddItem(new Item { Name = "Book", CostPerUnit = 12.49m }, 2);
            shoppingBasket.AddItem(new Item { Name = "Music CD", CostPerUnit = 14.99m }, 1);
            shoppingBasket.AddItem(new Item { Name = "Chocolate bar", CostPerUnit = 0.85m }, 1);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            consoleOutputReceiptService.WriteReceipt(shoppingBasket);

            // Assert
            var writtenText = stringWriter.ToString();
            Assert.Contains("Book: 24.98 (2 @ 12.49)", writtenText);
            Assert.Contains("Music CD: 16.49", writtenText);
            Assert.Contains("Chocolate bar: 0.85", writtenText);
            Assert.Contains("Sales Taxes: 1.50", writtenText);
            Assert.Contains("Total: 42.32", writtenText);
        }

        [Fact]
        public void WriteReceipt_Handles_Provided_Output2_Scenarios()
        {
            // Arrange
            var mockTaxService = ProduceMockTaxService();
            var consoleOutputReceiptService = new ConsoleOutputReceiptService(mockTaxService);

            var shoppingBasket = new ShoppingBasket();
            shoppingBasket.AddItem(new Item { Name = "Imported box of chocolates", CostPerUnit = 10.00m }, 1);
            shoppingBasket.AddItem(new Item { Name = "Imported bottle of perfume", CostPerUnit = 47.50m }, 1);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            consoleOutputReceiptService.WriteReceipt(shoppingBasket);

            // Assert
            var writtenText = stringWriter.ToString();
            Assert.Contains("Imported box of chocolates: 10.50", writtenText);
            Assert.Contains("Imported bottle of perfume: 54.65", writtenText);
            Assert.Contains("Sales Taxes: 7.65", writtenText);
            Assert.Contains("Total: 65.15", writtenText);
        }

        [Fact]
        public void WriteReceipt_Handles_Provided_Output3_Scenarios()
        {
            // Arrange
            var mockTaxService = ProduceMockTaxService();
            var consoleOutputReceiptService = new ConsoleOutputReceiptService(mockTaxService);

            var shoppingBasket = new ShoppingBasket();
            shoppingBasket.AddItem(new Item { Name = "Imported bottle of perfume", CostPerUnit = 27.99m }, 1);
            shoppingBasket.AddItem(new Item { Name = "Bottle of perfume", CostPerUnit = 18.99m }, 1);
            shoppingBasket.AddItem(new Item { Name = "Packet of headache pills", CostPerUnit = 9.75m }, 1);
            shoppingBasket.AddItem(new Item { Name = "Imported box of chocolates", CostPerUnit = 11.25m }, 2);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            consoleOutputReceiptService.WriteReceipt(shoppingBasket);

            // Assert
            var writtenText = stringWriter.ToString();
            Assert.Contains("Imported bottle of perfume: 32.19", writtenText);
            Assert.Contains("Bottle of perfume: 20.89", writtenText);
            Assert.Contains("Packet of headache pills: 9.75", writtenText);
            Assert.Contains("Imported box of chocolates: 23.70 (2 @ 11.85)", writtenText);
            Assert.Contains("Sales Taxes: 7.30", writtenText);
            Assert.Contains("Total: 86.53", writtenText);
        }

        private ITaxService ProduceMockTaxService()
        {
            var mockTaxService = Mock.Of<ITaxService>();

            Mock.Get(mockTaxService)
                .Setup(_ => _.CalculateTaxForItem(It.Is<Item>(item => item.Name == "Book" && item.CostPerUnit == 12.49m)))
                .Returns(0.00m);

            Mock.Get(mockTaxService)
                .Setup(_ => _.CalculateTaxForItem(It.Is<Item>(item => item.Name == "Music CD" && item.CostPerUnit == 14.99m)))
                .Returns(1.50m);

            Mock.Get(mockTaxService)
                .Setup(_ => _.CalculateTaxForItem(It.Is<Item>(item => item.Name == "Chocolate bar" && item.CostPerUnit == 0.85m)))
                .Returns(0.00m);

            Mock.Get(mockTaxService)
                .Setup(_ => _.CalculateTaxForItem(It.Is<Item>(item => item.Name == "Imported box of chocolates" && item.CostPerUnit == 10.00m)))
                .Returns(0.50m);

            Mock.Get(mockTaxService)
                .Setup(_ => _.CalculateTaxForItem(It.Is<Item>(item => item.Name == "Imported bottle of perfume" && item.CostPerUnit == 47.50m)))
                .Returns(7.15m);

            Mock.Get(mockTaxService)
                .Setup(_ => _.CalculateTaxForItem(It.Is<Item>(item => item.Name == "Imported bottle of perfume" && item.CostPerUnit == 27.99m)))
                .Returns(4.20m);

            Mock.Get(mockTaxService)
                .Setup(_ => _.CalculateTaxForItem(It.Is<Item>(item => item.Name == "Bottle of perfume" && item.CostPerUnit == 18.99m)))
                .Returns(1.90m);

            Mock.Get(mockTaxService)
                .Setup(_ => _.CalculateTaxForItem(It.Is<Item>(item => item.Name == "Packet of headache pills" && item.CostPerUnit == 9.75m)))
                .Returns(0.00m);

            Mock.Get(mockTaxService)
                .Setup(_ => _.CalculateTaxForItem(It.Is<Item>(item => item.Name == "Imported box of chocolates" && item.CostPerUnit == 11.25m)))
                .Returns(0.60m);

            return mockTaxService;
        }
    }
}
