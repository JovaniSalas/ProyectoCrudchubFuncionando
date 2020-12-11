using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProducts.Models
{

    public class Product : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CategoryType { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult(
                   "El nombre del producto es requerido.");
            }
            if (string.IsNullOrEmpty(Description))
            {
                yield return new ValidationResult(
                   "La descripción del producto es requerida.");
            }

            if (string.IsNullOrEmpty(CategoryType))
            {
                yield return new ValidationResult(
                   "La categoria es requerida.");
            }
            else
            {
                List<string> listTypesCategories = new List<string>() { "Comida", "Servicio", "Salud", "Basico" };
                if (!listTypesCategories.Any(c => c == CategoryType))
                {
                    var _typesCategories = string.Join(", ", listTypesCategories);
                    yield return new ValidationResult(
                                       "La categoria es incorrecta. Catregorias correctas:" + _typesCategories);
                }
            }

            if (Price < 1)
            {
                yield return new ValidationResult(
                   "El precio del producto es requerido.");
            }

            if (Quantity < 1)
            {
                yield return new ValidationResult(
                   "La cantidad del producto es requerida.");
            }
        }
    }
}
