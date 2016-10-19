using System.Collections.Generic;

namespace Kata09
{
    public class RulesEngine
    {
        public IEnumerable<IPricingRule> GetRules()
        {
            return new List<IPricingRule>()
            {
                new MultibuyRule("A", 3, 130),
                new MultibuyRule("B", 2, 45),
                new NullRule("A", 50),
                new NullRule("B", 30),
                new NullRule("C", 20),
                new NullRule("D", 15)
            };
        }
    }
}