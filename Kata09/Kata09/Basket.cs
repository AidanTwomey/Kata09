using System.Collections.Generic;
using System.Linq;

namespace Kata09
{
    public class Basket
    {
        private readonly IDictionary<StockPricingUnit, int> unitsInBasket;

        public Basket()
            :this(new List<StockPricingUnit>())
        {
        }

        public Basket(IEnumerable<StockPricingUnit> units)
        {
            unitsInBasket = units
                .GroupBy(u => u)
                .ToDictionary(group => group.Key, group => group.Count());
        }

        public void Add(StockPricingUnit unit)
        {
            if (!unitsInBasket.ContainsKey(unit))
            {
                unitsInBasket.Add(unit, 0);
            }

            unitsInBasket[unit]++;
        }

        public void Remove(StockPricingUnit unit, int count = 1)
        {
            if (unitsInBasket.ContainsKey(unit))
            {
                unitsInBasket[unit] -= count;
            }
        }

        public IEnumerable<int> GetUnitLevels(IEnumerable<StockPricingUnit> units)
        {
            return units.Select(u => unitsInBasket.ContainsKey(u) ? unitsInBasket[u] : 0);
        }

        public int CalculateTotal(IEnumerable<IPricingRule> rules)
        {
            // work with a cloned basket to avoid side effects
            var clonedBasket = new Basket(unitsInBasket.Keys.SelectMany(k => Enumerable.Repeat(k, unitsInBasket[k])));

            return rules
                .SelectMany(r => r.ApplyRule(clonedBasket))
                .Sum();
        }
    }
}