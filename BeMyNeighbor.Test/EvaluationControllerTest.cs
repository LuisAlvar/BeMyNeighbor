using Microsoft.AspNetCore.Mvc;
using Xunit; 
using BeMyNeighbor.MVCClient.Controllers;
namespace BeMyNeighbor.Test
{
    public class EvaluationControllerTest{

        [Fact]
        public void TestStartNewSubmission(){

            var eval = new UserEvaluationController();
            var view = eval.StartNewEvaluation(1,1,1);
            Assert.NotNull(view);
			Assert.IsType<ViewResult>(view);
        }

        [Fact]
        public void TestEvaluationSubmission(){
            var eval = new UserEvaluationController();
            var view = eval.SubmitEvaluation(new System.Collections.Generic.List<string>{
                "1","1"
            });
            Assert.NotNull(view);
			Assert.IsType<ViewResult>(view);
        }
    }
}