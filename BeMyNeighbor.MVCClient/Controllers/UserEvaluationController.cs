using Microsoft.AspNetCore.Mvc;
using BeMyNeighbor.Domain.Models.DbModels;
using BeMyNeighbor.Domain.Models;
using System.Collections.Generic;
using System;

namespace BeMyNeighbor.MVCClient.Controllers
{
    public class UserEvaluationController : Controller{

        public IActionResult StartNewEvaluation(){
            return View ("EvaluateUser",QuestionsDbManager.GetInstance().QuestionsList);
        }

[HttpPost]
[ValidateAntiForgeryToken]
        public IActionResult SubmitEvaluation (List<string> QuestionScore,
        string postID,string userID, string taskTypeID){
            // replace post params with current object like the current user object
            bool flag = EvaluationDbManager.GetInstance().PushEvaluation(QuestionScore,
            Convert.ToInt32 (postID),Convert.ToInt32(userID),Convert.ToInt32(taskTypeID));
            if(flag){
                ViewData["msg"] = "Evaluation Submitted Successfully";
            }else{
                ViewData["msg"] = "Error in submitting evaluation";
            }
            return View("EvaluationSubmissionReceiptPage");

        }
        
    }
}