using System;
using System.Collections.Generic;
using ThoughtworksTrains.Business;
using ThoughtworksTrains.Domain.Interfaces;
using ThoughtworksTrains.Domain;

namespace ThoughtworksTrains.Application
{
    public class CommandStart
    {
        private CalculateDistance calculateDistance;
        private IGraph graph;
        public CommandStart(String input) {
            
            calculateDistance = new CalculateDistance();
            graph = new Map();
            
            foreach (var inpt in input.Split(","))
            {
                graph.AddPath(
                    new Route(
                        NewInstanceCity(inpt[0].ToString().Trim().ToUpper()), 
                        NewInstanceCity(inpt[1].ToString().Trim().ToUpper().ToString()), 
                        Int64.Parse(inpt[2].ToString().Trim())
                    )
                );
            }
        }
        public IEnumerable<String> GetOutput() 
        {
            List<String> retorno = new List<String>();
            
            retorno.Add(calculateDistance.Distance(graph, new List<City>() { NewInstanceCity("A"), NewInstanceCity("D"), NewInstanceCity("C") }).ToString());

            return retorno;
        }

        public City NewInstanceCity(String name) =>  new City(name);
    }
}