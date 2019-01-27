using Xunit;
using System;
using System.Collections.Generic;
using ThoughtworksTrains.Domain;
using ThoughtworksTrains.Domain.Interfaces;
using ThoughtworksTrains.Domain.Exceptions;
using ThoughtworksTrains.Business.Calculate;

namespace ThoughtworksTrains.Test.Business
{
    public class CalculateShortestDistance
    {
        private readonly IGraph _graph;
        private readonly ICalculateShortestPath _calculate;

        public CalculateShortestDistance()
        {
            _graph = new Map();
            _graph.AddPath(new Route(new City("A"), new City("B"), 5));
            _graph.AddPath(new Route(new City("B"), new City("C"), 4));
            _graph.AddPath(new Route(new City("C"), new City("D"), 8));
            _graph.AddPath(new Route(new City("D"), new City("C"), 8));
            _graph.AddPath(new Route(new City("D"), new City("E"), 6));
            _graph.AddPath(new Route(new City("A"), new City("D"), 5));
            _graph.AddPath(new Route(new City("C"), new City("E"), 2));
            _graph.AddPath(new Route(new City("E"), new City("B"), 3));
            _graph.AddPath(new Route(new City("A"), new City("E"), 7));

            _calculate = new CalculateShortestPath();
        }

        [Fact]
        public void ReturnMinDistanceAC()
        {
            var distance = _calculate.ShortestDistance(_graph, new City("A"), new City("C"));

            Assert.Equal(9, distance);
        }

        [Fact]
        public void ReturnMinDistanceBB()
        {
            var distance = _calculate.ShortestDistance(_graph, new City("B"), new City("B"));

            Assert.Equal(9, distance);
        }
        
        [Fact]
        public void ReturnNoSuchRouteToZY()
        {
            Action actionInvalidRoute = () => {
                _calculate.ShortestDistance(_graph, new City("Z"), new City("Y") );
            };

            Assert.Throws<RouteException>(actionInvalidRoute);
        }
    }
}