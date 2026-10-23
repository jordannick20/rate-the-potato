using Microsoft.AspNetCore.Mvc;
using Boilerplate.Models;

namespace Boilerplate.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        var model = new ReviewModel();
        model.GetReviews();
        return View(model);
    }

    [HttpGet]
    public IActionResult GetReview(Review review)
    {
        if (ModelState.IsValid)
        {
            var model = new ReviewModel();
            model.AddReview(review);
            return RedirectToAction("Index");
        }

        return View(review);
    }
    [HttpPost]
    public IActionResult AddReview(Review review)
    {
        if (ModelState.IsValid)
        {
            var model = new ReviewModel();
            model.AddReview(review);
            return RedirectToAction("Index");
        }

        return View(review);
    }

}
