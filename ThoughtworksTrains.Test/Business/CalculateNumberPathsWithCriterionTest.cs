using Xunit;
using System;
using System.Collections.Generic;
using ThoughtworksTrains.Domain;
using ThoughtworksTrains.Domain.Interfaces;
using ThoughtworksTrains.Domain.Criterion;
using ThoughtworksTrains.Business;

namespace ThoughtworksTrains.Test.Business
{
    public class CalculateNumberPathsWithCriterionTest
    {
        private readonly IGraph _graph;
        private readonly ICalculateNumberPathsWithCriterion _calculateNumberPathsWithCriterion;

        public CalculateNumberPathsWithCriterionTest()
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

            _calculateNumberPathsWithCriterion = new CalculateNumberPathsWithCriterion();
        }

        [Fact]
        public void ReturnTripsCToCWithMaxThreeStops()
        {
            var number = _calculateNumberPathsWithCriterion.NumberPathsWithCriterion(_graph, new City("C"), new City("C"), new TripsWithMaxThreeStops());

            Assert.Equal(2, number);
        }

        [Fact]
        public void ReturnTripsACWithExatlyFourStops()
        {
            var number = _calculateNumberPathsWithCriterion.NumberPathsWithCriterion(_graph, new City("A"), new City("C"), new TripsWithExactlyFourStops());

            Assert.Equal(3, number);
        }

        [Fact]
        public void ReturnTripsCCWithDistanceLessThanThirtyStops()
        {
            var number = _calculateNumberPathsWithCriterion.NumberPathsWithCriterion(_graph, new City("C"), new City("C"), new TripsWithThirtyDistanceToStop());

            Assert.Equal(7, number);
        }

    }
}