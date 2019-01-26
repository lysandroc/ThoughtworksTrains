using System.Collections.Generic;

namespace ThoughtworksTrains.Domain.Interfaces
{
    public interface IGraph
    {
        IReadOnlyList<IPath> GetPaths(INode from);
        void AddPath(IPath path);
    }
}