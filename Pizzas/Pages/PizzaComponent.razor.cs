using Microsoft.AspNetCore.Components;
using Pizzas.Data;
using Pizzas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Pizzas.Pages
{
    public class PizzaBase : ComponentBase
    {
        protected bool IsAdminMode { get; set; } = false;
        protected Dictionary<Pizza, int> Cart { get; set; } = new Dictionary<Pizza, int>();
        protected decimal Total => Cart.Sum(pizza => pizza.Key.Price * pizza.Value);
        protected List<Pizza> PizzaList { get; set; }
        protected Pizza PizzaToEdit { get; set; } = null;
        protected string PizzaToEditIngredientsString { get; set; } = "";
        protected PizzaBase()
        {
            PizzaList = InitialPizzas.Pizzas;
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
            PizzaToEdit = pizza;
            PizzaToEditIngredientsString = string.Join(", ", PizzaToEdit.Ingredients);
        }
        protected void SubmitPizza()
        {
            PizzaToEdit.Ingredients = PizzaToEditIngredientsString.Split(", ");
            PizzaToEdit = null;

        }
    }
}
