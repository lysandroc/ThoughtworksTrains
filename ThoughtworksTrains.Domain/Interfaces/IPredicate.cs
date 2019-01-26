using System;

namespace ThoughtworksTrains.Domain.Interfaces
{
    public interface IPredicate
    {
        IGraph Graph {get;}
        INode Target { get; }
        INode CurrentNode { get;}
        Int64 CurrentChildNumber { get; }
        Int64 CurrentDistance { get; }
    }
}