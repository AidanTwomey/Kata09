using NUnit.Framework;

namespace Kata09.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        [TestCase(0, "")]
        [TestCase(50, "A")]
        [TestCase(80, "AB")]
        [TestCase(115, "CDBA")]
        [TestCase(100, "AA")]
        [TestCase(130, "AAA")]
        [TestCase(180, "AAAA")]
        [TestCase(230, "AAAAA")]
        [TestCase(260, "AAAAAA")]
        [TestCase(160, "AAAB")]
        [TestCase(175, "AAABB")]
        [TestCase(190, "AAABBD")]
        [TestCase(190, "DABABA")]

        [Test]
        public void checkout_value_calculated_correctly_at_end(int expected, string basket)
        {
            var checkout = new Checkout(new RulesEngine().GetRules());
      

            foreach (char unit in basket)
            {
                checkout.Scan(unit.ToString());
            }

            Assert.AreEqual(expected, checkout.Total);
        }

        [Test]
        public void incremental_total_calculated_correctly_when_new_items_scanned()
        {
            var co = new Checkout(new RulesEngine().GetRules());

            Assert.AreEqual(0, co.Total);

            co.Scan("A");
            Assert.AreEqual(50, co.Total);

            co.Scan("B");
            Assert.AreEqual(80, co.Total);

            co.Scan("A");
            Assert.AreEqual(130, co.Total);

            co.Scan("A");
            Assert.AreEqual(160, co.Total);

            co.Scan("B");
            Assert.AreEqual(175, co.Total);
        }
        
    }
}