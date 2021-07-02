using JGarfield.DealerOnSalesTaxes.Library.Domain;

namespace JGarfield.DealerOnSalesTaxes.Library.Services
{
    /// <summary>
    /// Defines the capabilities related to outputting a receipt for a 
    /// <see cref="ShoppingBasket"/> to a particular output destination.
    /// </summary>
    public interface IReceiptService
    {
        /// <summary>
        /// Writes the final receipt contents to a particular output destination.
        /// </summary>
        /// <param name="shoppingBasket">The <see cref="ShoppingBasket"/> to generate a receipt for.</param>
        void WriteReceipt(ShoppingBasket shoppingBasket);
    }
}
