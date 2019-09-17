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
  }
}