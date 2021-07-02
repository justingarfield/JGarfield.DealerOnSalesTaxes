using JGarfield.DealerOnSalesTaxes.Library.Domain;
using System;

namespace JGarfield.DealerOnSalesTaxes.Library.Services
{
    /// <summary>
    /// Provides an <see cref="IReceiptService"/> implementation that directs output to the Console.
    /// </summary>
    public class ConsoleOutputReceiptService : IReceiptService
    {
        /// <summary>
        /// The <see cref="ITaxService"/> implementation provided by DI.
        /// </summary>
        private readonly ITaxService _taxService;

        /// <summary>
        /// Instantiates a new <see cref="ConsoleOutputReceiptService"/>.
        /// </summary>
        /// <param name="taxService">The <see cref="ITaxService"/> implementation to use.</param>
        public ConsoleOutputReceiptService(ITaxService taxService)
        {
            _taxService = taxService ?? throw new ArgumentNullException(nameof(taxService), "Must be defined.");
        }

        /// <summary>
        /// Writes the final receipt contents to the Console / StdOut.
        /// </summary>
        /// <param name="shoppingBasket">The <see cref="ShoppingBasket"/> to generate a receipt for.</param>
        public void WriteReceipt(ShoppingBasket shoppingBasket)
        {
            var salesTaxesForEntireBasket = 0.00m;
            var totalForAllLineItemsWithSalesTaxes = 0.00m;

            foreach (var lineItem in shoppingBasket.LineItems)
            {
                var salesTaxForItem = _taxService.CalculateTaxForItem(lineItem.Item);

                var lineItemCostWithSalesTax = lineItem.Item.CostPerUnit + salesTaxForItem;
                var lineItemTotal = lineItemCostWithSalesTax * lineItem.Quantity;

                salesTaxesForEntireBasket += salesTaxForItem * lineItem.Quantity;
                totalForAllLineItemsWithSalesTaxes += lineItemTotal;

                var output = $"{lineItem.Item.Name}: {lineItemTotal}";

                if (lineItem.Quantity > 1)
                {
                    output += $" ({lineItem.Quantity} @ {lineItemCostWithSalesTax})";
                }

                Console.WriteLine(output);
            }

            Console.WriteLine($"Sales Taxes: {salesTaxesForEntireBasket}");
            Console.WriteLine($"Total: {totalForAllLineItemsWithSalesTaxes}");
        }
    }
}
