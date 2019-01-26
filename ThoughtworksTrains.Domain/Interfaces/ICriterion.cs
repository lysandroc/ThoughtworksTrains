using System;
using  ThoughtworksTrains.Domain.Enum;

namespace ThoughtworksTrains.Domain.Interfaces
{
    public interface ICriterion<T>
    {
        EnumStatusCriterion Accord(T value);
    }
}