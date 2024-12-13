using CsvHelper;
using CsvHelper.Configuration;
using Spectre.Console;
using System.Globalization;
using System.IO;
using System.Linq;

namespace FuneralHomes
{
    public static class ServicesPrices
    {
        public const int BasicFuneralServices = 3000;
        public const int CremationServices = 1200; 
        public const int CustomFuneralServices = 0; 

        public const int CasketBasic = 15000;
        public const int CasketPremium = 30000;
        public const int CasketLuxury = 50000;

        public const int FlowersStandard = 5000;
        public const int FlowersPremium = 10000;
        public const int FlowersLuxury = 15000;

        public const int TransportationStandard = 5000;
        public const int TransportationPremium = 10000;
    }

    public abstract class FuneralService
    {
        public string Name { get; private set; }
        public int BasePrice { get; private set; }
        public string Details { get; protected set; }

        protected FuneralService(string name, int basePrice)
        {
            Name = name;
            BasePrice = basePrice;
        }

        public virtual int CalculateCost()
        {
            return BasePrice;
        }

        public void DisplayDetails()
        {
            Console.Clear();
            AnsiConsole.Write(
                new Panel(
                    $"[bold underline]{Name}[/]\n\n" +
                    $"[yellow]Base Price:[/] {BasePrice:C}\n\n" +
                    "[yellow]Service Details:[/]\n" +
                    $"{Details}\n")
                {
                    Header = new PanelHeader($"[blue]{Name}[/]"),
                    Border = BoxBorder.Rounded,
                    Padding = new Padding(2, 2)
                });
            AnsiConsole.MarkupLine("\n[green]Press any key to return to the main menu...[/]");
            Console.ReadKey();
        }
    }

    public class BasicFuneralService : FuneralService
    {
        public BasicFuneralService() : base("Basic Funeral Service", ServicesPrices.BasicFuneralServices)
        {
            Details = "- Transportation of the deceased to the funeral home\n" +
                      "- Embalming service\n" +
                      "- Viewing at the funeral home\n" +
                      "- Basic casket";
        }

        public override int CalculateCost()
        {
            // Return only the base price
            return BasePrice;
        }
    }

    public class CremationService : FuneralService
    {
        public CremationService() : base("Direct Cremation", ServicesPrices.CremationServices)
        {
            Details = "- Transportation of the deceased\n" +
                      "- Cremation\n" +
                      "- Urn for ashes";
        }

        public override int CalculateCost()
        {
            // Return only the base price
            return BasePrice;
        }
    }

    public class CustomFuneralService : FuneralService
    {
        public string SelectedCasket { get; private set; }
        public string SelectedFlowers { get; private set; }
        public string SelectedTransportation { get; private set; }

        public CustomFuneralService() : base("Custom Funeral Service", ServicesPrices.CustomFuneralServices)
        {
            Details = "- Flexible payment plans\n" +
                      "- Lock in current prices for future services\n" +
                      "- Customizable service options\n" +
                      "- Professional financial guidance";
        }

        public override int CalculateCost()
        {
            int totalCost = BasePrice;  // Start with the base price

            if (SelectedCasket == "Casket Premium")
                totalCost += ServicesPrices.CasketPremium;
            else if (SelectedCasket == "Casket Luxury")
                totalCost += ServicesPrices.CasketLuxury;
            else
                totalCost += ServicesPrices.CasketBasic;

            if (SelectedFlowers == "Flowers Premium")
                totalCost += ServicesPrices.FlowersPremium;
            else if (SelectedFlowers == "Flowers Luxury")
                totalCost += ServicesPrices.FlowersLuxury;
            else
                totalCost += ServicesPrices.FlowersStandard;

            if (SelectedTransportation == "Transportation Premium")
                totalCost += ServicesPrices.TransportationPremium;
            else
                totalCost += ServicesPrices.TransportationStandard;

            return totalCost;
        }

        public void CustomSelectServices()
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[green]Custom Funeral Service - Select your services[/]");

            // Casket selection
            SelectedCasket = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow]Select a Casket[/]")
                    .PageSize(4)
                    .AddChoices("Casket Basic", "Casket Premium", "Casket Luxury"));

            // Flowers selection
            SelectedFlowers = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow]Select Flowers[/]")
                    .PageSize(4)
                    .AddChoices("Flowers Standard", "Flowers Premium", "Flowers Luxury"));

            // Transportation selection
            SelectedTransportation = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow]Select Transportation[/]")
                    .PageSize(4)
                    .AddChoices("Transportation Standard", "Transportation Premium"));

            // Calculate and display the total cost
            int totalCost = CalculateCost();
            SalesSummary.UpdateRevenue(totalCost, "Custom");
            SalesSummary.RecordPlanSale('C');
        }
    }

    public static class ViewPlansAndServices
    {
        private static readonly List<FuneralService> Services = new()
        {
            new BasicFuneralService(),
            new CremationService(),
            new CustomFuneralService()
        };

        public static void Display()
        {
            bool isRunning = true;

            while (isRunning)
            {
                try
                {
                    Console.Clear();

                    var serviceNames = Services.Select(service => service.Name).Append("Exit").ToList();

                    var mainMenuChoice = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("[green]Select a Plan to view detailed information[/]")
                            .PageSize(7)
                            .AddChoices(serviceNames));

                    if (mainMenuChoice == "Exit")
                    {
                        AnsiConsole.MarkupLine("[red]Exiting... Goodbye![/]");
                        isRunning = false;
                    }
                    else
                    {
                        var selectedService = Services.FirstOrDefault(s => s.Name == mainMenuChoice);
                        selectedService?.DisplayDetails();
                    }
                }
                catch (Exception ex)
                {
                    AnsiConsole.MarkupLine($"[red]An unexpected error occurred: {ex.Message}[/]");
                    Console.ReadKey();
                }
            }
        }
    }
    public class SalesData
    {
        public int BasicFuneralCount { get; set; }
        public int CremationCount { get; set; }
        public int CustomFuneralCount { get; set; }
        public int CustomFuneralRevenue { get; set; }
        public int TotalRevenue { get; set; }
    }

    public static class SalesSummary
    {
        public static string FilePath = "sales_summary.csv";
        private static SalesData salesData = LoadSalesData();

        public static void RecordPlanSale(char planChoice)
        {
            switch (planChoice)
            {
                case 'A':
                    salesData.BasicFuneralCount++;
                    break;
                case 'B':
                    salesData.CremationCount++;
                    break;
                case 'C':
                    salesData.CustomFuneralCount++;
                    break;
            }
        }

        public static void UpdateRevenue(int saleAmount, string serviceType)
        {
            switch (serviceType)
            {
                case "Basic":
                case "Cremation":
                    salesData.TotalRevenue += saleAmount;
                    break;
                case "Custom":
                    salesData.TotalRevenue += saleAmount;
                    salesData.CustomFuneralRevenue += saleAmount;
                    break;
            }
            // Removed SaveSalesData() here
        }


        public static void DisplaySalesSummary()
        {
            try
            {
                Console.Clear();
                AnsiConsole.Write(new FigletText("Sales Summary").Centered().Color(Color.Green));

                if (salesData.TotalRevenue == 0)
                {
                    AnsiConsole.MarkupLine("[yellow]No sales data to display.[/]");
                    Console.ReadKey();
                    return;
                }

                // Create the table
                var table = new Table()
                    .Centered()
                    .Border(TableBorder.Rounded)
                    .Title("[bold yellow]Funeral Services Sales[/]")
                    .AddColumn("[bold green]Service[/]")
                    .AddColumn("[bold green]Units Sold[/]")
                    .AddColumn("[bold green]Revenue[/]");

                // Add rows for Basic Funeral Services, Cremation Services, and Custom Funeral Services
                table.AddRow("Basic Funeral Services", salesData.BasicFuneralCount.ToString(), $"P{salesData.BasicFuneralCount * ServicesPrices.BasicFuneralServices:N}");
                table.AddRow("Cremation Services", salesData.CremationCount.ToString(), $"P{salesData.CremationCount * ServicesPrices.CremationServices:N}");
                table.AddRow("Custom Funeral Services", salesData.CustomFuneralCount.ToString(), $"P{salesData.CustomFuneralRevenue:N}");
                table.AddRow("[bold cyan]Total Revenue[/]", "-", $"[bold cyan]P{salesData.TotalRevenue:N}[/]");

                // Display the table
                AnsiConsole.Write(table);

                // Create a Bar Chart to show the revenue comparison
                var barChart = new BarChart()
                    .Width(50)
                    .Label("[bold]Service Revenue[/]")
                    .AddItem("Basic Funeral Services", salesData.BasicFuneralCount * ServicesPrices.BasicFuneralServices, Color.Green)
                    .AddItem("Cremation Services", salesData.CremationCount * ServicesPrices.CremationServices, Color.Blue)
                    .AddItem("Custom Funeral Services", salesData.CustomFuneralRevenue, Color.Yellow)
                    .AddItem("Total Revenue", salesData.TotalRevenue, Color.Aquamarine1);

                // Display the bar chart below the table
                AnsiConsole.Write(barChart);

                // Prompt the user to continue
                AnsiConsole.MarkupLine("\n[green]Press any key to continue...[/]");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Error: {ex.Message}[/]");
                Console.ReadKey();
            }
        }

        private static SalesData LoadSalesData()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    using (var reader = new StreamReader(FilePath))
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                    {
                        var records = csv.GetRecords<SalesData>().ToList();
                        if (records.Any())
                        {
                            Console.WriteLine("Sales data loaded successfully.");
                            return records.First();
                        }
                    }
                }

                Console.WriteLine("[yellow]Sales data file not found or empty. Initializing with default values.[/]");
                return new SalesData();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[red]Error loading sales data: {ex.Message}[/]");
                return new SalesData();
            }
        }

        public static void SaveSalesData()
        {
            try
            {
                using (var writer = new StreamWriter(FilePath, false)) // Overwrite the file
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {                  
                    csv.WriteHeader<SalesData>();
                    csv.NextRecord(); // Move to the next line after writing the header

                    // Write the single record
                    csv.WriteRecord(salesData);
                }

                Console.WriteLine("[green]Sales data successfully saved![/]");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[red]Error saving sales data: {ex.Message}[/]");
            }
        }
    }
}
