using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    class Turn
    {
        public string name { get; set; }
        private string dataFolder;
        private List<Question> questions = new List<Question>();
        

        public Turn(string dataFolder)
        {
            this.dataFolder = dataFolder;
            load_data();
        }

        private void load_data()
        {
            System.IO.StreamReader file =
                new System.IO.StreamReader(dataFolder + "\\config.txt");

            name = file.ReadLine();
            string line;
            while ((line = file.ReadLine()) != null)
            {
                questions.Add(new Question(line));
            }
            file.Close();
        }

    }
}
