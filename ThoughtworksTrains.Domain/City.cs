using System;
using ThoughtworksTrains.Domain.Interfaces;

namespace ThoughtworksTrains.Domain
{
    public class City : INode
    {
        public String Name { get; set; }
        
        public City(String id, String name) 
        {
            this.Name = name;
        }

        public override string ToString() => this.Name;

        public bool Equals(INode other)
        {
            return other != null && Name.Equals(((City)other).Name);
        }

        public override int GetHashCode()
        {
            var hashCode = 352033280;
            hashCode = hashCode * -1521134295 + this.Name.GetHashCode();
            return hashCode;
        }
  }   
}