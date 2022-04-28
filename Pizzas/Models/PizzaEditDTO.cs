using System.ComponentModel.DataAnnotations;

namespace Pizzas.Models
{
    public class PizzaEditDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Le Nom est requis.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "La liste des ingrédients est requise.")]
        [RegularExpression(@"^[a-zA-z0-9\s\-]+(\,[a-zA-z0-9\s\-]+)*$", ErrorMessage = "La liste des ingrédients doit etre séparée par des espaces.")]
        public string IngredientsString { get; set; }
        [Range(1, 99, ErrorMessage = "Le prix doit être compris entre 1 et 99 €.")]
        public int Price { get; set; }
    }
}
