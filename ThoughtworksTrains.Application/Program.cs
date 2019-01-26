using System;
using System.Collections.Generic;
using ThoughtworksTrains.Application;

namespace ThoughtworksTrains.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Write your Graph here, follow this example below.");
                Console.WriteLine("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");

                CommandStart commandStart = new CommandStart(Console.ReadLine());
                
                foreach (String output in commandStart.GetOutput())
                    Console.WriteLine($"{output}");  
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }     
        }
    }
}
