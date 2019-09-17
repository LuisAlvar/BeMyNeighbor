using BeMyNeighbor.MVCClient.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace BeMyNeighbor.Test.MVCClient.Controllers{
  public class AuthController_UnitTest{
    private AuthController _AuthController = new AuthController();

    [Fact]
    public void SignIn_Test(){
      var view = _AuthController.SignIn();
      Assert.NotNull(view);
      Assert.IsType<ViewResult>(view);
    }

    [Fact]
    public void SignUp_Test(){
      var view = _AuthController.SignUp();
      Assert.NotNull(view);
      Assert.IsType<ViewResult>(view);
    }

  }
}