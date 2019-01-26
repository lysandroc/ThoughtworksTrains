using System;
using ThoughtworksTrains.Domain.Interfaces;

namespace ThoughtworksTrains.Domain.Predicates
{
    public class Predicate : IPredicate
    {
        public IGraph Graph {get;}
        public INode Target { get; }
        public INode CurrentNode { get;}
        public Int64 CurrentChildNumber { get; }
        public Int64 CurrentDistance { get; }

        public Predicate(IGraph graph, 
            INode nodeTarget, 
            INode currentNode, 
            Int64 currentChildNumber, 
            Int64 currentDistance)
        {
            this.Graph = graph;
            this.Target = nodeTarget;
            this.CurrentNode = currentNode;
            this.CurrentChildNumber = currentChildNumber;
            this.CurrentDistance = currentDistance;
        }
    }
}