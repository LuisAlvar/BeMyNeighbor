using Microsoft.AspNetCore.Mvc;

namespace BeMyNeighbor.MVCClient.Controllers{
  public class MainController: Controller{
    public ViewResult Index(){
      //Here is here we want to load community and post infomration 
      return View();
    }
  }
}