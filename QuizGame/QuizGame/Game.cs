using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    class Game
    {
        private string gameFolder;
        public static Dictionary<string, Team> teams = new Dictionary<string, Team>();
        private List<Turn> turns = new List<Turn>();

        public Game(string gameFolder)
        {
            this.gameFolder = gameFolder;
            loadTurns();
        }

        public void AddTeam(Team team)
        {
            teams[team.name] = team;
        }

        public List<Turn> getTurns()
        {
            return turns;
        }
        private void loadTurns()
        {
            string[] fileArray = Directory.GetDirectories(gameFolder);
            foreach (string dir in fileArray)
            {
                turns.Add(new Turn(dir));
            }
        }





    }
}
