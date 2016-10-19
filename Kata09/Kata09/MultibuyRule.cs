using System.Collections.Generic;
using System.Linq;

namespace Kata09
{
    public class MultibuyRule : IPricingRule
    {
        private readonly StockPricingUnit unitUnderOffer;
        private readonly int requiredUnits;
        private readonly int offerPrice;

        public MultibuyRule(StockPricingUnit unitUnderOffer, int requiredUnits, int offerPrice)
        {
            this.unitUnderOffer = unitUnderOffer;
            this.requiredUnits = requiredUnits;
            this.offerPrice = offerPrice;
        }

        public IEnumerable<int> ApplyRule(Basket basket)
        {
            while (basket.GetUnitLevels(new[] {unitUnderOffer}).Single() >= requiredUnits)
            {
                basket.Remove( unitUnderOffer, requiredUnits );
                yield return offerPrice;
            }
        }

        #region equality

        protected bool Equals(MultibuyRule other)
        {
            return unitUnderOffer.Equals(other.unitUnderOffer) && requiredUnits == other.requiredUnits && offerPrice == other.offerPrice;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MultibuyRule) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = unitUnderOffer.GetHashCode();
                hashCode = (hashCode*397) ^ requiredUnits;
                hashCode = (hashCode*397) ^ offerPrice;
                return hashCode;
            }
        }

        #endregion
    }
}