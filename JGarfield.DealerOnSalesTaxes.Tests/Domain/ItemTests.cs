using JGarfield.DealerOnSalesTaxes.Library.Domain;
using Xunit;

namespace JGarfield.DealerOnSalesTaxes.Tests.Domain
{
    public class ItemTests
    {
        /// <summary>
        /// Some places I've worked test Getters/Setters in the event
        ///  that someone decides to add logic to them down the road.
        /// </summary>
        [Fact]
        public void Can_Get_Set_Properties()
        {
            var item = new Item
            {
                CostPerUnit = 13.37m,
                IsImported = true,
                ItemType = ItemType.Medical,
                Name = "Some Random Item"
            };

            Assert.Equal(13.37m, item.CostPerUnit);
            Assert.True(item.IsImported);
            Assert.Equal(ItemType.Medical, item.ItemType);
            Assert.Equal("Some Random Item", item.Name);
        }
    }
}
