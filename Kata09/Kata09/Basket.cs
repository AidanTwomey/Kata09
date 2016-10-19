using System.Collections.Generic;
using System.Linq;

namespace Kata09
{
    public class Basket
    {
        private readonly IDictionary<StockPricingUnit, int> units;

        public Basket()
            :this(new List<StockPricingUnit>())
        {
        }

        public Basket(IEnumerable<StockPricingUnit> units)
        {
            this.units = units
                .GroupBy(u => u)
                .ToDictionary(group => group.Key, group => group.Count());
        }

        public void Add(StockPricingUnit unit)
        {
            if (!units.ContainsKey(unit))
            {
                units.Add( unit, 0);
            }

            units[unit]++;
        }

        public void Remove(StockPricingUnit unit, int count = 1)
        {
            if (units.ContainsKey(unit))
            {
                units[unit] -= count;
            }
        }

        public IEnumerable<int> GetUnitLevels(IEnumerable<StockPricingUnit> units)
        {
            return units.Select(u => this.units.ContainsKey(u) ? this.units[u] : 0);
        }

        public int CalculateTotal(IEnumerable<IPricingRule> rules)
        {
            var clonedBasket = new Basket(units.Keys.SelectMany(k => Enumerable.Repeat(k, units[k])));
            return rules.SelectMany(r => r.ApplyRule(clonedBasket)).Sum();
        }
    }
}