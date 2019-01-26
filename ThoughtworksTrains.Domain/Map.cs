using System;
using System.Linq;
using System.Collections.Generic;
using ThoughtworksTrains.Domain;
using ThoughtworksTrains.Domain.Interfaces;
using ThoughtworksTrains.Domain.Exceptions;

namespace ThoughtworksTrains.Domain
{
    public class Map : IGraph
    {
        private IDictionary<INode, IList<IPath>> Graph;

        public Map() => this.Graph = new Dictionary<INode, IList<IPath>>();

        public void AddPath(IPath path) {
            if (this.Graph.ContainsKey(path.Source))
                this.Graph[path.Source].Add(path);
            else
                this.Graph.Add(path.Source, new List<IPath>() { path });
        }
        public IReadOnlyList<IPath> GetPaths(INode source)
        {
            if (this.Graph.ContainsKey(source))
                return new List<IPath>(this.Graph[source]);
            else
                throw new RouteException("NO SUCH ROUTE");
        }

        public bool NodeHasRelationship(INode currentNode, INode nextNode)
        {
            return this.Graph[currentNode]
            .Where(adjacentVertex => nextNode.Equals(adjacentVertex.Target))
            .Count() > 0;
        }
    }
}