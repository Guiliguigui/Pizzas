using Pizzas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizzas.Services
{
    public interface IPizzaService
    {
        Task EditPizzaAsync(Pizza pizza);
        Task<List<Pizza>> GetPizzasAsync();
    }
}