using Xunit;

namespace JGarfield.DealerOnSalesTaxes.Tests.Theories
{
    /// <summary>
    /// Contains data used when testing that the SalesTax Service 
    /// handles rounding to the nearest 5-cents properly.
    /// </summary>
    public class SalesTax_Rounding_Theory : TheoryData<decimal, decimal>
    {
        /// <summary>
        /// Instantiates a new <see cref="SalesTax_Rounding_Theory"/>.
        /// </summary>
        public SalesTax_Rounding_Theory()
        {
            Add(5.00m, 0.50m);
            Add(5.10m, 0.55m);
            Add(5.20m, 0.55m);
            Add(5.30m, 0.55m);
            Add(5.33m, 0.55m);
            Add(5.40m, 0.55m);
            Add(5.50m, 0.55m);
            Add(5.60m, 0.60m);
            Add(5.70m, 0.60m);
            Add(5.80m, 0.60m);
            Add(5.90m, 0.60m);
            Add(6.00m, 0.60m);
        }
    }
}
