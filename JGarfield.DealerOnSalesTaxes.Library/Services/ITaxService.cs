using JGarfield.DealerOnSalesTaxes.Library.Domain;

namespace JGarfield.DealerOnSalesTaxes.Library.Services
{
    /// <summary>
    /// Defines the capabilities related to managing and calculating Sales and Import taxes.
    /// </summary>
    public interface ITaxService
    {
        /// <summary>
        /// Calculates the overall taxes for an Item, taking into account both Sales and Import taxes.
        /// </summary>
        /// <param name="item">The <see cref="Item"/> to calculate taxes for.</param>
        /// <returns>The taxes due for the <see cref="Item"/>.</returns>
        decimal CalculateTaxForItem(Item item);
    }
}
