using JGarfield.DealerOnSalesTaxes.Library;
using JGarfield.DealerOnSalesTaxes.Library.Model;
using JGarfield.DealerOnSalesTaxes.UnitTests.Theories;
using System;
using Xunit;

namespace JGarfield.DealerOnSalesTaxes.UnitTests.Library
{
    /// <summary>
    /// Provides unit tests for the <see cref="ConsoleInputParser"/> class.
    /// </summary>
    public class ConsoleInputParserTests
    {
        [Theory]
        [ClassData(typeof(Input1_Scenarios_Theory))]
        [ClassData(typeof(Input2_Scenarios_Theory))]
        [ClassData(typeof(Input3_Scenarios_Theory))]
        public void ParseConsoleInputToBasketItem_Handles_Provided_Input_Scenarios(string consoleInput, ParsedConsoleInputModel expectedStoreItem)
        {
            var parsedConsoleInput = ConsoleInputParser.ParseConsoleInputToModel(consoleInput);

            Assert.Equal(expectedStoreItem.Quantity, parsedConsoleInput.Quantity);
            Assert.Equal(expectedStoreItem.Name, parsedConsoleInput.Name);
            Assert.Equal(expectedStoreItem.CostPerUnit, parsedConsoleInput.CostPerUnit);
        }

        [Fact]
        public void ParseConsoleInputToBasketItem_Throws_FormatException_When_Insufficient_InputParts()
        {
            // Arrange
            var badInputTooFewParts = "1 Book at";
            Action action = () => ConsoleInputParser.ParseConsoleInputToModel(badInputTooFewParts);

            // Act
            var exception = Record.Exception(action);

            // Assert
            Assert.IsType<FormatException>(exception);

            // Note: Some places I've worked check exact exception messages. Sometimes I'll just
            // check for it to be !string.IsNullOrWhiteSpace(...), because the exact message
            // text has made tests insanely brittle on prior projects in some cases.
            Assert.Equal("Invalid input provided.", exception.Message);
        }

        [Fact]
        public void ParseConsoleInputToBasketItem_Throws_FormatException_When_Quantity_Cannot_Be_Derived()
        {
            // Arrange
            var badQuantityInput = "abc123efg Book at 12.49";
            Action action = () => ConsoleInputParser.ParseConsoleInputToModel(badQuantityInput);

            // Act
            var exception = Record.Exception(action);
            
            // Assert
            Assert.IsType<FormatException>(exception);
            Assert.Equal("A quantity could not be derived.", exception.Message);
        }

        [Fact]
        public void ParseConsoleInputToBasketItem_Throws_FormatException_When_Cost_Cannot_Be_Derived()
        {
            // Arrange
            var badCostInput = "1 Book at abc123efg";
            Action action = () => ConsoleInputParser.ParseConsoleInputToModel(badCostInput);

            // Act
            var exception = Record.Exception(action);

            // Assert
            Assert.IsType<FormatException>(exception);
            Assert.Equal("A cost could not be derived.", exception.Message);
        }
    }
}
