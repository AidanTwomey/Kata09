namespace Kata09
{
    public struct StockPricingUnit
    {
        public string Name { get; private set; }

        public StockPricingUnit(string name)
        {
            Name = name;
        }

        public static implicit operator string(StockPricingUnit unit)
        {
            return unit.Name;
        }

        public static implicit operator StockPricingUnit(string name)
        {
            return new StockPricingUnit(name);
        }
    }
}