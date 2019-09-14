using Microsoft.AspNetCore.Mvc;
using BeMyNeighbor.Domain.Models;

namespace BeMyNeighbor.MVCClient.Controllers{
  public class MainController: Controller{
    public IActionResult Index(){
      //Here is here we want to load community and post infomration 
      if(CurrentUser.Storage().UserDb.Username == null){
        return RedirectToAction("Index", "Home");
      }
      return View(CurrentUser.Storage());
    }

    [HttpPost]
    public void SelectedCommunity(LocalUser info){
      //here is where we are going to verify the user 
      var infosd = info;  
    }

  }
}