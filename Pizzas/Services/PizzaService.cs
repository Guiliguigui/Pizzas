using Pizzas.Data;
using Pizzas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizzas.Services
{
    public class PizzaService : IPizzaService
    {
        private List<Pizza> Pizzas { get; set; }
        public PizzaService()
        {
            Pizzas = InitialPizzas.Pizzas;
        }
        public async Task<List<Pizza>> GetPizzasAsync()
        {
            return Pizzas;
        }
        public async Task EditPizzaAsync(Pizza pizza)
        {
            var nextPizza = Pizzas.Find(previousPizza => pizza.Id == pizza.Id);
            nextPizza.Name = pizza.Name;
            nextPizza.Price = pizza.Price;
            nextPizza.Ingredients = pizza.Ingredients;
        }

    }
}
