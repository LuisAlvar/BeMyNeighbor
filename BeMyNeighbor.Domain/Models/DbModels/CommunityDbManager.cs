using System.Collections.Generic;
using BeMyNeighbor.Data.Entities; 
using System.Linq;

namespace BeMyNeighbor.Domain.Models.DbModels{
    public class CommunityDbManager{
        private static CommunityDbManager instance;
		private CommunityDbManager(){

		}
		public static CommunityDbManager GetInstance(){
			if (instance == null){ 
      	        instance = new CommunityDbManager(); 
    	    } 
    	return instance; 
  	    }

        public List<Community> PullAllCommunities(){
            List <Community> communities = new List<Community>();
            try{
                communities = DbManager.GetInstance().Community.ToList();
                return communities;
            }catch(System.Exception){
                return communities;
            }
        }  
    }
}