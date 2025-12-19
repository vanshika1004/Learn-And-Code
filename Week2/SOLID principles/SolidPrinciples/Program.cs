using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_principles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program started For SRP\nSRP - Single Responsibility Principle - This principle says a class should have only one reason to change.");
            SRP.Run();
            Console.WriteLine("Program ended For SRP\n\n");

            Console.WriteLine("Program started For OCP\nOCP- Open Closed Principle - Open for Extension, Closed for Modification");
            OCP.Run();
            Console.WriteLine("Program ended For OCP\n\n");

            Console.WriteLine("Program started For LSP\nLSP - Liskov Substitution Principle - Subclasses should be substitutable for their base class without breaking behavior.");
            LSP.Run();
            Console.WriteLine("Program ended For LSP\n\n");

            Console.WriteLine("Program started For ISP\nISP - Interface Segregation Principle - A class should not be forced to implement methods it does not use.");
            InterfaceSegregationPrinciple.Run();
            Console.WriteLine("Program ended For ISP\n\n");

            Console.WriteLine("Program started For DIP\nDIP - Dependency Inversion Principle - High‑level modules depend on abstractions, not on concrete classes.");
            InterfaceSegregationPrinciple.Run();
            Console.WriteLine("Program ended For DIP\n\n");

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine(); 
        }
    }
}
