using JGarfield.DealerOnSalesTaxes.Library;
using JGarfield.DealerOnSalesTaxes.Library.Domain;
using JGarfield.DealerOnSalesTaxes.Library.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace JGarfield.DealerOnSalesTaxes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            // Wanted to show knowledge of using a Dependency Injection (DI) Container
            // Normally wouldn't just build a host and run call Run on it, but this 
            // works for purposes of a sample project.
            using (IHost host = CreateHostBuilder(args).Build())
            {
                // Get the IReceiptService implementation from DI. Don't need to create a 
                // scope here since I just needed Singleton services.
                var receiptService = host.Services.GetRequiredService<IReceiptService>();

                Console.WriteLine("Please input the line item in a format of \"<qty> <item name> at <cost>\". Enter an empty line when finished.");

                var shoppingBasket = new ShoppingBasket();

                var consoleInput = Console.ReadLine();
                while (!string.IsNullOrWhiteSpace(consoleInput))
                {
                    try
                    {
                        var parsedConsoleInput = ConsoleInputParser.ParseConsoleInputToModel(consoleInput);
                        Console.WriteLine($"Adding the following item to the Shopping Basket --- Qty: {parsedConsoleInput.Quantity}, Name: {parsedConsoleInput.Name}, Cost-per-unit: {parsedConsoleInput.CostPerUnit}, ItemType: {parsedConsoleInput.ItemType}, IsImported: {parsedConsoleInput.IsImported}");

                        shoppingBasket.AddItem(new Item
                        {
                            Name = parsedConsoleInput.Name,
                            CostPerUnit = parsedConsoleInput.CostPerUnit,
                            ItemType = parsedConsoleInput.ItemType,
                            IsImported = parsedConsoleInput.IsImported
                        }, parsedConsoleInput.Quantity);
                    }
                    catch (FormatException)
                    {
                        // Just showing that I would normally use a Logger to log the Exception and give the caller something nicer on their end.
                        // _logger.LogError(fe, "Could not parse User Input. See exception details.");
                        Console.WriteLine("Could not successfully parse user input. Please check entry and try again.");
                    }

                    consoleInput = Console.ReadLine();
                }

                receiptService.WriteReceipt(shoppingBasket);
            }
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddSingleton<ITaxService, TaxService>()
                            .AddSingleton<IReceiptService, ConsoleOutputReceiptService>());
    }
}
