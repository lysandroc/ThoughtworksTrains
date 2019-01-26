using System.Collections.Generic;

namespace ThoughtworksTrains.Domain.Interfaces
{
    public interface IGraph
    {
        IReadOnlyList<IPath> GetPaths(INode source);
        void AddPath(IPath path);
        bool NodeHasRelationship(INode currentNode, INode nextNode);
    }
}