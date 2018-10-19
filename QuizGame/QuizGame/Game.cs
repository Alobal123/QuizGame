using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    class Game
    {
        private string gameFolder;
        private List<Team> teams = new List<Team>();

        public Game(string gameFolder)
        {
            this.gameFolder = gameFolder;
        }

        public void AddTeam(Team team)
        {
            teams.Add(team);
        }
        public List<Team> getTeams()
        {
            return teams;
        }

    }
}
