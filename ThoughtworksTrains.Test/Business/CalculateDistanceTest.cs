using Xunit;
using System;
using System.Collections.Generic;
using ThoughtworksTrains.Domain;
using ThoughtworksTrains.Domain.Interfaces;
using ThoughtworksTrains.Business;

namespace ThoughtworksTrains.Test.Business
{
    public class CalculateDistanceTest
    {
        private readonly IGraph _graph;
        private readonly ICalculateDistance _calculate;

        public CalculateDistanceTest() {
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

            _calculate = new CalculateDistance();
        }

        [Fact]
        public void ReturnNineToABC()
        {
            var distance = _calculate.Distance(_graph, new List<City>() { new City("A"), new City("B"), new City("C") });

            Assert.Equal(9, distance);
        }

        [Fact]
        public void ReturnFiveToAD()
        {
            var distance = _calculate.Distance(_graph, new List<City>() { new City("A"), new City("D") });

            Assert.Equal(5, distance);
        }
        
        [Fact]
        public void ReturnThirTeenToADC()
        {
            var distance = _calculate.Distance(_graph, new List<City>() { new City("A"), new City("D"), new City("C") });

            Assert.Equal(13, distance);
        }

        [Fact]
        public void ReturnTwentyTwoToAEBCD()
        {
            var distance = _calculate.Distance(_graph, new List<City>() { new City("A"), new City("E"), new City("B"), new City("C"), new City("D") });

            Assert.Equal(22, distance);
        }

        [Fact]
        public void ReturnNoSuchRouteToAED()
        {
            Action actionInvalidRoute = () => {
                _calculate.Distance(_graph, new List<City>() { new City("A"), new City("E"), new City("D") });
            };

            Assert.Throws<Exception>(actionInvalidRoute);
        }

        [Fact]
        public void ReturnNoSuchRouteToZY()
        {
            Action actionInvalidRoute = () => {
                _calculate.Distance(_graph, new List<City>() { new City("Z"), new City("Y") });
            };

            Assert.Throws<Exception>(actionInvalidRoute);
        }
    }
}