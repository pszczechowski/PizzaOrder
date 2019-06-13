using System.Collections.Generic;

namespace PizzaPortal.Infrastructure
{
    public class PizzaTemplates : Entity
    {
        public string PizzaTemplate { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}