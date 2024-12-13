using Spectre.Console;
using System;

namespace FuneralHomes
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                try
                {
                    Console.Clear();

                    // Create a banner for the system title with a background
                    AnsiConsole.MarkupLine("Welcome to ETN Funeral Homes");

                    // Main Menu with a more stylish look
                    var mainMenuChoice = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("[yellow]Please choose an option:[/]")
                            .PageSize(5)
                            .AddChoices("Customer Fillup", "Admin Menu", "View Plans and Services", "Test", "Exit"));

                    switch (mainMenuChoice)
                    {
                        case "Exit":
                            AnsiConsole.MarkupLine("[red]Exiting... Goodbye![/]");
                            isRunning = false;
                            break;

                        case "Customer Fillup":
                            CustomerFillup();
                            break;

                        case "Admin Menu":
                            PasswordAdminMenu();
                            break;

                        case "View Plans and Services":
                            Console.Clear();
                            try
                            {
                                ViewPlansAndServices.Display();
                            }
                            catch (Exception ex)
                            {
                                AnsiConsole.MarkupLine($"[red]Failed to load plans and services: {ex.Message}[/]");
                            }
                            Console.ReadKey();
                            break;
                        case "Test":
                            var customService = new CustomFuneralService();
                            customService.CustomSelectServices();
                            break;
                        default:
                            AnsiConsole.MarkupLine("[red]Invalid choice. Please try again.[/]");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    AnsiConsole.MarkupLine($"[red]An unexpected error occurred: {ex.Message}[/]");
                    Console.ReadKey();
                }
            }
        }

        static void CustomerFillup()
        {
            try
            {
                Console.Clear();
                CustomerManagement.AddCustomer();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Error in Customer Menu: {ex.Message}[/]");
                Console.ReadKey();
            }
        }

        static void PasswordAdminMenu()
        {
            try
            {
                Console.Clear();
                AnsiConsole.MarkupLine("[yellow]Admin Access Required[/]");

                // Admin password prompt with a bold style
                AnsiConsole.MarkupLine("Please enter the [bold]admin password[/]:");

                string inputPassword = Console.ReadLine();
                const string adminPassword = "admin123"; // Replace with a secure mechanism in production

                if (inputPassword == adminPassword)
                {
                    AdminMenu();
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Access Denied. Incorrect password.[/]");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Error during admin authentication: {ex.Message}[/]");
                Console.ReadKey();
            }
        }

        static void AdminMenu()
        {
            bool isAdminMenuRunning = true;

            while (isAdminMenuRunning)
            {
                try
                {
                    Console.Clear();

                    // Adding a border and title for the admin menu
                    Console.WriteLine("Admin");

                    var adminMenuChoice = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("[yellow]Choose an admin option[/]")
                            .PageSize(6)
                            .AddChoices("Add Customer", "View Customers", "Update Customer Information",
                                        "Delete Customer", "Search Customer", "Summary of Sales", "Back to Main Menu"));

                    switch (adminMenuChoice)
                    {
                        case "Back to Main Menu":
                            isAdminMenuRunning = false;
                            break;

                        case "Add Customer":
                            Console.Clear();
                            try
                            {
                                CustomerManagement.AddCustomer();
                            }
                            catch (Exception ex)
                            {
                                AnsiConsole.MarkupLine($"[red]Error adding customer: {ex.Message}[/]");
                            }
                            break;

                        case "View Customers":
                            Console.Clear();
                            try
                            {
                                CustomerManagement.ViewCustomers();
                            }
                            catch (Exception ex)
                            {
                                AnsiConsole.MarkupLine($"[red]Error viewing customers: {ex.Message}[/]");
                            }
                            Console.ReadKey();
                            break;

                        case "Update Customer Information":
                            Console.Clear();
                            try
                            {
                                CustomerManagement.UpdateCustomer();
                            }
                            catch (Exception ex)
                            {
                                AnsiConsole.MarkupLine($"[red]Error updating customer: {ex.Message}[/]");
                            }
                            break;

                        case "Delete Customer":
                            Console.Clear();
                            try
                            {
                                CustomerManagement.DeleteCustomer();
                            }
                            catch (Exception ex)
                            {
                                AnsiConsole.MarkupLine($"[red]Error deleting customer: {ex.Message}[/]");
                            }
                            break;

                        case "Search Customer":
                            Console.Clear();
                            try
                            {
                                CustomerManagement.SearchCustomer();
                            }
                            catch (Exception ex)
                            {
                                AnsiConsole.MarkupLine($"[red]Error searching customer: {ex.Message}[/]");
                            }
                            break;

                        case "Summary of Sales":
                            Console.Clear();
                            try
                            {
                                SalesSummary.DisplaySalesSummary();
                                Console.ReadKey();
                            }
                            catch (Exception ex)
                            {
                                AnsiConsole.MarkupLine($"[red]Error loading summary of sales: {ex.Message}[/]");
                            }
                            break;

                        default:
                            AnsiConsole.MarkupLine("[red]Invalid choice. Please try again.[/]");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    AnsiConsole.MarkupLine($"[red]Error in Admin Menu: {ex.Message}[/]");
                    Console.ReadKey();
                }
            }
        }
    }
}
