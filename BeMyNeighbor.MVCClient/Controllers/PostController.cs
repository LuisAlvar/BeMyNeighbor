using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BeMyNeighbor.Domain.Models.DbModels;

namespace BeMyNeighbor.MVCClient.Controllers{
  public class PostController: Controller{
    public IActionResult Index(){
      return View();
    }

    [HttpGet]
    public IActionResult Create(){
      return View(new CreatePostViewModel());
    }

    [HttpPost]
    public IActionResult Create(CreatePostViewModel model){
      PostDbManager.CreatePost(model);
      return RedirectToAction("Index", "Post");
    }

    public IActionResult CommunityPosts(){
      ViewBag.listOfPosts = PostDbManager.FetchPostsByCommunityId(2);
      return View();
    }

    public IActionResult SelectedPost(int postId){
      PostDbManager.SelectedPost(postId);
      return View();
    }

  }
}