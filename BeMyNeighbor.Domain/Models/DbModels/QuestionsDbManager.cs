using System.Collections.Generic;
using BeMyNeighbor.Data.Entities; 
using System.Linq;

namespace BeMyNeighbor.Domain.Models.DbModels{
	public class QuestionsDbManager{

		public List<Questions> QuestionsList {get;}

		private static QuestionsDbManager instance;
		private QuestionsDbManager(){
			QuestionsList = InitializeQuestionsList();
		}
		private List<Questions> InitializeQuestionsList(){

			List <Questions> qList = new List<Questions>();
			qList = DbManager.GetInstance().Questions.ToList();
			return qList;
		}
		public static QuestionsDbManager GetInstance(){
			if (instance == null){ 
      	instance = new QuestionsDbManager(); 
    	} 
    	return instance; 
  	}	
	}
}
