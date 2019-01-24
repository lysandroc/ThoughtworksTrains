using ThoughtworksTrains.Domain.Exceptions;

namespace ThoughtworksTrains.Domain
{
    public class Route
    {
        public City SourceCity { get; }
        public City TargetCity { get; }
        public int Distance { get; }

        public Route(City Source, City Target, int Distance) 
        {
            if(Source == null || Target == null || Distance < 0)
                throw new RouteException("The information of route should be positive, check if params were passed correlty!");
            this.SourceCity = Source;
            this.TargetCity = Target;
            this.Distance = Distance;
        }
    }
}