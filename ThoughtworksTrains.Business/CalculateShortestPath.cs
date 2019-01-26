using System;
using System.Linq;
using System.Collections.Generic;
using ThoughtworksTrains.Domain.Interfaces;

namespace ThoughtworksTrains.Business
{
    public class CalculateShortestPath : ICalculateShortestPath
    {
        private IList<Int64> distances;

        public long ShortestDistance(IGraph graph, INode from, INode to)
        {
            this.distances = new List<Int64>();

            ShortestPathRecursive(graph, from, to, 0, new List<IPath>());

            return distances.Min();
        }

        private void ShortestPathRecursive(IGraph graph, INode from, INode to, Int64 distanceCurrent, IList<IPath> visited) 
        {
            foreach(var item in graph.GetPaths(from)) 
            {
                if(!visited.Contains(item)) {
                    visited.Add(item);
                    if(!item.Target.Equals(to))
                        ShortestPathRecursive(graph, item.Target, to, distanceCurrent + item.Distance, new List<IPath>(visited));
                    else
                        distances.Add(distanceCurrent + item.Distance);
                }
            }
        }
    }
}