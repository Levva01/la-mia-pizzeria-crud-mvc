namespace la_mia_pizzeria_crud_mvc.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Pizza> Pizze { get; set; }

        public Category()
        {

        }
    }
}
