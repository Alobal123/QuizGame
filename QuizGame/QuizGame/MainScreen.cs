using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizGame
{
    public partial class MainScreen : Form
    {
        private Game game;
        internal MainScreen(Game game)
        {
            InitializeComponent();
            this.game = game;
            this.Name = "QuizGame";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            foreach (var turn in game.getTurns())
            {
                Button newButton = new TurnButton(turn);
                newButton.Scale(4);
                TurnPanel.Controls.Add(newButton);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Answer answer = Program.ws.get_Answer();
            if(answer != null && !Game.teams.ContainsKey(answer.TeamName)){
                game.AddTeam(new Team(answer.TeamName, Color.Red));
                teamLabel.Text += $"\n{answer.TeamName}";

            }
        }
       public void ShowPoints()
        {
            MessageBox.Show("Showing points");
            teamLabel.Text = "";
            foreach(Team team in Game.teams.Values)
            {
                teamLabel.Text += $"\n{team.name}       {team.points}";
            }
            this.Refresh();
        }
       public void stopTeamAdding()
        {
            timer1.Enabled = false;
        }
    }
}
