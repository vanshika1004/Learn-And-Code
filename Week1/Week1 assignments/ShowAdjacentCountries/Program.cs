using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowAdjacentCountries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Show Adjacent Country\n");

            while (true)
            {
                Console.Write("Enter a 2-letter country code or type EXIT to quit: \n");

                var countryCode = Console.ReadLine()?.Trim().ToUpperInvariant();

                if (string.Equals(countryCode, "EXIT", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Exiting...");
                    break;
                }
                if (!IsValidCountryCode(countryCode))
                {
                    Console.WriteLine("Invalid input. Please enter a 2-letter country code.");
                    continue;
                }
                if (!CountryNeighbors.GetNeighboringCountries(countryCode, out var countryName, out var neighbors))
                {
                    Console.WriteLine($"No data found for country code '{countryCode}'.\n");
                    continue;
                }

                Console.WriteLine($"Country : {countryName}");
                Console.WriteLine("Adjacents :");

                foreach (var neighbor in neighbors)
                {
                    Console.WriteLine($" - {neighbor}");
                }
            }
        }


        private static bool IsValidCountryCode(string code)
        {
            return !string.IsNullOrWhiteSpace(code) && code.Length == 2;
        }
    }

        internal static class CountryNeighbors
        { private static readonly Dictionary<string, (string Country, List<string> Neighbors)>
            countriesData = new Dictionary<string, (string Country, List<string> Neighbors)>(StringComparer.OrdinalIgnoreCase) 
            { 
                { "IN", ("India", new List<string> { "China", "Pakistan", "Nepal", "Bhutan", "Bangladesh", "Myanmar", "Afghanistan" }) },
                { "US", ("United States", new List<string> { "Canada", "Mexico" }) },
                { "CA", ("Canada", new List<string> { "United States" }) },
                { "MX", ("Mexico", new List<string> { "United States", "Guatemala", "Belize" }) },
                { "CN", ("China", new List<string> { "India", "Mongolia", "Russia", "Nepal", "Bhutan", "Myanmar", "Vietnam", "Laos", "North Korea", "Pakistan", "Afghanistan", "Kazakhstan", "Kyrgyzstan", "Tajikistan" }) },
                { "RU", ("Russia", new List<string> { "China", "Mongolia", "Kazakhstan", "Ukraine", "Belarus", "Latvia", "Estonia", "Lithuania", "Finland", "Georgia", "Azerbaijan", "Norway", "Poland" }) },
                { "BR", ("Brazil", new List<string> { "Argentina", "Bolivia", "Peru", "Colombia", "Venezuela", "Guyana", "Suriname", "French Guiana", "Paraguay", "Uruguay" }) },
                { "AR", ("Argentina", new List<string> { "Chile", "Bolivia", "Paraguay", "Brazil", "Uruguay" }) },
                { "DE", ("Germany", new List<string> { "France", "Poland", "Netherlands", "Belgium", "Luxembourg", "Austria", "Czech Republic", "Denmark", "Switzerland" }) },
                { "FR", ("France", new List<string> { "Spain", "Belgium", "Luxembourg", "Germany", "Switzerland", "Italy", "Andorra", "Monaco" }) },
                { "ES", ("Spain", new List<string> { "Portugal", "France", "Andorra" }) },
                { "IT", ("Italy", new List<string> { "France", "Switzerland", "Austria", "Slovenia" }) },
                { "CH", ("Switzerland", new List<string> { "France", "Germany", "Austria", "Italy" }) },
                { "AU", ("Australia", new List<string> { "Papua New Guinea", "Indonesia (sea border)", "New Zealand (closest regionally)" }) }, { "NZ", ("New Zealand", new List<string> { "Australia" }) },
                { "PK", ("Pakistan", new List<string> { "India", "Afghanistan", "China", "Iran" }) },
                { "AF", ("Afghanistan", new List<string> { "Pakistan", "Iran", "Turkmenistan", "Uzbekistan", "Tajikistan", "China" }) },
                { "ET", ("Ethiopia", new List<string> { "Eritrea", "Djibouti", "Somalia", "Kenya", "South Sudan", "Sudan" }) },
                { "ZA", ("South Africa", new List<string> { "Namibia", "Botswana", "Zimbabwe", "Mozambique", "Eswatini", "Lesotho" }) }
            };
        public static bool GetNeighboringCountries( string countryCode, out string countryName, out IReadOnlyCollection<string> neighbors)
        { if (countriesData.TryGetValue(countryCode, out var entry))
            {
                countryName = entry.Country; neighbors = entry.Neighbors; return true;
            }
            countryName = string.Empty;
            neighbors = Array.Empty<string>();
            return false;
        }
    }
    }
