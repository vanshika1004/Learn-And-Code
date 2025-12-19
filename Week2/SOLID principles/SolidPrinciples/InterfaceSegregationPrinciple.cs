using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_principles
{
    internal class InterfaceSegregationPrinciple
    {
        public static void Run()
        {
            IPrinter printer = new SimplePrinter();
            IScanner scanner = new SimpleScanner();

            printer.Print("Hello ISP");
            scanner.Scan();

        }
    }
    //ISP - Interface Segregation Principle - A class should not be forced to implement methods it does not use.
    interface IPrinter
    {
        void Print(string content);
    }

    interface IScanner
    {
        void Scan();
    }

    // Only prints, not forced to implement Scan
    class SimplePrinter : IPrinter
    {
        public void Print(string content)
        {
            Console.WriteLine($"Printing: {content}");
        }
    }

    // Only scans, not forced to implement Print
    class SimpleScanner : IScanner
    {
        public void Scan()
        {
            Console.WriteLine("Scanning document...");
        }
    }
}
