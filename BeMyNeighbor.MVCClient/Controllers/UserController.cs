using Microsoft.AspNetCore.Mvc;
using BeMyNeighbor.Domain.Models.DbModels;
using BeMyNeighbor.Domain.Models;
using System.Collections.Generic;
using BeMyNeighbor.Data.Entities;
using System;

namespace BeMyNeighbor.MVCClient.Controllers{
    public class UserController : Controller{

        public IActionResult SignupPage(){
		    return View("UserSignupPage",CommunityDbManager.GetInstance().PullAllCommunities());
		}

        [HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult SignUp (Address ads, string firstname, string lastname,
        string username, string email, string password, int CommunityId){
        if (UserDbManager.GetInstance().SignUp(ads, firstname, lastname, username, email, password, CommunityId)){	
                
                ViewData["Msg"] = "User Created, Re-directing to Home Page";
			    return View("../Home/Index");
			}else{
			    ViewData["Msg"] = "The email address you entered is already registered!";
			    return View("../Home/Index");
			}
		}
    }
}