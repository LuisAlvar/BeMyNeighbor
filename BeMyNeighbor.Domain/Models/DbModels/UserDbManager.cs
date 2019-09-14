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
      CurrentUser.Storage().Messages.SourceType = "/Auth/SignIn";
      try
      {
        CurrentUser.Storage().UserDb = DbManager.GetInstance().User.Single(u => (u.Username == user.UsernameOrEmail || u.Email == user.UsernameOrEmail) && (u.HashedPassword == user.Password));
      }
      catch (System.Exception)
      {
        CurrentUser.Storage().Messages.MessageType = "LoginError";
        CurrentUser.Storage().Messages.MessageToUser = "Invalid User or Password";
        CurrentUser.Storage().Messages.DestinationType = "/Auth/SignIn";
        return false;
      }

      return true;
    }

    public bool SignUp(LocalUser user){
      CurrentUser.Storage().Messages.SourceType = "/Auth/SignUp";
			try{
        DbManager.GetInstance().User.Add(new User{
            Firstname = user.UserDb.Firstname,
            Lastname = user.UserDb.Lastname,
            Address = user.AddressDb,
            Username = user.UserDb.Username,
            HashedPassword = user.Password,
            SeedPassword = user.Password,
            CommunityId = user.UserDb.CommunityId,
            Email = user.UserDb.Email,
            VerifiedUser = false,
            NubmerOfPoints = 0
        });
        DbManager.GetInstance().SaveChanges();
        CurrentUser.Storage().Messages.MessageType = "SignUpSuccessful";
        CurrentUser.Storage().Messages.MessageToUser = "Signed up Successfully! Please sign in.";
        CurrentUser.Storage().Messages.DestinationType = "/Auth/SignIn";
			}
			catch(System.Exception){
        CurrentUser.Storage().Messages.MessageType = "SignInErrorWithDb";
        CurrentUser.Storage().Messages.MessageToUser = "Username or email is already taken";
        CurrentUser.Storage().Messages.DestinationType = "/Auth/SignUp";
        return false;
      }
      return true;
    }
          
        
    }
}