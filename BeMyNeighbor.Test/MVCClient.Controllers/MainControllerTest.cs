using Microsoft.AspNetCore.Mvc;
using Xunit; 
using BeMyNeighbor.MVCClient.Controllers;
using BeMyNeighbor.Domain.Models;
using BeMyNeighbor.Data.Entities;

namespace BeMyNeighbor.Test.MVCClient.Controllers{
    public class MainControllerTest{
    
        [Fact]
        public void IndexWithUserNotNullAndHasCommunityTest(){
          var mn = new MainController();
          CurrentUser.SetStorage(new LocalUser{
            UserDb = new User{
            UserId =1,
            Username = "eslam",
            Email = "eom@yahoo.com",
            NubmerOfPoints =1,
            AddressId = 10,
            CommunityId = 10
          }
          });
          var view = mn.Index();
          Assert.NotNull(view);
          Assert.IsNotType<IActionResult>(view);    
        } 
    }
}