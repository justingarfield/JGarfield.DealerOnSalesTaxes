using JGarfield.DealerOnSalesTaxes.Library.Domain;

namespace JGarfield.DealerOnSalesTaxes.Library.Model
{
    /// <summary>
    /// Simple model to hold input that gets parsed from Console Input by the end-user.
    /// </summary>
    public class ParsedConsoleInputModel
    {
        /// <summary>
        /// The item quantity that was parsed from the input string.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The item cost-per-unit that was parsed from the input string.
        /// </summary>
        public decimal CostPerUnit { get; set; }

        /// <summary>
        /// The item name that was parsed from the input string.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicator determining whether or not the item parsed from the input string is considered Imported.
        /// </summary>
        public bool IsImported { get; set; }

        /// <summary>
        /// The type / category of the Item.
        /// </summary>
        public ItemType ItemType { get; set; }
    }
}
