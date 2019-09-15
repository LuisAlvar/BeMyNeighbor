using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BeMyNeighbor.Domain.Models;
using BeMyNeighbor.Domain.Models.DbModels;
using BeMyNeighbor.Domain.Models.ViewModels;

namespace BeMyNeighbor.MVCClient.Controllers{
  public class PostController: Controller{
    public IActionResult Index(){
      return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Create(){
    
      return View(new CreatePostViewModel());
    }

    [HttpPost]
    public IActionResult Create(CreatePostViewModel model){
      PostDbManager.CreatePost(model);
      return RedirectToAction("Index", "Main");
    }

    public IActionResult CommunityPosts(){
      ViewBag.listOfPosts = PostDbManager.FetchPostsByCommunityId(CurrentUser.Storage().UserDb.CommunityId);
      
      return View();
    }

    public IActionResult SelectedPost(int postId){
      PostDbManager.SelectedPost(postId);
      return View();
    }

  }
}