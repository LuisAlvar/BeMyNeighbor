using Microsoft.AspNetCore.Mvc;
using Xunit; 
using BeMyNeighbor.MVCClient.Controllers;
using BeMyNeighbor.Domain.Models;
using BeMyNeighbor.Data.Entities;

namespace BeMyNeighbor.Test.MVCClient.Controllers{
    public class MainControllerTest{
      private MainController _MainController = new MainController();

      // [Fact]
      // public void SelectCommunity_Test(){
      //   var view = _MainController.SelectCommunity();
      //   Assert.NotNull(view);
      //   Assert.IsType<ViewResult>(view);
      // }

      // [Fact]
      // public void ViewJobList_Test(){
      //   var view = _MainController.ViewJobList();
      //   Assert.NotNull(view);
      //   Assert.IsType<ViewResult>(view);
      // }

      // [Fact]
      // public void SelectedCommunity_Test(){
      //   var view = _MainController.SelectedCommunity(new LocalUser());
      //   Assert.NotNull(view);
      //   Assert.IsType<RedirectToActionResult>(view);
      // }

      // [Fact]
      // public void SelectedJob_Test(){
      //   var view = _MainController.SelectedJob(2342535);
      //   Assert.NotNull(view);
      //   Assert.IsType<RedirectToActionResult>(view);
      // }

    }
}