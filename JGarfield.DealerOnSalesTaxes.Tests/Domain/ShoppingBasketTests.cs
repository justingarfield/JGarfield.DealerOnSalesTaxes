using JGarfield.DealerOnSalesTaxes.Library.Domain;
using System;
using Xunit;

namespace JGarfield.DealerOnSalesTaxes.Tests.Domain
{
    public class ShoppingBasketTests
    {
        private const string ITEM1_NAME = "My Sample Item 1";
        private const decimal ITEM1_COST_PER_UNIT = 13.37m;
        private const int ITEM1_QTY = 1;

        /// <summary>
        /// Some places I've worked test default Constructors to ensure logic hasn't 
        /// been added that would prevent DI (or others) from instantiating them.
        /// </summary>
        [Fact]
        public void Can_Instantiate()
        {
            // Arrange
            // Act
            var shoppingBasket = new ShoppingBasket();

            // Assert
            Assert.NotNull(shoppingBasket);
        }

        [Fact]
        public void Instantiates_With_Empty_LineItem_Collection()
        {
            // Arrange
            // Act
            var shoppingBasket = new ShoppingBasket();

            // Assert
            Assert.Empty(shoppingBasket.LineItems);
        }

        [Fact]
        public void AddItem_Successfully_Adds_Item_To_New_LineItem()
        {
            // Arrange
            var shoppingBasket = new ShoppingBasket();
            var item = new Item {
                Name = ITEM1_NAME,
                CostPerUnit = ITEM1_COST_PER_UNIT
            };

            // Act
            shoppingBasket.AddItem(item, ITEM1_QTY);

            // Assert
            Assert.Equal(ITEM1_QTY, shoppingBasket.LineItems[0].Quantity);
            Assert.Equal(ITEM1_NAME, shoppingBasket.LineItems[0].Item.Name);
            Assert.Equal(ITEM1_COST_PER_UNIT, shoppingBasket.LineItems[0].Item.CostPerUnit);
        }

        [Fact]
        public void AddItem_Successfully_Adds_Item_To_Existing_LineItem()
        {
            // Arrange
            var shoppingBasket = new ShoppingBasket();
            var item = new Item
            {
                Name = ITEM1_NAME,
                CostPerUnit = ITEM1_COST_PER_UNIT
            };
            shoppingBasket.AddItem(item, ITEM1_QTY);

            item = new Item
            {
                Name = ITEM1_NAME,
                CostPerUnit = ITEM1_COST_PER_UNIT
            };

            // Act
            shoppingBasket.AddItem(item, 100);

            // Assert
            Assert.Equal(ITEM1_QTY + 100, shoppingBasket.LineItems[0].Quantity);
            Assert.Equal(ITEM1_NAME, shoppingBasket.LineItems[0].Item.Name);
            Assert.Equal(ITEM1_COST_PER_UNIT, shoppingBasket.LineItems[0].Item.CostPerUnit);
        }

        [Fact]
        public void AddItem_Successfully_Adds_New_LineItem_When_CostPerUnit_Differs()
        {
            // Arrange
            var shoppingBasket = new ShoppingBasket();
            var item = new Item
            {
                Name = ITEM1_NAME,
                CostPerUnit = ITEM1_COST_PER_UNIT
            };
            shoppingBasket.AddItem(item, ITEM1_QTY);

            item = new Item
            {
                Name = ITEM1_NAME,
                CostPerUnit = 3000.00m
            };

            // Act
            shoppingBasket.AddItem(item, ITEM1_QTY);

            // Assert
            Assert.Equal(2, shoppingBasket.LineItems.Count);

            Assert.Equal(ITEM1_QTY, shoppingBasket.LineItems[0].Quantity);
            Assert.Equal(ITEM1_NAME, shoppingBasket.LineItems[0].Item.Name);
            Assert.Equal(ITEM1_COST_PER_UNIT, shoppingBasket.LineItems[0].Item.CostPerUnit);

            Assert.Equal(ITEM1_QTY, shoppingBasket.LineItems[1].Quantity);
            Assert.Equal(ITEM1_NAME, shoppingBasket.LineItems[1].Item.Name);
            Assert.Equal(3000.00m, shoppingBasket.LineItems[1].Item.CostPerUnit);
        }
    }
}
