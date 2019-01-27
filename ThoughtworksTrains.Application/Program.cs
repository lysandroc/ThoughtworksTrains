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
                Console.WriteLine("Example Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
                Console.Write("Graph: ");
                
                CommandStart commandStart = new CommandStart(Console.ReadLine());
                
                int index=1;   
                foreach (Int64 distance in commandStart.GetOutput()) 
                {
                    var output = distance == 0 ? "NO SUCH ROUTE" : distance.ToString();
                    Console.WriteLine($"Output #{index}: {output}");
                    index++; 
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please provide a valid router");
            }
        }
    }
}
