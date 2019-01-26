using System;

namespace ThoughtworksTrains.Domain.Interfaces
{
    public interface ICalculateNumberPathsWithCriterion
    {
        Int64 CalculateNumberPathsWithCriterion(IGraph graph, INode from, INode to, ICriterion<IPredicate> criterion);

    }
}