namespace JGarfield.DealerOnSalesTaxes.Library.Domain
{
    /// <summary>
    /// The Type of an item in the store.
    /// </summary>
    public enum ItemType
    {
        /// <summary>
        /// Not sure what the item type is. (default)
        /// </summary>
        None,

        /// <summary>
        /// The item is a book related.
        /// </summary>
        Book,

        /// <summary>
        /// The item is food related.
        /// </summary>
        Food,

        /// <summary>
        /// The item is Medical related.
        /// </summary>
        Medical,

        /// <summary>
        /// The Item doesn't fall into a particular Type / Category.
        /// </summary>
        Other
    }
}
