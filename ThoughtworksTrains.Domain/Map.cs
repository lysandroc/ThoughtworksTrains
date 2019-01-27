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
        private IDictionary<INode, IList<IPath>> _graph;

        public Map() => this._graph = new Dictionary<INode, IList<IPath>>();

        public void AddPath(IPath path) {
            if (this._graph.ContainsKey(path.Source))
                this._graph[path.Source].Add(path);
            else
                this._graph.Add(path.Source, new List<IPath>() { path });
        }
        public IReadOnlyList<IPath> GetPaths(INode source)
        {
            if (this._graph.ContainsKey(source))
                return new List<IPath>(this._graph[source]);
            else
                throw new RouteException("NO SUCH ROUTE");
        }

        public bool NodeHasRelationship(INode currentNode, INode nextNode)
        {
            return this._graph.ContainsKey(currentNode) && this._graph[currentNode]
                .Where(adjacentVertex => nextNode.Equals(adjacentVertex.Target))
                .Count() > 0;
        }
    }
}