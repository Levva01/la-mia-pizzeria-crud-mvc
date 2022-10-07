using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Data.SqlClient.Server;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_post.Controllers
{
    public class PizzaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Pizza> pizze = new();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                pizze = db.Pizze.ToList();
            }
            return View(pizze);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PizzeCategories pizzeCategories = new PizzeCategories();
            pizzeCategories.Categories = new ApplicationDbContext().Categories.ToList();
            return View(pizzeCategories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzeCategories formPizza)
        {
            /*
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Pizza pizzaCreate = new Pizza();
                pizzaCreate.Nome = formPizza.Nome;
                pizzaCreate.Descrizione = formPizza.Descrizione;
                pizzaCreate.Foto = formPizza.Foto;
                pizzaCreate.Prezzo = formPizza.Prezzo;
                context.Pizze.Add(pizzaCreate);
                context.SaveChanges();
                return RedirectToAction("Pizza");
            } */

            ApplicationDbContext context = new ApplicationDbContext();
            if (!ModelState.IsValid)
            {
                formPizza.Categories = context.Categories.ToList();
                return View("Create", formPizza);
            }

            context.Pizze.Add(formPizza.Pizza);


            context.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Pizza pizzaEdit = context.Pizze.Where(post => post.Id == id).FirstOrDefault();
                if (pizzaEdit is null)
                {
                    return View("Error");
                }

                PizzeCategories pizzeCategories = new PizzeCategories();

                pizzeCategories.Pizza = pizzaEdit;
                pizzeCategories.Categories = context.Categories.ToList();
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
                    return View("Update", formPizza);
                }
                formPizza.Pizza.Id = id;
                context.Pizze.Update(formPizza.Pizza);
                /*
                Pizza pizza = pizzaContext.Pizze.Where(pizzaContext => pizzaContext.Id == id).FirstOrDefault();

                pizza.Nome = formPizza.Nome;
                pizza.Descrizione = formPizza.Descrizione;
                pizza.Prezzo = formPizza.Prezzo;
                pizza.Foto = formPizza.Foto;
                */
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