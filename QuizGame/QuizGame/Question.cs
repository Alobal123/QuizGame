using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{


    class Question
    {
        public string Answer { get; }
        public string Path { get; }

        public Question (string line)
        {
            string[] splited = line.Split(':');
            Path = splited[0];
            Answer = splited[1];
        }
    }
}
