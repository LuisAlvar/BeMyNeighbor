using BeMyNeighbor.Data.Entities;

namespace BeMyNeighbor.Models.DbModels{
	public class DbManager{


		private static DbManager instance;
		public BeMyNeighborDBContext _dbConnection;

		private DbManager(){
			_dbConnection = new BeMyNeighborDBContext(); 
		}
		public static DbManager GetInstance(){
			if (instance == null){ 
      	instance = new DbManager();
    	} 
    	return instance; 
  	}	
	}
}