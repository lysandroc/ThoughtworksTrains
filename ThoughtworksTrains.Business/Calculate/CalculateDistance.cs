using System;
using System.Linq;
using System.Collections.Generic;
using ThoughtworksTrains.Domain.Interfaces;
using ThoughtworksTrains.Domain.Exceptions;

namespace ThoughtworksTrains.Business.Calculate
{
    public class CalculateDistance : ICalculateDistance
    {
        public Int64 Distance(IGraph graph, IReadOnlyList<INode> nodes)
        {
            try
            {
                Int64 distance =0;
                var position =0;
                
                foreach (var item in nodes.Take(nodes.Count-1))
                {
                    INode nextNode = nodes.ElementAt(position+1);

                    if(!graph.NodeHasRelationship(item, nextNode))
                        return 0;

                    distance += graph
                        .GetPaths(item)
                        .Where(p=> p.Target.Equals(nextNode))
                        .First().Distance;
                    
                    position +=1;
                }

                return distance;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}