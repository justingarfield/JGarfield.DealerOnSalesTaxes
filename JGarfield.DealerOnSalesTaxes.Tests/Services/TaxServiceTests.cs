using JGarfield.DealerOnSalesTaxes.Library.Domain;
using JGarfield.DealerOnSalesTaxes.Library.Services;
using JGarfield.DealerOnSalesTaxes.Tests.Theories;
using Xunit;

namespace JGarfield.DealerOnSalesTaxes.Tests.Services
{
    public class TaxServiceTests
    {
        [Fact]
        public void CalculateTaxForItem_Does_Not_Apply_SalesTax_To_Exempt_Items()
        {
            // Arrange
            var taxService = new TaxService();

            var item = new Item {
                CostPerUnit = 100.00m,
                ItemType = ItemType.Book
            };

            // Act
            var calculatedItemTax = taxService.CalculateTaxForItem(item);

            // Assert
            Assert.Equal(0.00m, calculatedItemTax);
        }

        [Fact]
        public void CalculateTaxForItem_Applies_SalesTax_To_NonExempt_Items()
        {
            // Arrange
            var taxService = new TaxService();

            var item = new Item
            {
                CostPerUnit = 100.00m,
                ItemType = ItemType.Other
            };

            // Act
            var calculatedItemTax = taxService.CalculateTaxForItem(item);

            // Assert
            Assert.Equal(10.00m, calculatedItemTax);
        }

        [Fact]
        public void CalculateTaxForItem_Applies_ImportTax_To_All_Items()
        {
            // Arrange
            var taxService = new TaxService();

            var item = new Item
            {
                CostPerUnit = 100.00m,
                ItemType = ItemType.Book,
                IsImported = true
            };

            // Act
            var calculatedItemTax = taxService.CalculateTaxForItem(item);

            // Assert
            Assert.Equal(5.00m, calculatedItemTax);
        }

        [Fact]
        public void CalculateTaxForItem_Applies_Both_SalesTax_And_ImportTax()
        {
            // Arrange
            var taxService = new TaxService();

            var item = new Item
            {
                CostPerUnit = 100.00m,
                ItemType = ItemType.Other,
                IsImported = true
            };

            // Act
            var calculatedItemTax = taxService.CalculateTaxForItem(item);

            // Assert
            Assert.Equal(15.00m, calculatedItemTax);
        }

        [Theory]
        [ClassData(typeof(SalesTax_Rounding_Theory))]
        public void CalculateTaxForItem_Rounds_SalesTax_Up_To_Nearest_5Cents(decimal costPerUnit, decimal expectedTaxAmount)
        {
            // Arrange
            var taxService = new TaxService();

            var item = new Item
            {
                CostPerUnit = costPerUnit,
                ItemType = ItemType.Other
            };

            // Act
            var calculatedItemTax = taxService.CalculateTaxForItem(item);

            // Assert
            Assert.Equal(expectedTaxAmount, calculatedItemTax);
        }
    }
}
