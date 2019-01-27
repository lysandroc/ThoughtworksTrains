using System;
using System.Linq;
using System.Collections.Generic;
using ThoughtworksTrains.Domain.Enum;
using ThoughtworksTrains.Domain.Interfaces;
using ThoughtworksTrains.Domain.Predicates;

namespace ThoughtworksTrains.Business.Calculate
{
    public class CalculateNumberPathsWithCriterion :ICalculateNumberPathsWithCriterion
    {
        private Int64 _numberPath;
        public Int64 NumberPathsWithCriterion(IGraph graph, INode from, INode to, ICriterion<IPredicate> criterion)
        {
            this._numberPath = 0;
            this.NumberPaths(new Predicate(graph, to, from,  0, 0), criterion);
            return _numberPath;
        }
        private void NumberPaths(Predicate predicate, ICriterion<IPredicate> criterion)
        {
            foreach (var item in predicate.Graph.GetPaths(predicate.CurrentNode))
            {

                if(!predicate.Graph.NodeHasRelationship(item.Source, item.Target))
                    break;

                var predicateNew = new Predicate(
                            predicate.Graph, 
                            predicate.Target, 
                            item.Target, 
                            predicate.CurrentChildNumber + 1, 
                            predicate.CurrentDistance + item.Distance);

                switch (criterion.Accord(predicateNew))
                {
                    case EnumStatusCriterion.YES:
                        this._numberPath +=1;
                        this.NumberPaths(predicateNew, criterion);
                        break;
                    case EnumStatusCriterion.BYPASS:
                        this.NumberPaths(predicateNew, criterion);
                        break;
                    default:
                        break;
                }
            }   
        }
    }
}