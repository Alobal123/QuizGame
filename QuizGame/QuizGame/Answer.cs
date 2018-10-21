using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    class Answer
    {
        public string TeamName{ get; }
        public string AnswerString { get; }

        public Answer(string TeamName, string AnswerString)
        {
            this.TeamName = TeamName;
            this.AnswerString = AnswerString;
        }
        public override string ToString()
        {
            return $"Team {TeamName} answered {AnswerString}.";
        }
    }
}
