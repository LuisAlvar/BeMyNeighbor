using Microsoft.AspNetCore.Mvc;
using Xunit; 
using BeMyNeighbor.MVCClient.Controllers;
using BeMyNeighbor.Domain.Models.ViewModels;

namespace BeMyNeighbor.Test.MVCClient.Controllers{
    public class PostControllerTest{
        [Fact]
        public void CreatePostView(){
            var pst = new PostController();
            var view = pst.Create();
            Assert.NotNull(view);
			Assert.IsType<ViewResult>(view);
        } 
        
        [Fact]
        public void CreatePostAction(){
            var pst = new PostController();
            var view = pst.Create(new CreatePostViewModel{
                CommunityId = 10,
                userId = 1,
                TaskTypeId = 100,
                UserComment = "new post from testing project"
            });
            Assert.NotNull(view);
			Assert.IsType<ViewResult>(view);
        }        
    }
}