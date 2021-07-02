using JGarfield.DealerOnSalesTaxes.Library.Domain;
using JGarfield.DealerOnSalesTaxes.Library.Model;
using System;

namespace JGarfield.DealerOnSalesTaxes.Library
{
    /// <summary>
    /// Provides capabilites to parse Console Input into models usable by the application.
    /// </summary>
    public static class ConsoleInputParser
    {
        /// <summary>
        /// Given a string from console input, attempts to parse the user's input and derive a <see cref="ParsedConsoleInputModel"/> from it.
        /// </summary>
        /// <param name="consoleInput">The console input string to parse.</param>
        /// <returns>A <see cref="ParsedConsoleInputModel"/> derived from the input.</returns>
        public static ParsedConsoleInputModel ParseConsoleInputToModel(string consoleInput)
        {
            var consoleInputParts = consoleInput.Split(' ');
            
            // There should be at least 4 pieces of information available if the input is the least bit valid.
            if (consoleInputParts.Length < 4)
            {
                throw new FormatException("Invalid input provided.");
            }

            if (!int.TryParse(consoleInputParts[0], out int parsedQuantity))
            {
                throw new FormatException("A quantity could not be derived.");
            }

            if (!decimal.TryParse(consoleInputParts[consoleInputParts.Length - 1], out decimal parsedCostPerUnit))
            {
                throw new FormatException("A cost could not be derived.");
            }

            var startOfItemNameIdx = consoleInput.IndexOf(' ') + 1;
            var endOfItemNameIdx = consoleInput.LastIndexOf(" at ") - 2;
            var parsedItemName = consoleInput.Substring(startOfItemNameIdx, endOfItemNameIdx);

            var isImported = consoleInput.Contains("imported", StringComparison.InvariantCultureIgnoreCase);

            var itemType = DeriveItemType(parsedItemName);

            return new ParsedConsoleInputModel
            {
                Quantity = parsedQuantity,
                Name = parsedItemName,
                CostPerUnit = parsedCostPerUnit,
                IsImported = isImported,
                ItemType = itemType
            };
        }

        /// <summary>
        /// Given the name of an item, derives what <see cref="ItemType"/> it falls under. Defaults to <see cref="ItemType.Other"/>.
        /// </summary>
        /// <param name="itemName">The item name to derive an <see cref="ItemType"/> from.</param>
        /// <returns>The <see cref="ItemType"/> derived from the provided item name.</returns>
        private static ItemType DeriveItemType(string itemName)
        {
            var itemType = ItemType.Other;

            if (itemName.Contains("book", StringComparison.InvariantCultureIgnoreCase))
                itemType = ItemType.Book;

            if (itemName.Contains("Chocolate bar", StringComparison.InvariantCultureIgnoreCase)
                || itemName.Contains("box of chocolates", StringComparison.InvariantCultureIgnoreCase))
                itemType = ItemType.Food;

            if (itemName.Contains("headache pills", StringComparison.InvariantCultureIgnoreCase))
                itemType = ItemType.Medical;

            return itemType;
        }
    }
}
