using JGarfield.DealerOnSalesTaxes.Library.Model;
using Xunit;

namespace JGarfield.DealerOnSalesTaxes.UnitTests.Theories
{
    /// <summary>
    /// Contains data for all of the input values for Scenario 2 that will need to 
    /// translate properly to <see cref="ParsedConsoleInputModel"/> instances in order
    /// to meet the requirements for the DealerOn SalesTax project.
    /// </summary>
    public class Input2_Scenarios_Theory : TheoryData<string, ParsedConsoleInputModel>
    {
        /// <summary>
        /// Instantiates a new <see cref="Input1_Scenarios_Theory"/>.
        /// </summary>
        public Input2_Scenarios_Theory()
        {
            Add("1 Imported box of chocolates at 10.00", new ParsedConsoleInputModel { Quantity = 1, Name = "Imported box of chocolates", CostPerUnit = 10.00m });
            Add("1 Imported bottle of perfume at 47.50", new ParsedConsoleInputModel { Quantity = 1, Name = "Imported bottle of perfume", CostPerUnit = 47.50m });
        }
    }
}
