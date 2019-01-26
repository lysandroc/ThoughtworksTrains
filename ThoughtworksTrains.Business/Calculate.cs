using System;
using System.Linq;
using System.Collections.Generic;
using ThoughtworksTrains.Domain.Interfaces;

namespace ThoughtworksTrains.Business
{
    public class Calculate : ICalculateDistance //, ICalculateNumberPathsWithCriterion, ICalculateMinPath
    {
        private Int64 NumberPath { get; set; }

        public Int64 CalculateDistance(IGraph graph, IReadOnlyList<INode> nodes)
        {
            try
            {
                Int64 distance =0;
                var position =0;
                
                foreach (var item in nodes.Take(nodes.Count-1))
                {
                    INode nextNode = nodes.ElementAt(position+1);

                    graph.NodeHasRelationship(item, nextNode);

                    distance+= graph
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

        // Int64 CalculateNumberPathsWithCriterion(IGraph graph, INode from, INode to, ICriterion<IPredicate> criterion)
        // {
        
        // }
        // Int64 CalculateMinPath(IGraph graph, INode from, INode to)
        // {

        // }
    }
}