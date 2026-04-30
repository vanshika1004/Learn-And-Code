using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("v1 working");
        Console.WriteLine("v2 working");
        Console.WriteLine("v3 working");
        throw new Exception("bug introduced");
    }
}