using Microsoft.AspNetCore.Mvc;
using Boilerplate.Models;

namespace Boilerplate.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    /*     public IActionResult Test(MyModel myModel)
        {
            myModel.GetTests();
            return View(myModel);
        } */

    [HttpPost]
    public IActionResult Create(Create review)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Index");
        }

        return View(review);
    }

}
