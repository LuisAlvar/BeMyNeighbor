using Microsoft.AspNetCore.Mvc;
using BeMyNeighbor.Domain.Models;
using BeMyNeighbor.Domain.Models.DbModels;

namespace BeMyNeighbor.MVCClient.Controllers{
  public class AuthController: Controller{
    [HttpGet]
    public ViewResult SignIn(){
      return View(CurrentUser.Storage());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SignIn(LocalUser user){
      if(!UserDbManager.GetInstance().SignIn(user)){
          ViewData["Msg"] = CurrentUser.Storage().Messages.MessageToUser;
          return View("../Home/Index");
      }
      return RedirectToAction("Index", "Main");
    }
  }
}