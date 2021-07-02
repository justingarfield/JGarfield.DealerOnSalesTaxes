using JGarfield.DealerOnSalesTaxes.Library.Model;
using Xunit;

namespace JGarfield.DealerOnSalesTaxes.UnitTests.Theories
{
    /// <summary>
    /// Contains data for all of the input values for Scenario 3 that will need to 
    /// translate properly to <see cref="ParsedConsoleInputModel"/> instances in order
    /// to meet the requirements for the DealerOn SalesTax project.
    /// </summary>
    public class Input3_Scenarios_Theory : TheoryData<string, ParsedConsoleInputModel>
    {
        /// <summary>
        /// Instantiates a new <see cref="Input1_Scenarios_Theory"/>.
        /// </summary>
        public Input3_Scenarios_Theory()
        {
            Add("1 Imported bottle of perfume at 27.99", new ParsedConsoleInputModel { Quantity = 1, Name = "Imported bottle of perfume", CostPerUnit = 27.99m });
            Add("1 Bottle of perfume at 18.99", new ParsedConsoleInputModel { Quantity = 1, Name = "Bottle of perfume", CostPerUnit = 18.99m });
            Add("1 Packet of headache pills at 9.75", new ParsedConsoleInputModel { Quantity = 1, Name = "Packet of headache pills", CostPerUnit = 9.75m });
            Add("1 Imported box of chocolates at 11.25", new ParsedConsoleInputModel { Quantity = 1, Name = "Imported box of chocolates", CostPerUnit = 11.25m });
        }
    }
}
