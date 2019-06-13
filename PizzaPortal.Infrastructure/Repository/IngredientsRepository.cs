using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaPortal.Infrastructure.Context;

namespace PizzaPortal.Infrastructure.Repository
{
    public class IngredientsRepository : IingredientsRepository
    {
        public async Task<IEnumerable<Ingredient>> GetAll()
        {
            var pizzaTemplates = await _pizzaPortalContext.Ingredients.ToListAsync();
            pizzaTemplates.ForEach(x => { _pizzaPortalContext.Entry(x).Reference(y => y.PizzaTemplates).LoadAsync();});
            return pizzaTemplates;
        }

        public async Task<Ingredient> GetById(long id)
        {
            var ingredientsName = await _pizzaPortalContext.Ingredients
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
            await _pizzaPortalContext.Entry(ingredientsName).Reference(x => x.IngredientName).LoadAsync();
            var ingredientsPrice = await _pizzaPortalContext.Ingredients
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
            await _pizzaPortalContext.Entry(ingredientsPrice).Reference(x => x.IngredientPrice).LoadAsync();
            var pizzaTemplates = await _pizzaPortalContext.Ingredients
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
            await _pizzaPortalContext.Entry(pizzaTemplates).Reference(x => x.PizzaTemplates).LoadAsync();
            return ingredientsName;

        }

        public async Task Add(Ingredient pizza)
        {
            pizza.DateOfCreation = DateTime.Now;
            await _pizzaPortalContext.Ingredients
                .Include(z => z.PizzaTemplates)
                .FirstAsync();
            await _pizzaPortalContext.Ingredients.AddAsync(pizza);
            await _pizzaPortalContext.SaveChangesAsync();
        }

        public async Task Update(Ingredient entity)
        {
            var ingredientToUpdate = await _pizzaPortalContext.Ingredients
                .Include(x => x.PizzaTemplates)
                .SingleOrDefaultAsync(x => x.Id == entity.Id);
            if (ingredientToUpdate != null)
            {
                ingredientToUpdate.IngredientName = entity.IngredientName;
                ingredientToUpdate.PizzaTemplates = entity.PizzaTemplates;
                ingredientToUpdate.IngredientPrice = entity.IngredientPrice;
                ingredientToUpdate.DateOfUpdate = DateTime.Now;
            }
        }
      
        public async Task Delete(long id)
        {
            var ingredientsToDelete = await _pizzaPortalContext.Ingredients.SingleOrDefaultAsync(pizza => pizza.Id == id);
            if (ingredientsToDelete != null)
            {
                _pizzaPortalContext.Ingredients.Remove(ingredientsToDelete);
                await _pizzaPortalContext.SaveChangesAsync();
            }
        }
        private readonly PizzaPortalContext _pizzaPortalContext;
        public IngredientsRepository(PizzaPortalContext pizzaPortalContext)
        {
            _pizzaPortalContext = pizzaPortalContext;
        }
     }
}