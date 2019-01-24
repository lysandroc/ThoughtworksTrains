using System;

namespace ThoughtworksTrains.Domain.Exceptions
{
    public class RouteException : Exception
    {
        public RouteException(string message) : base(message)
        {
        } 
    }
}