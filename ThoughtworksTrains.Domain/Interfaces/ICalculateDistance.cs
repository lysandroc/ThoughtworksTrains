using System;
using System.Collections.Generic;

namespace ThoughtworksTrains.Domain.Interfaces
{
    public interface ICalculateDistance
    {
        Int64 CalculateDistance(IGraph graph, IReadOnlyList<INode> nodes);
    }
}