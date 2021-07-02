using JGarfield.DealerOnSalesTaxes.Library.Model;
using Xunit;

namespace JGarfield.DealerOnSalesTaxes.UnitTests.Theories
{
    /// <summary>
    /// Contains data for all of the input values for Scenario 1 that will need to 
    /// translate properly to <see cref="ParsedConsoleInputModel"/> instances in order
    /// to meet the requirements for the DealerOn SalesTax project.
    /// </summary>
    public class Input1_Scenarios_Theory : TheoryData<string, ParsedConsoleInputModel>
    {
        /// <summary>
        /// Instantiates a new <see cref="Input1_Scenarios_Theory"/>.
        /// </summary>
        public Input1_Scenarios_Theory()
        {
            Add("1 Book at 12.49", new ParsedConsoleInputModel { Quantity = 1, Name = "Book", CostPerUnit = 12.49m });
            Add("1 Book at 12.49", new ParsedConsoleInputModel { Quantity = 1, Name = "Book", CostPerUnit = 12.49m });
            Add("1 Music CD at 14.99", new ParsedConsoleInputModel { Quantity = 1, Name = "Music CD", CostPerUnit = 14.99m });
            Add("1 Chocolate bar at 0.85", new ParsedConsoleInputModel { Quantity = 1, Name = "Chocolate bar", CostPerUnit = 0.85m });
        }
    }
}
