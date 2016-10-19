using System.Collections.Generic;
using System.Linq;

namespace Kata09
{
    public class NullRule : IPricingRule
    {
        private readonly StockPricingUnit unit;
        private readonly int unitPrice;

        public NullRule(StockPricingUnit unit, int unitPrice)
        {
            this.unit = unit;
            this.unitPrice = unitPrice;
        }

        public IEnumerable<int> ApplyRule(Basket basket)
        {
            var count = basket.GetUnitLevels(new[] {unit}).Single();

            basket.Remove( unit, count);

            return Enumerable.Repeat(unitPrice, count);
        }

        #region equality

        protected bool Equals(NullRule other)
        {
            return unit.Equals(other.unit) && unitPrice == other.unitPrice;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NullRule) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (unit.GetHashCode()*397) ^ unitPrice;
            }
        }


        #endregion
    }
}