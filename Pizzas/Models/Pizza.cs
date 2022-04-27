using System.ComponentModel.DataAnnotations;

namespace Pizzas.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Ingredients { get; set; }
        public int Price { get; set; }
        public string ImageName { get; set; }
    }
}
