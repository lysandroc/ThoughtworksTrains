using ThoughtworksTrains.Domain.Interfaces;
using ThoughtworksTrains.Domain.Enum;

namespace ThoughtworksTrains.Domain.Criterion
{
    public class TripsWithExactlyFourStops : ICriterion<IPredicate>
    {
        public EnumStatusCriterion Accord(IPredicate value)
        {
            if (value.CurrentChildNumber == 4 && value.CurrentNode.Equals(value.Target))
                return EnumStatusCriterion.YES;
            else if (value.CurrentChildNumber < 4)
                return EnumStatusCriterion.BYPASS;
            else
                return EnumStatusCriterion.NO;
        }
    }
}