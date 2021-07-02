namespace JGarfield.DealerOnSalesTaxes.Library.Domain
{
    /// <summary>
    /// Represents an Item that can be sold by a Store.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// The Name of the item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// How much a single unit of the item costs.
        /// </summary>
        public decimal CostPerUnit { get; set; }

        /// <summary>
        /// The type / category of item (used when determining Sales Tax)
        /// </summary>
        public ItemType ItemType { get; set; }

        /// <summary>
        /// Whether or not the item is considered Imported (used for Import Tax)
        /// </summary>
        public bool IsImported { get; set; }
    }
}
