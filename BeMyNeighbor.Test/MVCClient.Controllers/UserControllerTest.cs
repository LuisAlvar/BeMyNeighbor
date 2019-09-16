using Microsoft.AspNetCore.Mvc;
using Xunit; 
using BeMyNeighbor.MVCClient.Controllers;

namespace BeMyNeighbor.Test.MVCClient.Controllers{
    public class UserControllerTest{

        [Fact]
        public void SignupPageTesting(){
            var usr = new UserController();
            var view = usr.SignupPage();
            Assert.NotNull(view);
			Assert.IsType<ViewResult>(view);
        }        
    }
}