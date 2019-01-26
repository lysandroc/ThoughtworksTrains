using System;
using Xunit;
using ThoughtworksTrains.Domain;
using ThoughtworksTrains.Domain.Exceptions;

namespace ThoughtworksTrains.Test
{
    public class RouteTest
    {
        [Fact]
        public void InvalidRoute()
        {
            Action actionInvalidRoute = () => { new Route("A", null, null, -1); };
            Assert.Throws<RouteException>(actionInvalidRoute);
        }

        [Fact]
        public void ValidRoute()
        {
            var ex = Record.Exception(() => { new Route("A", new City("A", "A"), new City("B", "B"), 1); });

            Assert.Null(ex);
        }
    }
}