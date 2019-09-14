using Microsoft.AspNetCore.Mvc;
using BeMyNeighbor.Domain.Models;
using BeMyNeighbor.Domain.Models.DbModels;
using BeMyNeighbor.Data.Entities;

namespace BeMyNeighbor.MVCClient.Controllers{
  public class AuthController: Controller{
    [HttpGet]
    public ViewResult SignIn(){
      //clean good or bad messaages
      if(CurrentUser.Storage().Messages.DestinationType != "/Auth/SignIn"){
        CurrentUser.Storage().CleanMessages();
      }
      return View(CurrentUser.Storage());
    }

    [HttpGet]
    public ViewResult SignUp(){
      if(CurrentUser.Storage().Messages.DestinationType != "/Auth/SignUp"){
        CurrentUser.Storage().CleanMessages();
      }
      return View(CurrentUser.Storage());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public RedirectToActionResult SignUp(LocalUser newUser){
      if(UserDbManager.GetInstance().SignUp(newUser)){
        //sign up successfuly 
        return RedirectToAction("SignIn", "Auth");
      }
      //sign up failed
      return RedirectToAction("SignUp","Auth");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public RedirectToActionResult SignIn(LocalUser user){
      if(!UserDbManager.GetInstance().SignIn(user)){
          return RedirectToAction("SignIn", "Auth");
      }
      var curr = CurrentUser.Storage();
      return RedirectToAction("Index", "Main");
    }

    public RedirectToActionResult Logout(){
      CurrentUser.DeleteStorage();
      return RedirectToAction("Index", "Home");
    }
  }
}