namespace PizzaPortal.Infrastructure
{
    public class Ingredient : Entity
    {
        public string IngredientName { get; set; }
        public string IngredientPrice { get; set; }
        public PizzaTemplates PizzaTemplates { get; set; }
    }
}