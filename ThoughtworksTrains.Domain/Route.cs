using System;
using ThoughtworksTrains.Domain.Interfaces;

namespace ThoughtworksTrains.Domain
{
    public class Route : IPath
    {
        public INode Source { get; }
        public INode Target { get; }
        public Int64 Distance { get; }

        public Route(City source, City target, Int64 distance) 
        {
            if(source == null || target == null || distance < 0)
                throw new ArgumentException("The information of route should be positive, check if params were passed correlty!");
            this.Source = source;
            this.Target = target;
            this.Distance = distance;
        }

        public bool Equals(IPath other)
        {
            return other != null 
                && this.Target.Equals(((Route)other).Target)
                && this.Source.Equals(((Route)other).Source);
        }

        public override int GetHashCode() 
        {
            var hashCode = 352033288;
            hashCode = hashCode * -1521134295 + this.Source.GetHashCode();
            hashCode = hashCode * -1521134295 + this.Target.GetHashCode();
            return hashCode;
        }
    }
}