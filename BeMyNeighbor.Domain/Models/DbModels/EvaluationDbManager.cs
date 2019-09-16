using System.Collections.Generic;
using BeMyNeighbor.Data.Entities; 
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

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

					PostDbManager.UpdatePostDoneFlag(postID);
					
					DbManager.GetInstance().UsersEvaluation.Add(
						new UsersEvaluation{
							PostId = postID,
							UserId = userID,
							TaskTypeId = taskTypeID,
							EvaluationQuestions = qlist,
							TotalScore = totalScore,
						}
					);
					DbManager.GetInstance().SaveChanges();

					int taskReward = TaskDbManager.GetInstance().TaskTypeList.FirstOrDefault
					(t=> t.TaskTypeId == taskTypeID).TaskTypeRewardPoints;

					UserDbManager.GetInstance().UpdateUserPoints(userID,taskReward);
			}
			catch (System.Exception ex){
				System.Console.WriteLine(ex.ToString());
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

		public List<UsersEvaluation> ListUserEvaluation(int userID){
			
			List <UsersEvaluation> evals = new List<UsersEvaluation>();

			try{
					evals = DbManager.GetInstance().UsersEvaluation.Include("TaskType")
						.Include("EvaluationQuestions.Question").ToList().Where(p=> p.UserId == userID).ToList();
			}catch(System.Exception ex){
				System.Console.WriteLine(ex.ToString());
			}
			
			return evals;
		}
	}
}
