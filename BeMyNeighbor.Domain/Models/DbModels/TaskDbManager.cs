using System.Collections.Generic;
using BeMyNeighbor.Data.Entities; 
using System.Linq;

namespace BeMyNeighbor.Domain.Models.DbModels{
	public class TaskDbManager{

		public List<Task> TaskTypeList {get;}

		private static TaskDbManager instance;
		private TaskDbManager(){
			TaskTypeList = InitializeTaskTypeList();
		}
		private List<Task> InitializeTaskTypeList(){

			List <Task> tList = new List<Task>();
			try{
                tList = DbManager.GetInstance().Task.ToList();
            }catch(System.Exception ex){
                System.Console.WriteLine(ex.ToString());
            }
			return tList;
		}
		public static TaskDbManager GetInstance(){
			if (instance == null){ 
      	instance = new TaskDbManager(); 
    	} 
    	return instance; 
  	}	
	}
}
