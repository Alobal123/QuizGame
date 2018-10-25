using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizGame
{
    internal partial class ResultLabel : UserControl
    {
        public ResultLabel(string answer, List<Answer> answers)
        {
            
            InitializeComponent();
            this.rightAnswerLabel.Text = answer;
            foreach (var a in answers)
            {
                this.rightResultPanel.Controls.Add(new AnswerBox(a));
                
            }
        }

        public void countPoints()
        {
            int place = 0;
            foreach (var comp in rightResultPanel.Controls)
            {
                if (comp is AnswerBox)
                {
                    AnswerBox box = (AnswerBox)comp;
                    if (box.isRight) {
                        
                        Game.teams[box.answer.TeamName].give_points(1);
                        MessageBox.Show($"giving points {Game.teams[box.answer.TeamName].points}");
                    }
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            ((TurnScreen)Parent).TurnScreen_Click(sender, e);
        }
    }
}
