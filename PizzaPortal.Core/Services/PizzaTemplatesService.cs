using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaPortal.Contract.PizzaTemplatesDto;
using PizzaPortal.Core.Services.Mappers;
using PizzaPortal.Infrastructure;
using PizzaPortal.Infrastructure.Repository;

namespace PizzaPortal.Core.Services
{
    public interface IPizzaTemplatesService : IService<PizzaTemplatesDto>
    {
        
    }
    public class PizzaTemplatesService : IPizzaTemplatesService

    {
       

        public async Task<IEnumerable<PizzaTemplatesDto>> GetAll()
        {
            var pizzasTemplates = await _iPizzaRepository.GetAll();
            return pizzasTemplates.Select(x => new PizzaTemplatesDto()
            {
                PizzaTemplate = x.PizzaTemplate,
                Ingredients = x.Ingredients,
                Images = x.Images,
            }).ToList();

        }

        /*private async Task<IEnumerable<PizzaTemplatesDto>> PizzaTemplatesDtoMapper()
        {
            var pizzasTemplates = await _iPizzaRepository.GetAll();
            return pizzasTemplates.Select(x => new PizzaTemplatesDto()
                {
                    PizzaTemplate = x.PizzaTemplate,
                    Ingredients = x.Ingredients,
                    Images = x.Images,
                })
                .ToList();
        }*/

        public async Task<PizzaTemplatesDto> GetById(long id)
        {
            var pizza = await _iPizzaRepository.GetById(id);
            return PizzaTemplatesMapper.MapDtoToPizzaTemplates(pizza);
        }

        public async Task Add(PizzaTemplatesDto pizza)
        {
            await _iPizzaRepository.Add(PizzaTemplatesMapper.MapPizzaTemplatesToDo(pizza));
        }

        public async Task Update(PizzaTemplatesDto entity)
        {
            await _iPizzaRepository.Update(PizzaTemplatesMapper.MapPizzaTemplatesToDo(entity));
        }

        public async Task Delete(long id)
        {
            await _iPizzaRepository.Delete(id);
        }

        private readonly IPizzaRepository _iPizzaRepository;
        
        public PizzaTemplatesService(IPizzaRepository iPizzaRepository)
        {
            _iPizzaRepository = iPizzaRepository;
        }
    }
} 