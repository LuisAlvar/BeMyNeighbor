using System.Collections.Generic;
using BeMyNeighbor.Data.Entities; 
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace BeMyNeighbor.Domain.Models.DbModels{
    public class UserDbManager{

        private static UserDbManager instance;
		private UserDbManager(){

		}
		public static UserDbManager GetInstance(){
			if (instance == null){ 
      	        instance = new UserDbManager(); 
    	    } 
    	return instance; 
  	    }

        public bool SignUp(Address ads, string firstname, string lastname,
        string username, string email, string password, int communityId){
			try{
                DbManager.GetInstance().User.Add(new User{
                    Firstname = firstname,
                    Lastname = lastname,
                    Address = ads,
                    Username = username,
                    HashedPassword = password,
                    SeedPassword = password,
                    CommunityId = communityId,
                    Email = email,
                    VerifiedUser = false,
                    NubmerOfPoints = 0
                });
                DbManager.GetInstance().SaveChanges();
				return true;
			}
			catch(System.Exception ex){
                System.Console.WriteLine(ex.ToString());
				return false;
			}
		}

    public bool SignIn(LocalUser user){
      try
      {
        CurrentUser.Storage().UserDb = DbManager.GetInstance().User.Single(u => u.Username == user.UserDb.Username || u.Email == user.UserDb.Email);
      }
      catch (System.Exception)
      {
        CurrentUser.Storage().Messages.MessageType = "LoginError";
        CurrentUser.Storage().Messages.MessageToUser = "Invalid User or Password";
        return false;
      }

      return true;
    }
          
        
    }
}