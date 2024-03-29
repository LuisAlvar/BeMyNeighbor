using Microsoft.AspNetCore.Mvc;
using BeMyNeighbor.Domain.Models;
using BeMyNeighbor.Domain.Models.DbModels;

namespace BeMyNeighbor.MVCClient.Controllers{
  public class MainController: Controller{
    public IActionResult Index(){

      /*
        We are routing as such to preserve the unqiue URI
      */
      //Here is here we want to load community and post infomration 
      if(CurrentUser.Storage().UserDb.Username == null){
        return RedirectToAction("Index", "Home");
      }
      if(!CurrentUser.Storage().UserDb.VerifiedUser){
        return RedirectToAction("SelectCommunity", "Main");
        // return View("../Main/_SelectCommunity", CurrentUser.Storage());
      }
      if(CurrentUser.Storage().Messages.DestinationType != "/Main/Index"){
        CurrentUser.Storage().CleanMessages();
      }
      CurrentUser.Storage().Messages.ReduceDuration();
      //reget the post for user 
      //if the user has been verified go to index
      return View(CurrentUser.Storage());
    }

    [HttpGet]
    public ViewResult SelectCommunity(){
      UserDbManager.GetInstance().CommunityListByUserLocation();
      return View(CurrentUser.Storage());
    }

    [HttpPost]
    public RedirectToActionResult SelectedCommunity(LocalUser info){
      //here is where we are going to verify the user 
      UserDbManager.GetInstance().UserSelectedCommunity(info.SelectedCommunity);
      var userCur = CurrentUser.Storage().UserDb;
      // return View("../Main/Index", CurrentUser.Storage());
      return RedirectToAction("Index", "Main");
    }

    [HttpPost]
    public RedirectToActionResult SelectedJob(int selectedPostId){
      PostDbManager.SelectedOtherUsersPost(selectedPostId);
      return RedirectToAction("Index", "Main");
    }

    public ViewResult ViewJobList(){
      return View("JobsList",PostDbManager.FetchPostsLinkedWithUserID(CurrentUser.Storage().UserDb.UserId));
    }

  }
}