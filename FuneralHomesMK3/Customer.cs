using CsvHelper;
using System.Data;
using System.Globalization;
using Spectre.Console;

namespace FuneralHomes
{
    public class Person
    {   
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
    }

    public class CustomerData : Person
    {
        public string Age { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Address { get; set; }
        public string CivilStatus { get; set; }
        public string SpouseName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string DeceasedOccupation { get; set; }
        public string InformantsName { get; set; }
        public string RelationshipToTheDeceased { get; set; }
        public string ContactNumber { get; set; }
        public string PlaceOfFuneral { get; set; }
        public string OfficiatingMinister { get; set; }
        public string SelectedPlan { get; set; }
        public int PricePlan { get; set; }
    }


    public static class CustomerManagement
    {
        private static List<CustomerData> records = new List<CustomerData>();
        private static int nextId = 1; // To auto-generate IDs
        private const string filePath = "customer.csv";

        // Load data from the CSV file on program start
        static CustomerManagement()
        {
            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    try
                    {
                        records = csv.GetRecords<CustomerData>().ToList();
                        // Update nextId to ensure no duplicate IDs
                        if (records.Any())
                            nextId = records.Max(r => r.Id) + 1;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading customer data: {ex.Message}");
                    }
                }
            }
        }
        public static void AddCustomer()
        {
            Console.WriteLine("=== Add New Customer ===");
            try
            {
                int id = nextId;
                nextId++;

                // Customer Name Input with Validation
                string lastName, firstName, middleName;
                while (true)
                {
                    Console.Write("Name of the Deceased (format: LastName,FirstName,MiddleName): ");
                    string input = Console.ReadLine();
                    string[] nameParts = input.Split(',');

                    if (nameParts.Length == 3)
                    {
                        lastName = nameParts[0].Trim();
                        firstName = nameParts[1].Trim();
                        middleName = nameParts[2].Trim();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid format. Please use LastName,FirstName,MiddleName.");
                    }
                }

                // Sex Input
                string sex;
                while (true)
                {
                    Console.Write("Sex: ");
                    sex = Console.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(sex)) break;
                    else Console.WriteLine("Sex cannot be empty.");
                }

                string age;
                while (true)
                {
                    Console.Write("Age: ");
                    age = Console.ReadLine().Trim();
                    if (int.TryParse(age, out _)) break;
                    else Console.WriteLine("Invalid age. Please enter a valid number.");
                }

                // Date of Birth Input with Validation
                DateTime parsedDateOfBirth;
                while (true)
                {
                    Console.Write("Date of Birth (yyyy/mm/dd): ");
                    string dateofbirth = Console.ReadLine();
                    if (DateTime.TryParse(dateofbirth, out parsedDateOfBirth)) break;
                    else Console.WriteLine("Invalid date format. Please enter the date in yyyy/mm/dd format.");
                }

                // Calculate the expected date of death based on the age
                DateTime expectedDateOfDeath = parsedDateOfBirth.AddYears(int.Parse(age));

                // Date of Death Input with Validation
                DateTime parsedDateOfDeath;
                while (true)
                {
                    Console.Write("Date of Death (yyyy/mm/dd): ");
                    string dateofdeath = Console.ReadLine();
                    if (DateTime.TryParse(dateofdeath, out parsedDateOfDeath))
                    {
                        // Check if the date of death is not earlier than the date of birth
                        if (parsedDateOfDeath < parsedDateOfBirth)
                        {
                            Console.WriteLine("Error: Date of Death cannot be earlier than Date of Birth.");
                        }
                        // Check if the date of death is consistent with the given age
                        else if (parsedDateOfDeath.Year != expectedDateOfDeath.Year ||
                                 (parsedDateOfDeath.Month < expectedDateOfDeath.Month ||
                                  (parsedDateOfDeath.Month == expectedDateOfDeath.Month && parsedDateOfDeath.Day < expectedDateOfDeath.Day)))
                        {
                            Console.WriteLine("Error: The Date of Death does not match the given age.");
                        }
                        else
                        {
                            break; // Valid date of death
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please enter the date in yyyy/mm/dd format.");
                    }
                }


                // Place of Birth Input
                string placeofbirth;
                while (true)
                {
                    Console.Write("Place of Birth: ");
                    placeofbirth = Console.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(placeofbirth)) break;
                    else Console.WriteLine("Place of Birth cannot be empty.");
                }

                // Address Input
                string address;
                while (true)
                {
                    Console.Write("Address: ");
                    address = Console.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(address)) break;
                    else Console.WriteLine("Address cannot be empty.");
                }

                // Deceased Occupation Input
                string deceasedOccupation;
                while (true)
                {
                    Console.Write("Deceased Occupation: ");
                    deceasedOccupation = Console.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(deceasedOccupation)) break;
                    else Console.WriteLine("Occupation cannot be empty.");
                }

                // Civil Status Input with Validation
                string civilStatus = "";
                while (true)
                {
                    Console.Write("Civil Status (Married/Single/Widow): ");
                    civilStatus = Console.ReadLine().Trim().ToLower();
                    if (civilStatus == "married" || civilStatus == "single" || civilStatus == "widow")
                        break;
                    else Console.WriteLine("Invalid input. Please enter Married, Single, or Widow.");
                }

                // Spouse Name (if applicable)
                string spouseName = "";
                if (civilStatus == "married" || civilStatus == "widow")
                {
                    Console.Write("Enter Spouse Name: ");
                    spouseName = Console.ReadLine().Trim();
                }
                else if (civilStatus == "single")
                {
                    spouseName = "N/A";
                }

                // Parent Names Input
                string fathersname, mothersname;
                while (true)
                {
                    Console.Write("Father's Name: ");
                    fathersname = Console.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(fathersname)) break;
                    else Console.WriteLine("Father's Name cannot be empty.");
                }

                while (true)
                {
                    Console.Write("Mother's Name: ");
                    mothersname = Console.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(mothersname)) break;
                    else Console.WriteLine("Mother's Name cannot be empty.");
                }

                // Informant Info Input
                string informantsName, relationshipToTheDeceased, contactNumber;
                while (true)
                {
                    Console.Write("Informant's Name: ");
                    informantsName = Console.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(informantsName)) break;
                    else Console.WriteLine("Informant's Name cannot be empty.");
                }

                while (true)
                {
                    Console.Write("Relationship to the Deceased: ");
                    relationshipToTheDeceased = Console.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(relationshipToTheDeceased)) break;
                    else Console.WriteLine("Relationship to the Deceased cannot be empty.");
                }

                while (true)
                {
                    Console.Write("Contact Number (informant): ");
                    contactNumber = Console.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(contactNumber)) break;
                    else Console.WriteLine("Contact Number cannot be empty.");
                }

                // Place of Funeral & Officiating Minister Input
                string placeoffuneral, officiatingminister;
                while (true)
                {
                    Console.Write("Place of Funeral: ");
                    placeoffuneral = Console.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(placeoffuneral)) break;
                    else Console.WriteLine("Place of Funeral cannot be empty.");
                }

                while (true)
                {
                    Console.Write("Officiating Minister: ");
                    officiatingminister = Console.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(officiatingminister)) break;
                    else Console.WriteLine("Officiating Minister cannot be empty.");
                }

                string selectedPlan = "";
                int planPrice = 0;

                while (true)
                {
                    Console.WriteLine("Select a Plan\n");
                    Console.WriteLine("A. Basic Funeral Services\n");
                    Console.WriteLine("B. Cremation Services\n");
                    Console.WriteLine("C. Custom Funeral Service\n");

                    char choice;
                    if (char.TryParse(Console.ReadLine().ToUpper(), out choice))
                    {
                        switch (choice)
                        {
                            case 'A':
                                selectedPlan = "Basic Funeral Services";
                                planPrice = new BasicFuneralService().BasePrice; // Get base price
                                SalesSummary.RecordPlanSale('A');                 // Record the sale
                                break;
                            case 'B':
                                selectedPlan = "Cremation Services";
                                planPrice = new CremationService().BasePrice;    // Get base price
                                SalesSummary.RecordPlanSale('B');                // Record the sale
                                break;
                            case 'C':
                                selectedPlan = "Custom Funeral Service";
                                var customService = new CustomFuneralService();
                                customService.CustomSelectServices();            // Let the user select services
                                planPrice = customService.CalculateCost();       // Calculate the total cost
                                SalesSummary.RecordPlanSale('C');                // Record the sale
                                break;
                            default:
                                Console.WriteLine("Invalid selection. Please try again.");
                                continue;
                        }

                        // Update the revenue for the selected plan
                        SalesSummary.UpdateRevenue(planPrice, selectedPlan.Split(' ')[0]);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Please enter A, B, or C.");
                    }
                }
                Console.WriteLine($"You selected: {selectedPlan}");
                Console.WriteLine($"Total Price: P{planPrice:N}");
                SalesSummary.SaveSalesData();
                Console.WriteLine("Transaction has been recorded.");
                Console.ReadKey();


                // Create and add the customer
                var customer = new CustomerData
                {
                    Id = id,
                    LastName = lastName,
                    FirstName = firstName,
                    MiddleName = middleName,
                    ContactNumber = contactNumber,
                    Sex = sex,
                    Age = age,
                    DateOfBirth = parsedDateOfBirth,
                    DateOfDeath = parsedDateOfDeath,
                    PlaceOfBirth = placeofbirth,
                    Address = address,
                    CivilStatus = civilStatus,
                    SpouseName = spouseName,
                    FatherName = fathersname,
                    MotherName = mothersname,
                    DeceasedOccupation = deceasedOccupation,
                    InformantsName = informantsName,
                    RelationshipToTheDeceased = relationshipToTheDeceased,
                    PlaceOfFuneral = placeoffuneral,
                    OfficiatingMinister = officiatingminister,
                    SelectedPlan = selectedPlan,
                    PricePlan = planPrice
                };

                records.Add(customer);
                Console.WriteLine($"Customer added successfully! Assigned ID: {id}");
                SaveToCsv();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void ViewCustomers()
        {
            Console.WriteLine("=== Customer List ===");

            if (records.Count == 0)
            {
                Console.WriteLine("No customers found.");
            }
            else
            {
                // Create Table
                var table = new Table();
                table.Border(TableBorder.Heavy);
                table.AddColumn("Customer ID");
                table.AddColumn("Customer Name");
                table.AddColumn("Sex");
                table.AddColumns("Age");
                table.AddColumn("Address");
                table.AddColumn("Informant's Name");
                table.AddColumn("Relationship to the Deceased");
                table.AddColumn("Contact Number");
                table.AddColumns("Selected Plan");
                table.AddColumns("Price");
                table.Expand();

                // Add Rows
                foreach (var customer in records)
                {
                    table.AddRow(
                        customer.Id.ToString(),
                        $"{customer.LastName} {customer.FirstName} {customer.MiddleName}",
                        customer.Sex,
                        customer.Age,
                        customer.Address,
                        customer.InformantsName,
                        customer.RelationshipToTheDeceased,
                        customer.ContactNumber,
                        customer.SelectedPlan,
                        customer.PricePlan.ToString()
                    );
                }

                // Render Table
                AnsiConsole.Render(table);
            }

            Console.WriteLine("Press any key to continue...");
        }

        public static void UpdateCustomer()
        {
            Console.WriteLine("=== Update Customer ===");
            Console.Write("Enter Last Name of the customer to update: ");
            string searchLastName = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(searchLastName))
            {
                Console.WriteLine("Last name cannot be empty. Press any key to return to the main menu.");
                Console.ReadKey();
                return;
            }

            if (records == null || !records.Any())
            {
                Console.WriteLine("No records available. Please add some customers first.");
                Console.ReadKey();
                return;
            }

            var matchingCustomers = records
                .Where(c => c.LastName.Equals(searchLastName, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (matchingCustomers.Count == 0)
            {
                Console.WriteLine($"No customers found with the last name '{searchLastName}'.");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                return;
            }

            if (matchingCustomers.Count > 1)
            {
                Console.WriteLine("Multiple customers found. Please refine your search:");
                foreach (var customer in matchingCustomers)
                {
                    Console.WriteLine($"Customer ID: {customer.Id}, Name: {customer.FirstName} {customer.LastName}");
                }
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                return;
            }

            // Proceed to update the single matching customer
            var customerToUpdate = matchingCustomers.First();
            Console.WriteLine($"Customer found: {customerToUpdate.FirstName} {customerToUpdate.LastName}");
            UpdateCustomerDetails(customerToUpdate);
        }

        private static void UpdateCustomerDetails(CustomerData customer)
        {
            Console.WriteLine($"Updating details for {customer.FirstName} {customer.LastName} (ID: {customer.Id})");

            Console.Write("Enter New Last Name (leave blank to keep current): ");
            string lastName = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(lastName)) customer.LastName = lastName;

            Console.Write("Enter New First Name (leave blank to keep current): ");
            string firstName = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(firstName)) customer.FirstName = firstName;

            Console.Write("Enter New Age (leave blank to keep current): ");
            string age = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(age)) customer.Age = age;

            Console.Write("Enter New Sex (leave blank to keep current): ");
            string sex = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(sex)) customer.Sex = sex;

            Console.Write("Enter New Date of Birth (yyyy-MM-dd, leave blank to keep current): ");
            string dateOfBirth = Console.ReadLine()?.Trim();
            if (DateTime.TryParse(dateOfBirth, out var dob)) customer.DateOfBirth = dob;

            Console.Write("Enter New Date of Death (yyyy-MM-dd, leave blank to keep current): ");
            string dateOfDeath = Console.ReadLine()?.Trim();
            if (DateTime.TryParse(dateOfDeath, out var dod)) customer.DateOfDeath = dod;

            Console.Write("Enter New Place of Birth (leave blank to keep current): ");
            string placeOfBirth = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(placeOfBirth)) customer.PlaceOfBirth = placeOfBirth;

            Console.Write("Enter New Address (leave blank to keep current): ");
            string address = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(address)) customer.Address = address;

            Console.Write("Enter New Civil Status (leave blank to keep current): ");
            string civilStatus = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(civilStatus)) customer.CivilStatus = civilStatus;

            Console.Write("Enter New Spouse Name (leave blank to keep current): ");
            string spouseName = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(spouseName)) customer.SpouseName = spouseName;

            Console.Write("Enter New Father Name (leave blank to keep current): ");
            string fatherName = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(fatherName)) customer.FatherName = fatherName;

            Console.Write("Enter New Mother Name (leave blank to keep current): ");
            string motherName = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(motherName)) customer.MotherName = motherName;

            Console.Write("Enter New Deceased Occupation (leave blank to keep current): ");
            string deceasedOccupation = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(deceasedOccupation)) customer.DeceasedOccupation = deceasedOccupation;

            Console.Write("Enter New Informant's Name (leave blank to keep current): ");
            string informantsName = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(informantsName)) customer.InformantsName = informantsName;

            Console.Write("Enter New Relationship to the Deceased (leave blank to keep current): ");
            string relationshipToTheDeceased = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(relationshipToTheDeceased)) customer.RelationshipToTheDeceased = relationshipToTheDeceased;

            Console.Write("Enter New Contact Number (leave blank to keep current): ");
            string contactNumber = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(contactNumber)) customer.ContactNumber = contactNumber;

            Console.Write("Enter New Place of Funeral (leave blank to keep current): ");
            string placeOfFuneral = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(placeOfFuneral)) customer.PlaceOfFuneral = placeOfFuneral;

            Console.Write("Enter New Officiating Minister (leave blank to keep current): ");
            string officiatingMinister = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(officiatingMinister)) customer.OfficiatingMinister = officiatingMinister;

            Console.WriteLine("Customer details updated successfully.");
            SaveToCsv();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void DeleteCustomer()
        {
            Console.WriteLine("=== Delete Customer ===");
            try
            {
                Console.Write("Enter Customer Last Name to delete: ");
                string lastName = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(lastName))
                {
                    Console.WriteLine("Last name cannot be empty.");
                }
                else
                {
                    var matchingCustomers = records.Where(c => c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase)).ToList();

                    if (matchingCustomers.Count == 0)
                    {
                        Console.WriteLine("No customers found with the specified last name.");
                    }
                    else if (matchingCustomers.Count == 1)
                    {
                        // If only one customer matches, delete it
                        var customer = matchingCustomers.First();
                        records.Remove(customer);
                        Console.WriteLine($"Customer '{customer.FirstName} {customer.LastName}' deleted successfully.");
                        SaveToCsv();
                    }
                    else
                    {
                        // If multiple customers match, display options
                        Console.WriteLine("Multiple customers found with the same last name:");
                        for (int i = 0; i < matchingCustomers.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}: {matchingCustomers[i].FirstName} {matchingCustomers[i].LastName} (ID: {matchingCustomers[i].Id})");
                        }

                        Console.Write("Enter the number of the customer to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= matchingCustomers.Count)
                        {
                            var customer = matchingCustomers[choice - 1];
                            records.Remove(customer);
                            Console.WriteLine($"Customer '{customer.FirstName} {customer.LastName}' deleted successfully.");
                            SaveToCsv();
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public static void SearchCustomer()
        {
            Console.WriteLine("=== Search Customer by Last Name ===");
            Console.Write("Enter Last Name to search: ");
            string searchLastName = Console.ReadLine();

            var matchingCustomers = records.Where(c => c.LastName.Equals(searchLastName, StringComparison.OrdinalIgnoreCase)).ToList();

            if (matchingCustomers.Any())
            {
                Console.WriteLine("Matching Customers:");
                foreach (var customer in matchingCustomers)
                {
                    Console.WriteLine($"ID: {customer.Id}, Name: {customer.LastName} {customer.FirstName} {customer.MiddleName}, Contact: {customer.ContactNumber}");
                }
            }
            else
            {
                Console.WriteLine("No customers found with the specified last name.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private static void SaveToCsv()
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(records);
                }
                Console.WriteLine("Customer data saved to CSV.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data to CSV: {ex.Message}");
            }
        }
    }

}