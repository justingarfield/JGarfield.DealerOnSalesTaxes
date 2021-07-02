namespace JGarfield.DealerOnSalesTaxes.Library.Domain
{
    /// <summary>
    /// Represents a LineItem in a Shopping Basket.
    /// </summary>
    public class ShoppingBasketLineItem
    {
        /// <summary>
        /// The Item the LineItem references.
        /// </summary>
        public Item Item { get; set; }

        /// <summary>
        /// The quantity of the LineItem.
        /// </summary>
        public int Quantity { get; set; }
    }
}
