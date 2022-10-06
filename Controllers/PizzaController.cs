using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace la_mia_pizzeria_post.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            List<Pizza> pizze = new();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                pizze = db.Pizze.ToList();
            }
            return View(pizze);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza formPizza)
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

            if (!ModelState.IsValid)
            {
                return View("Create", formPizza);
            }

            using (var db = new ApplicationDbContext())
            {
                db.Pizze.Add(formPizza);

                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }
    }



}