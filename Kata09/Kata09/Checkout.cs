using System.Collections.Generic;

namespace Kata09
{
    public class Checkout
    {
        private readonly IEnumerable<IPricingRule> rules;
        private readonly Basket basket;

        public Checkout(IEnumerable<IPricingRule> rules)
        {
            this.rules = rules;
            basket = new Basket();
        }

        public void Scan(StockPricingUnit unit)
        {
            basket.Add(unit);
        }

        public int Total => basket.CalculateTotal( rules );
    }
}