using System.Collections.Generic;
using PizzaPortal.Contract.PizzaTemplatesDto;
using PizzaPortal.Infrastructure;

namespace PizzaPortal.Core.Services.Mappers
{
    internal static class PizzaTemplatesMapper
    {
        public static PizzaTemplatesDto MapDtoToPizzaTemplates(PizzaTemplates pizza)
        {
            return new PizzaTemplatesDto()
            {
                PizzaTemplate = pizza.PizzaTemplate,
                Ingredients = pizza.Ingredients,
                Images = pizza.Images,
                Id = pizza.Id,
              
               
             };
        }

        public static PizzaTemplates MapPizzaTemplatesToDo(PizzaTemplatesDto pizza)
        {
            return new PizzaTemplates()
            {
                PizzaTemplate = pizza.PizzaTemplate,
                Ingredients = new List<Ingredient>(),
                Images = pizza.Images,
                Id = pizza.Id.GetValueOrDefault(),
            };

        }
    }
}