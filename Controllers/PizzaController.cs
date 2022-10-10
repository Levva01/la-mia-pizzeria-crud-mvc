using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Data.SqlClient.Server;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_post.Controllers
{
    public class PizzaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Pizza> pizze = new();
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                pizze = context.Pizze.Include("Category").Include("Ingredients").ToList();
            }
            return View("Index", pizze);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PizzeCategories pizzeCategories = new PizzeCategories();
            ApplicationDbContext context = new ApplicationDbContext();
            pizzeCategories.Categories = context.Categories.ToList();
            pizzeCategories.Ingredients = context.Ingredients.ToList();
            return View(pizzeCategories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzeCategories formPizza)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            if (!ModelState.IsValid)
            {
                formPizza.Categories = context.Categories.ToList();
                formPizza.Ingredients = context.Ingredients.ToList();
                return View("Create", formPizza);
            }

            context.Pizze.Add(formPizza.Pizza);

            formPizza.Pizza.Ingredients = context.Ingredients.Where(Ingredients => formPizza.SelectedIngredienti.Contains(Ingredients.Id)).ToList<Ingredienti>();
            context.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Pizza pizzaEdit = context.Pizze.Include("Category").Include("Ingredients").Where(pizza => pizza.Id == id).FirstOrDefault();
                if (pizzaEdit is null)
                {
                    return View("Error");
                }

                PizzeCategories pizzeCategories = new PizzeCategories();

                pizzeCategories.Pizza = pizzaEdit;
                pizzeCategories.Categories = context.Categories.ToList();
                pizzeCategories.Ingredients = context.Ingredients.ToList();
                return View(pizzeCategories);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzeCategories formPizza)
        {

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                if (!ModelState.IsValid)
                {
                    formPizza.Categories = context.Categories.ToList();
                    formPizza.Ingredients = context.Ingredients.ToList();
                    return View("Update", formPizza);
                }
                Pizza pizza = context.Pizze.Where(pizza => pizza.Id == id).Include("Ingredients").FirstOrDefault();

                pizza.Nome = formPizza.Pizza.Nome;
                pizza.Descrizione = formPizza.Pizza.Descrizione;
                pizza.CategoryId = formPizza.Pizza.CategoryId;
                pizza.Ingredients = context.Ingredients.Where(ingredienti => formPizza.SelectedIngredienti.Contains(ingredienti.Id)).ToList<Ingredienti>();
                context.Pizze.Add(formPizza.Pizza);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            ApplicationDbContext pizzaContext = new ApplicationDbContext();
            Pizza pizza = pizzaContext.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();

            if (pizza == null)
            {
                return NotFound("Non trovato");
            }
            pizzaContext.Pizze.Remove(pizza);
            pizzaContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}