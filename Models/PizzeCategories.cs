using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_crud_mvc.Models
{
    public class PizzeCategories
    {
        public Pizza Pizza { get; set; }

        public List<Category> Categories { get; set; }
        public List<Ingredienti> Ingredients { get; set; }
        public List<int> SelectedIngredienti { get; set; }

        public PizzeCategories()
        {
            Pizza = new Pizza();
            Categories = new List<Category>();
            Ingredients = new List<Ingredienti>();
            SelectedIngredienti = new List<int>();
        }
    }
}
