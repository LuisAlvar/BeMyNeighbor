using System.Collections.Generic;
using BeMyNeighbor.Data.Entities; 
using System.Linq;
using System;

namespace BeMyNeighbor.Domain.Models.DbModels{

	public class EvaluationDbManager{

		private static EvaluationDbManager instance;
		private EvaluationDbManager(){

		}
		public static EvaluationDbManager GetInstance(){
			if (instance == null){ 
      	instance = new EvaluationDbManager(); 
    	} 
    	return instance; 
  	}

		public bool PushEvaluation(List<string> QuestionScore, int postID, 
		int userID, int taskTypeID){

			List <EvaluationQuestions> qlist = new List<EvaluationQuestions>();
			int totalScore =0;
      for (int i=0; i<QuestionScore.Count; i++){
        	qlist.Add(new EvaluationQuestions{
            QuestionId = QuestionsDbManager.GetInstance().QuestionsList[i].QuestionId,
            QuestionScore = (int) Convert.ToUInt32(QuestionScore[i])
            }
        	);
					totalScore+= (int) Convert.ToUInt32(QuestionScore[i]);
      }
			try{
					DbManager.GetInstance().UsersEvaluation.Add(
						new UsersEvaluation{
							PostId = postID,
							UserId = userID,
							TaskTypeId = taskTypeID,
							EvaluationQuestions = qlist,
							TotalScore = totalScore
						}
					);
					DbManager.GetInstance().SaveChanges();
			}
			catch (System.Exception){
					return false;
			}
			return true;
		}

		public UsersEvaluation PullEvaluation(int postID){

			var checkedEvaluation = DbManager.GetInstance().UsersEvaluation
                       .Where(p => p.PostId == postID)
                       .SingleOrDefault();
			return checkedEvaluation;
		}
	}
}
