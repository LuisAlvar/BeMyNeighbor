using System;
using System.Collections.Generic;

namespace BeMyNeighbor.Data.Entities
{
    public partial class UsersEvaluation
    {
        public UsersEvaluation()
        {
            EvaluationQuestions = new HashSet<EvaluationQuestions>();
        }

        public int EvaluationId { get; set; }
        public int PostId { get; set; }
        public int TaskTypeId { get; set; }
        public int UserId { get; set; }
        public int TotalScore { get; set; }

        public virtual Post Post { get; set; }
        public virtual Task TaskType { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<EvaluationQuestions> EvaluationQuestions { get; set; }
    }
}
