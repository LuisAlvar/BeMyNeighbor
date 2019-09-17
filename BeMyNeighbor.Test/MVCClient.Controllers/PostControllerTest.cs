using Microsoft.AspNetCore.Mvc;
using Xunit; 
using BeMyNeighbor.MVCClient.Controllers;
using BeMyNeighbor.Domain.Models.ViewModels;

namespace BeMyNeighbor.Test.MVCClient.Controllers{
    public class PostControllerTest{
      private PostController _PostController = new PostController();

      [Fact]
      public void Index_Test(){
        var view = _PostController.Index();
        Assert.NotNull(view);
        Assert.IsType<RedirectToActionResult>(view);
      }

      [Fact]
      public void Create_Test(){
        var view = _PostController.Create();
        Assert.NotNull(view);
        Assert.IsType<ViewResult>(view);
      }    
    }
}