using System.Collections.Generic;

namespace Kata09
{
    public interface IPricingRule
    {
        IEnumerable<int> ApplyRule(Basket basket);
    }
}