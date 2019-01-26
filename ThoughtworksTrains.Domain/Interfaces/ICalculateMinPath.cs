using System;

namespace ThoughtworksTrains.Domain.Interfaces
{
    public interface ICalculateMinPath
    {
        Int64 CalculateMinPath(IGraph graph, INode from, INode to);
    }
}