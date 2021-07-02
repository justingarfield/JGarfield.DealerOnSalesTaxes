using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace JGarfield.DealerOnSalesTaxes.Library.Domain
{
    /// <summary>
    /// Represents a Shopping Basket that can have Items added to it.
    /// </summary>
    public class ShoppingBasket
    {
        /// <summary>
        /// Holds the LineItems collection.
        /// </summary>
        private List<ShoppingBasketLineItem> _shoppingBasketLineItems;

        /// <summary>
        /// The <see cref="ShoppingBasket"/>'s current LineItems.
        /// </summary>
        public ReadOnlyCollection<ShoppingBasketLineItem> LineItems => _shoppingBasketLineItems.AsReadOnly();

        /// <summary>
        /// Instantiates a new <see cref="ShoppingBasket"/>.
        /// </summary>
        public ShoppingBasket()
        {
            _shoppingBasketLineItems = new List<ShoppingBasketLineItem>();
        }

        /// <summary>
        /// Adds an Item to the Shopping Basket.
        /// <br /><br />
        /// Note: If the item with the same Name and CostPerUnit is already in the basket, 
        /// its corresponding Line Item Quantity is simply increased.
        /// </summary>
        /// <param name="item">The item to add to the basket.</param>
        /// <param name="quantity">The quantity of the item to add to the basket.</param>
        public void AddItem(Item item, int quantity)
        {
            var existingLineItem = _shoppingBasketLineItems
                                        .FirstOrDefault(sbli => 
                                            sbli.Item.Name == item.Name 
                                            && sbli.Item.CostPerUnit == item.CostPerUnit
                                        );

            if (existingLineItem == null)
            {
                _shoppingBasketLineItems.Add(new ShoppingBasketLineItem
                {
                    Item = item,
                    Quantity = quantity
                });
            }
            else
            {
                existingLineItem.Quantity += quantity;
            }
        }
    }
}
