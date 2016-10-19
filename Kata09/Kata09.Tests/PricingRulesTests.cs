using System.Linq;
using NUnit.Framework;

namespace Kata09.Tests
{
    [TestFixture]
    public class PricingRulesTests
    {
        [Test]
        public void multibuy_when_minimum_in_basket_changes_price()
        {
            const int OFFER_PRICE = 130;

            var rule = new MultibuyRule("A", 3, OFFER_PRICE);

            var basket = new Basket();
            basket.Add("A");
            basket.Add("A");

            CollectionAssert.IsEmpty( rule.ApplyRule(basket) );

            basket.Add("A");

            Assert.AreEqual(OFFER_PRICE, rule.ApplyRule(basket).Single());

            CollectionAssert.IsEmpty(rule.ApplyRule(basket));
        }

        [Test]
        public void null_rule_returns_unit_price()
        {
            const int UNIT_PRICE = 50;

            var rule = new NullRule("A", UNIT_PRICE);

            var basket = new Basket();

            CollectionAssert.IsEmpty( rule.ApplyRule(basket));

            basket.Add("A");

            Assert.AreEqual( UNIT_PRICE, rule.ApplyRule(basket).Single());

            CollectionAssert.IsEmpty(rule.ApplyRule(basket));
        }
    }
}