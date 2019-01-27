using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using ThoughtworksTrains.Business.Calculate;
using ThoughtworksTrains.Domain.Interfaces;
using ThoughtworksTrains.Domain;
using ThoughtworksTrains.Domain.Criterion;

namespace ThoughtworksTrains.Application
{
    public class CommandStart
    {
        private readonly ICalculateDistance calculateDistance;
        private readonly ICalculateNumberPathsWithCriterion calculateWithCriterion;
        private readonly ICalculateShortestPath calculateShortestPath;
        private readonly IGraph graph;
        public CommandStart(IServiceProvider serviceProvider, String input) 
        {
            graph = serviceProvider.GetService<IGraph>();
            calculateDistance = serviceProvider.GetService<ICalculateDistance>();
            calculateWithCriterion = serviceProvider.GetService<ICalculateNumberPathsWithCriterion>();
            calculateShortestPath = serviceProvider.GetService<ICalculateShortestPath>();
            
            foreach (var route in input.Split(","))
            {
                if(MatchFail(route))
                    throw new Exception();

                graph.AddPath(
                    new Route(
                        new City(FormatString(route,0)), 
                        new City(FormatString(route,1)), 
                        Int64.Parse(FormatString(route,2))
                    )
                );
            }
        }
        public List<Int64> GetOutput() 
        {
            List<Int64> retorno = new List<Int64>();
            
            retorno.Add(calculateDistance.Distance(graph, new List<City>() { new City("A"), new City("B"), new City("C") }));
            retorno.Add(calculateDistance.Distance(graph, new List<City>() { new City("A"), new City("D") }));
            retorno.Add(calculateDistance.Distance(graph, new List<City>() { new City("A"), new City("D"), new City("C") }));
            retorno.Add(calculateDistance.Distance(graph, new List<City>() { new City("A"), new City("E"), new City("B"), new City("C"), new City("D") }));
            retorno.Add(calculateDistance.Distance(graph, new List<City>() { new City("A"), new City("E"), new City("D") }));
            retorno.Add(calculateWithCriterion.NumberPathsWithCriterion(graph, new City("C"), new City("C"), new TripsWithMaxThreeStops()));
            retorno.Add(calculateWithCriterion.NumberPathsWithCriterion(graph, new City("A"), new City("C"), new TripsWithExactlyFourStops()));
            retorno.Add(calculateShortestPath.ShortestDistance(graph, new City("A"), new City("C")));
            retorno.Add(calculateShortestPath.ShortestDistance(graph, new City("B"), new City("B")));
            retorno.Add(calculateWithCriterion.NumberPathsWithCriterion(graph, new City("C"), new City("C"), new TripsWithThirtyDistanceToStop()));
            return retorno;
        }

        private String FormatString(String text, int delimiter) => text.ToString().Trim().ToUpper().Substring(delimiter,1);
        private bool MatchFail(String route) => !(new Regex(@"^[a-zA-z]{2,2}\d{1}$").Match(route.Trim().ToString()).Success);
    }
}