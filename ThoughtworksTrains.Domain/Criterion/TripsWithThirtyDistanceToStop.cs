using ThoughtworksTrains.Domain.Interfaces;
using ThoughtworksTrains.Domain.Enum;

namespace ThoughtworksTrains.Domain.Criterion
{
    public class TripsWithThirtyDistanceToStop : ICriterion<IPredicate>
    {
        public EnumStatusCriterion Accord(IPredicate value)
        {
            if (value.CurrentDistance < 30 && value.CurrentNode.Equals(value.Target))
                return EnumStatusCriterion.YES;
            else if (value.CurrentDistance< 30)
                return EnumStatusCriterion.BYPASS;
            else
                return EnumStatusCriterion.NO;
        }
    }
}