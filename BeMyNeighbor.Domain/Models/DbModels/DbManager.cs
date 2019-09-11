using BeMyNeighbor.Data.Entities;

namespace BeMyNeighbor.Models.DbModels{
	public class DbManager{
		private static BeMyNeighborContext _dbConnection;
		private DbManager(){
		}
		public static BeMyNeighborContext GetInstance(){
			if (_dbConnection == null){ 
      	_dbConnection = new BeMyNeighborContext();
    	} 
    	return _dbConnection; 
  	}	
	}
}