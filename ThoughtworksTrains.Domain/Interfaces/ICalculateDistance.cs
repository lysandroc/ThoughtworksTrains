using System;
using System.Collections.Generic;

namespace ThoughtworksTrains.Domain.Interfaces
{
    public interface ICalculateDistance
    {
        Int64 Distance(IGraph graph, IReadOnlyList<INode> nodes);
    }
}