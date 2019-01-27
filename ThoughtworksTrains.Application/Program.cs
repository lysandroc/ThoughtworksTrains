using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using ThoughtworksTrains.Application;
using ThoughtworksTrains.Domain.Interfaces;
using ThoughtworksTrains.Domain;
using ThoughtworksTrains.Business.Calculate;

namespace ThoughtworksTrains.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var serviceProvider = new ServiceCollection()
                    .AddTransient<ICalculateDistance, CalculateDistance>()
                    .AddTransient<ICalculateNumberPathsWithCriterion, CalculateNumberPathsWithCriterion>()
                    .AddTransient<ICalculateShortestPath, CalculateShortestPath>()
                    .AddTransient<IGraph, Map>()
                    .BuildServiceProvider();

                Console.WriteLine("Write your Graph here, follow this example below.");
                Console.WriteLine("Example Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
                Console.Write("Graph: ");
                
                CommandStart commandStart = new CommandStart(serviceProvider, Console.ReadLine());
                
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
