using BeMyNeighbor.Data.Entities;

namespace BeMyNeighbor.Models.DbModels{
	public class DbManager{
		private static BeMyNeighborDBContext _dbConnection;
		private DbManager(){
		}
		public static BeMyNeighborDBContext GetInstance(){
			if (_dbConnection == null){ 
      	_dbConnection = new BeMyNeighborDBContext();
    	} 
    	return _dbConnection; 
  	}	
	}
}