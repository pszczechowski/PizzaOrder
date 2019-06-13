using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaPortal.Infrastructure.Context;


namespace PizzaPortal.Infrastructure.Repository
{
    public class PizzaRepository : IPizzaRepository
    {
        public async Task<IEnumerable<PizzaTemplates>> GetAll()
        {
            var ingredients = await _pizzaPortalContext.PizzaTemplates.ToListAsync();
            ingredients.ForEach(x => { _pizzaPortalContext.Entry(x).Reference(y => y.Ingredients).LoadAsync(); });
            return ingredients;

        }

        public async Task<PizzaTemplates> GetById(long id)
        {
            var pizzaTemplate = await _pizzaPortalContext.PizzaTemplates
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
            try
            {
                await _pizzaPortalContext.Entry(pizzaTemplate).Reference(x => x.Ingredients).LoadAsync();
            }
            catch (ArgumentException e)
            {
                return null;
            }

            return pizzaTemplate;
        }

        public async Task Add(PizzaTemplates pizza)
        {
           pizza.DateOfCreation = DateTime.Now;
           await _pizzaPortalContext.PizzaTemplates
               .Include(x => x.Ingredients)
               .FirstAsync();
           await _pizzaPortalContext.PizzaTemplates.AddAsync(pizza);
           await _pizzaPortalContext.SaveChangesAsync();

        }

        public async Task Update(PizzaTemplates entity)
        {
            var pizzaToUpdate = await _pizzaPortalContext.PizzaTemplates
                .Include(x => x.Ingredients)
                .SingleOrDefaultAsync(x => x.Id == entity.Id);
            
            if (pizzaToUpdate != null)
            {
                pizzaToUpdate.Ingredients = entity.Ingredients;
                pizzaToUpdate.PizzaTemplate = entity.PizzaTemplate;
                pizzaToUpdate.DateOfUpdate = DateTime.Now;
          

                if (entity.Ingredients != null && pizzaToUpdate.Ingredients != null)
                {
                    var ingredientsToUpdate = pizzaToUpdate.Ingredients.ToList();
                    foreach (var ingredients in ingredientsToUpdate)
                    {
                        foreach (var entityIngredients in entity.Ingredients)
                        {
                            if (ingredients.Id == entityIngredients.Id)
                            {
                                    _pizzaPortalContext.Entry(ingredientsToUpdate).CurrentValues.SetValues(entity.Ingredients);
                            }
                            
                        }
                        
                    }
                    {
                        
                    }
                }

                await _pizzaPortalContext.SaveChangesAsync();
            }
        }

        public async Task Delete(long id)
        {
            var pizzaToDelete = await _pizzaPortalContext.PizzaTemplates.SingleOrDefaultAsync(pizza => pizza.Id == id);
            if (pizzaToDelete != null)
            {
                _pizzaPortalContext.PizzaTemplates.Remove(pizzaToDelete);
                await _pizzaPortalContext.SaveChangesAsync();
            }
        }

        private readonly PizzaPortalContext _pizzaPortalContext;
     public PizzaRepository(PizzaPortalContext pizzaPortalContext)
        {
            _pizzaPortalContext = pizzaPortalContext;
        }
    }
}
    