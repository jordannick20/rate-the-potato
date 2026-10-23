using Microsoft.AspNetCore.Mvc;
using Boilerplate.Models;

namespace Boilerplate.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Review(Review review)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Index");
        }

        return View(review);
    }

}
