using ThoughtworksTrains.Domain.Interfaces;
using ThoughtworksTrains.Domain.Enum;

namespace ThoughtworksTrains.Domain.Criterion
{
    public class ThirtyDistanceToStop : ICriterion<IPredicate>
    {
        public EnumStatusCriterion Accord(IPredicate value)
        {
            if (value.CurrentChildNumber < 30 && value.CurrentNode.Equals(value.Target))
                return EnumStatusCriterion.YES;
            else if (value.CurrentChildNumber< 30)
                return EnumStatusCriterion.BYPASS;
            else
                return EnumStatusCriterion.NO;
        }
    }
}