using System.Collections;
using System.ComponentModel.Design;

namespace Calendar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HomeCalendar homeCalendar = new HomeCalendar();
            homeCalendar.ReadFromFile("../../../test.calendar");
            Console.WriteLine("Welcome to the Calendar Application!");

            Console.WriteLine("How would you like to get your Calendar item by");
            Menu();
            string choice = Console.ReadLine();
            (DateTime?, DateTime?, bool, int) parameters = GetSpecifications();

            switch (choice)
            {
                case "1":
                    List<CalendarItem> allItems = homeCalendar.GetCalendarItems(parameters.Item1,parameters.Item2,parameters.Item3,parameters.Item4);
                    DisplayCalendarItems(allItems);
                    break;
                case "2":
                    List<CalendarItemsByMonth> monthItems = homeCalendar.GetCalendarItemsByMonth(parameters.Item1,parameters.Item2,parameters.Item3,parameters.Item4);
                    DisplayCalendarItemsByMonth(monthItems);
                    break;
                case "3":
                    List<CalendarItemsByCategory> categoryItems =
                    homeCalendar.GetCalendarItemsByCategory(parameters.Item1,parameters.Item2,parameters.Item3,parameters.Item4);
                    DisplayCalendarItemsByCategory(categoryItems);
                    break;
                case "4":
                    List<Dictionary<string, object>> monthCategoryItems =
                    homeCalendar.GetCalendarDictionaryByCategoryAndMonth(parameters.Item1,parameters.Item2,parameters.Item3,parameters.Item4);
                    DisplayCalendarDictionaryByCategoryAndMonth(monthCategoryItems);
                    break;
                case "5":
                    Console.WriteLine("Exiting the application. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        static void Menu()
        {
            Console.WriteLine("1 - Get Calendar items All");
            Console.WriteLine("2 - Get Calendar items by Month");
            Console.WriteLine("3 - Get Calendar items by Category");
            Console.WriteLine("4 - Get Calendar items by Category and Month");
            Console.WriteLine("5 - Exit");
        }

        static (DateTime?, DateTime?, bool, int) GetSpecifications()
        {
            // Get start date
            Console.Write("Enter start date (yyyy-mm-dd) or press Enter for null: ");
            string startInput = Console.ReadLine();
            DateTime? startDate = null;
            if (!string.IsNullOrWhiteSpace(startInput))
            {
                startDate = DateTime.Parse(startInput);
            }

            // Get end date
            Console.Write("Enter end date (yyyy-mm-dd) or press Enter for null: ");
            string endInput = Console.ReadLine();
            DateTime? endDate = null;
            if (!string.IsNullOrWhiteSpace(endInput))
            {
                endDate = DateTime.Parse(endInput);
            }

            // Get filter choice
            Console.Write("Would you like to filter by category? (y/n): ");
            string filterChoice = Console.ReadLine();
            bool filter = filterChoice.ToLower() == "y";

            // Get category ID if filtering
            int categoryId = 0;
            if (filter)
            {
                Console.Write("Enter category number: ");
                int.TryParse(Console.ReadLine(), out categoryId);
            }

            return (startDate, endDate, filter, categoryId);
        }

        static void DisplayCalendarItems(List<CalendarItem> items)
        {
            Console.WriteLine($"=== Total Items: {items.Count} ===\n");
            Console.WriteLine($"{"Cat_ID", -10} {"Event_ID", -15} {"StartDateTime", -25} {"ShortDescription", -30} {"TotalBusyTime", -20} {"DurationInMinutes", -20}");
            Console.WriteLine(new string('-', 120));

            foreach (CalendarItem item in items)
            {
                Console.WriteLine($"{item.CategoryID, -10} {item.EventID, -15} {item.StartDateTime, -25:M/d/yyyy h:mm:ss tt} {item.ShortDescription, -30} {item.BusyTime, -20} {item.DurationInMinutes, -20}");
            }
        }

        static void DisplayCalendarItemsByMonth(List<CalendarItemsByMonth> monthItems)
        {
            double totalBusyTime = 0;
            foreach (var m in monthItems)
            {
                totalBusyTime += m.TotalBusyTime;
            }
            Console.WriteLine($"=== Total Items: {monthItems.Count} ===\n");
            Console.WriteLine( $"{"Cat_ID", -10} {"Event_ID", -15} {"StartDateTime", -25} {"ShortDescription", -30} {"TotalBusyTime", -20} {"DurationInMinutes", -20}");
            Console.WriteLine(new string('-', 120));

            foreach (var monthItem in monthItems)
            {
                foreach (var subItem in monthItem.Items)
                {
                    Console.WriteLine($"{subItem.CategoryID, -10} {subItem.EventID, -15} {subItem.StartDateTime, -25:M/d/yyyy h:mm:ss tt} {subItem.ShortDescription, -30} {subItem.BusyTime, -20} {subItem.DurationInMinutes, -20}");
                }
            }
        }

        static void DisplayCalendarItemsByCategory(List<CalendarItemsByCategory> categoryItems)
        {
            double totalBusyTime = 0;
            foreach (var c in categoryItems)
            {
                totalBusyTime += c.TotalBusyTime;
            }
            Console.WriteLine($"=== Total Items: {categoryItems.Count} ===\n");
            Console.WriteLine($"{"Cat_ID", -10} {"Event_ID", -15} {"StartDateTime", -25} {"ShortDescription", -30} {"TotalBusyTime", -20} {"DurationInMinutes", -20}");
            Console.WriteLine(new string('-', 120));

            foreach (var catItem in categoryItems)
            {
                foreach (var subItem in catItem.Items)
                {
                  Console.WriteLine( $"{subItem.CategoryID, -10} {subItem.EventID, -15} {subItem.StartDateTime, -25:M/d/yyyy h:mm:ss tt} {subItem.ShortDescription, -30} {subItem.BusyTime, -20} {subItem.DurationInMinutes, -20}");
                }
            }
        }

        static void DisplayCalendarDictionaryByCategoryAndMonth(List<Dictionary<string, object>> dictItems)
        {
            Console.WriteLine("\n=== Calendar Items by Category and Month ===");
            foreach (var record in dictItems)
            {
                Console.WriteLine($"\nMonth: {record["Month"]}");
                foreach (var key in record.Keys)
                {
                    if (key != "Month" && !key.StartsWith("items:"))
                    {
                        Console.WriteLine($"  {key}: {record[key]} mins");
                    }
                }
            }
        }
    }
}
