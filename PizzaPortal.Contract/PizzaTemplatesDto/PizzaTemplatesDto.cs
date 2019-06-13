using System.Collections.Generic;
using System.Globalization;
using PizzaPortal.Infrastructure;

namespace PizzaPortal.Contract.PizzaTemplatesDto
{

    public class PizzaTemplatesDto
    {
        public string PizzaTemplate { get; set; }
        
        public List<Ingredient> Ingredients { get; set; }
        
        public IEnumerable<Image> Images { get; set; }
        
        public long? Id { get; set; }
       
    }
}