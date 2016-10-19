using System.Collections.Generic;
using NUnit.Framework;

namespace Kata09.Tests
{
    [TestFixture]
    public class RulesEngineTests
    {
        [Test]
        public void return_rules_with_multibuy_before_all_null_rules()
        {
            var expected = new List<IPricingRule>()
            {
                new MultibuyRule("A", 3, 130),
                new MultibuyRule("B", 2, 45),
                new NullRule("A", 50),
                new NullRule("B", 30),
                new NullRule("C", 20),
                new NullRule("D", 15)
            };

            CollectionAssert.AreEqual(expected, new RulesEngine().GetRules());
        }
    }
}