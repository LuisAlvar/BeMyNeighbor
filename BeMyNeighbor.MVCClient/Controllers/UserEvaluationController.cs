using Microsoft.AspNetCore.Mvc;
using BeMyNeighbor.Domain.Models.DbModels;
using BeMyNeighbor.Domain.Models;
using System.Collections.Generic;
using BeMyNeighbor.Domain.Models.ViewModels;
using System;

namespace BeMyNeighbor.MVCClient.Controllers
{
    public class UserEvaluationController : Controller{
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult StartNewEvaluation(int postID,int selectedUserID,int taskTypeID){

            CurrentUser.Storage().CreatePostViewModel.userId = selectedUserID;
            CurrentUser.Storage().CreatePostViewModel.evaluationPostID = postID;
            CurrentUser.Storage().CreatePostViewModel.TaskTypeId = taskTypeID;
            return View ("EvaluateUser",QuestionsDbManager.GetInstance().QuestionsList);
        }
        public IActionResult ViewEvaluationHistory(){
            
            return View("ViewEvaluationHistory", 
            EvaluationDbManager.GetInstance().ListUserEvaluation(CurrentUser.Storage().UserDb.UserId));
        }

[HttpPost]
[ValidateAntiForgeryToken]
        public IActionResult SubmitEvaluation (List<string> QuestionScore){
            bool flag = EvaluationDbManager.GetInstance().PushEvaluation(QuestionScore,
            CurrentUser.Storage().CreatePostViewModel.evaluationPostID,
            CurrentUser.Storage().CreatePostViewModel.userId, 
            CurrentUser.Storage().CreatePostViewModel.TaskTypeId);

            if(flag){
                ViewData["msg"] = "Evaluation Submitted Successfully";
            }else{
                ViewData["msg"] = "Error in submitting evaluation";
            }
            return View("EvaluationSubmissionReceiptPage");

        }
        
    }
}