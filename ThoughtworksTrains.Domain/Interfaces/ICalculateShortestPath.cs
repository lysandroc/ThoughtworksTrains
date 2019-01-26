using System;

namespace ThoughtworksTrains.Domain.Interfaces
{
    public interface ICalculateShortestPath
    {
        Int64 ShortestDistance(IGraph graph, INode from, INode to);
    }
}