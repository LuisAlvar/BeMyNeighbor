using Microsoft.AspNetCore.Mvc;
using BeMyNeighbor.Domain.Models;
namespace BeMyNeighbor.MVCClient.Controllers{
  public class AuthController: Controller{
    [HttpGet]
    public ViewResult SignIn(){
      return View(CurrentUser.Storage());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SignIn(LocalUser user){

      return RedirectToAction("Index", "Main");
    }
  }
}