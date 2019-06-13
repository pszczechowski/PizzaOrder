using System.ComponentModel.DataAnnotations;

namespace PizzaPortal.Infrastructure
{
    public class Image : Entity
    {
        
        public byte[] Data { get; set; }
        public PizzaTemplates PizzaTemplates { get; set; }
    }
}