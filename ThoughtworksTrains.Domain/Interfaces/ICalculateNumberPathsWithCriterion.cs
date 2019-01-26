using System;

namespace ThoughtworksTrains.Domain.Interfaces
{
    public interface ICalculateNumberPathsWithCriterion
    {
        Int64 NumberPathsWithCriterion(IGraph graph, INode from, INode to, ICriterion<IPredicate> criterion);

    }
}