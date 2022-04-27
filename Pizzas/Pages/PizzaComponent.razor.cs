using Microsoft.AspNetCore.Components;
using Pizzas.Models;
using Pizzas.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pizzas.Pages
{
    public class PizzaBase : ComponentBase
    {
        [Inject]
        protected IPizzaService PizzaService { get; set; }
        protected bool IsAdminMode { get; set; } = false;
        protected Dictionary<Pizza, int> Cart { get; set; } = new Dictionary<Pizza, int>();
        protected decimal Total => Cart.Sum(pizza => pizza.Key.Price * pizza.Value);
        protected List<Pizza> PizzaList { get; set; }
        protected PizzaEditDTO PizzaToEdit { get; set; } = null;
        protected override async void OnInitialized()
        {
            base.OnInitialized();
            PizzaList = await PizzaService.GetPizzasAsync();
        }

        protected void AddToCart(Pizza pizza)
        {
            if (Cart.ContainsKey(pizza))
                Cart[pizza]++;
            else
                Cart.Add(pizza, 1);
        }
        protected void RemoveFromCart(Pizza pizza)
        {
            if (Cart[pizza] == 1)
                Cart.Remove(pizza);
            else
                Cart[pizza]--;
        }
        protected void EmptyCart()
        {
            Cart.Clear();
        }

        protected void EditPizza(Pizza pizza)
        {
            PizzaToEdit = new PizzaEditDTO()
            {
                Id = pizza.Id,
                IngredientsString = string.Join(", ", pizza.Ingredients),
                Name = pizza.Name,
                Price = pizza.Price,
            };
        }
        protected void SubmitPizza()
        {
            var pizza = PizzaList.Find(pizza => pizza.Id == PizzaToEdit.Id);
            pizza.Name = PizzaToEdit.Name;
            pizza.Price = PizzaToEdit.Price;
            pizza.Ingredients = PizzaToEdit.IngredientsString.Split(", ").Select(ingredient => ingredient.Trim()).ToArray();
            PizzaToEdit = null;
            PizzaService.EditPizzaAsync(pizza);
        }
    }
}
