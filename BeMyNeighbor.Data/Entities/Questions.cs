using System;
using System.Collections.Generic;

namespace BeMyNeighbor.Data.Entities
{
    public partial class Questions
    {
        public Questions()
        {
            EvaluationQuestions = new HashSet<EvaluationQuestions>();
        }

        public int QuestionId { get; set; }
        public string QuestionText { get; set; }

        public virtual ICollection<EvaluationQuestions> EvaluationQuestions { get; set; }
    }
}
