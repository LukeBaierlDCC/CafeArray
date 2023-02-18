using System;
using System.Collections.Generic;
using CafeArray;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Cafe Array. Please press enter to continue.");
        Console.ReadLine();
        Console.Clear();
        BeverageMenu();
    }

    static void BeverageMenu()
    {
        // Initialize the menu
        string[] menu = new string[] { "Coffee", "Latte", "Cappuccino", "Espresso" };
        double[] prices = new double[] { 2.99, 3.99, 4.99, 2.49 };

        Wallet wallet = new Wallet(50.00);

        // Initialize the list of orders
        List<string> orders = new List<string>();

        // Main loop
        while (true)
        {
            // Display the menu
            Console.WriteLine("Menu:");
            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {menu[i]} - {prices[i]:c}");
            }

            // Prompt the user to enter an order or 'q' to quit
            Console.WriteLine("Enter an item number to order, or 'q' to quit:");
            string input = Console.ReadLine();

            // Check if the user entered 'q' to quit
            if (input.ToLower() == "q")
            {
                break;
            }

            // Parse the user input as an integer
            if (int.TryParse(input, out int itemNumber) && itemNumber >= 1 && itemNumber <= menu.Length)
            {
                // Add the selected item to the list of orders
                orders.Add(menu[itemNumber - 1]);

                // Confirm the order to the user
                Console.WriteLine($"Added {menu[itemNumber - 1]} to your order.");

                // Get the price of the selected item
                double price = prices[itemNumber - 1];

                // Ask the user to pay for the item
                Console.WriteLine($"The price is {price:c}.");
                Console.WriteLine("Enter 'y' to pay or 'n' to cancel:");
                input = Console.ReadLine();

                if (input.ToLower() == "y")
                {
                    // Make the payment and update the wallet balance
                    if (wallet.MakePayment(price))
                    {
                        Console.WriteLine("Payment accepted.");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient funds. Please add money to your wallet.");
                    }
                }
                else
                {
                    // Remove the item from the order list
                    orders.RemoveAt(orders.Count - 1);
                    Console.WriteLine("Order cancelled.");
                }
            }
            else
            {
                // Display an error message for invalid input
                Console.WriteLine("Invalid input. Please enter an item number or 'q' to quit.");
            }
        }

        // Display the final order summary
        Console.WriteLine("Order summary:");
        foreach (string item in orders)
        {
            Console.WriteLine(item);
        }

        // Display the wallet balance
        Console.WriteLine($"Your wallet balance is {wallet.GetBalance():c}.");

        Console.WriteLine("Thank you for your order!");
    }
}
