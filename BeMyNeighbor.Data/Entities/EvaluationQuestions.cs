using System;
using System.Collections.Generic;

namespace BeMyNeighbor.Data.Entities
{
    public partial class EvaluationQuestions
    {
        public int EvaluationId { get; set; }
        public int QuestionId { get; set; }
        public int QuestionScore { get; set; }
        public string QuestionAnswer { get; set; }

        public virtual UsersEvaluation Evaluation { get; set; }
        public virtual Questions Question { get; set; }
    }
}
