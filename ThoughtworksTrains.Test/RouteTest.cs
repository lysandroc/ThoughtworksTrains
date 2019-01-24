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
            Action actionInvalidRoute = () => { new Route(null, null, -1); };
            Assert.Throws<RouteException>(actionInvalidRoute);
        }

        [Fact]
        public void ValidRoute()
        {
            var ex = Record.Exception(() => { new Route(new City { Name="A" }, new City { Name="B" }, 1); });
            Assert.Null(ex);
        }
    }
}