using System.ComponentModel.DataAnnotations;

namespace Pizzas.Models
{
    public class Pizza
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Le Nom est requis.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "La liste des ingrédients est requise.")]
        public string[] Ingredients { get; set; }
        [Range(1, 99, ErrorMessage = "Le prix doit être compris entre 1 et 99 €.")]
        public int Price { get; set; }
        [Required]
        public string ImageName { get; set; }
    }
}
