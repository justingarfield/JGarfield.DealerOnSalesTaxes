using JGarfield.DealerOnSalesTaxes.Library.Domain;
using System;
using System.Linq;

namespace JGarfield.DealerOnSalesTaxes.Library.Services
{
    /// <summary>
    /// Provides an <see cref="ITaxService"/> implementation that manages calculating Sales and Import taxes.
    /// </summary>
    public class TaxService : ITaxService
    {
        /// <summary>
        /// Basic sales tax applies to all items at a rate of 10% of the item’s list price
        /// </summary>
        private const decimal BASIC_SALES_TAX_PERCENTAGE = 0.10m;

        /// <summary>
        /// An import duty (import tax) applies to all imported items at a rate of 5% of the shelf price
        /// </summary>
        private const decimal IMPORT_TAX_PERCENTAGE = 0.05m;

        /// <summary>
        /// Books, Food, and Medical are exempt from basic sales tax
        /// </summary>
        private readonly ItemType[] _itemTypesExemptFromBasicSalesTax = new ItemType[3] {
            ItemType.Book,
            ItemType.Food,
            ItemType.Medical
        };

        /// <summary>
        /// Calculates the overall taxes for an Item, taking into account both Sales and Import taxes.
        /// </summary>
        /// <param name="item">The <see cref="Item"/> to calculate taxes for.</param>
        /// <returns>The taxes due for the <see cref="Item"/>.</returns>
        public decimal CalculateTaxForItem(Item item)
        {
            decimal taxForItem = 0.00m;

            // Basic sales tax applies to all items at a rate of 10% of the item’s list price, with the 
            // exception of books, food, and medical products, which are exempt from basic sales tax
            if (!_itemTypesExemptFromBasicSalesTax.Contains(item.ItemType))
            {
                taxForItem += Math.Round(item.CostPerUnit * BASIC_SALES_TAX_PERCENTAGE, 2);
            }

            // An import duty (import tax) applies to all imported items at a rate of 5% of the shelf price, with no exceptions.
            if (item.IsImported)
            {
                taxForItem += Math.Round(item.CostPerUnit * IMPORT_TAX_PERCENTAGE, 2);
            }

            // Requirements said to only round Sales Tax up, but if I don't apply 
            // this for Import Tax as well, then I can't match the Expected Outputs.
            taxForItem = RoundUpToNearest5Cents(taxForItem);

            return taxForItem;
        }

        /// <summary>
        /// Given a specific Tax Amount, rounds it up to the nearest 5-cents.
        /// </summary>
        /// <param name="taxAmount">The tax amount to round.</param>
        /// <returns>The rounded tax amount value.</returns>
        private decimal RoundUpToNearest5Cents(decimal taxAmount)
        {
            return Math.Ceiling(taxAmount / 0.05m) * 0.05m;
        }
    }
}
