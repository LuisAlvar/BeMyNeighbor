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


          
        
    }
}