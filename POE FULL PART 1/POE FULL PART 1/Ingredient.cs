namespace POE_FULL_PART_1
{
    internal class Ingredient
    {
        public Ingredient(string name, double quantity, string unit)
        {
            Quantity = quantity;
        }

        public object Quantity { get; internal set; }
        public object Unit { get; internal set; }
        public object Name { get; internal set; }
    }
}