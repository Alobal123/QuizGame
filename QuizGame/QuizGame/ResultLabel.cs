﻿using System;
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
                AnswerBox answerBox = new AnswerBox(a);
                this.rightResultPanel.Controls.Add(answerBox);
                if (LevenshteinDistance.Compute(this.rightAnswerLabel.Text, a.AnswerString) < 5)
                {
                    answerBox.isRight = true;
                    answerBox.BackColor = Color.Green;
                }
                else
                {
                    answerBox.isRight = false;
                    answerBox.BackColor = Color.Red;
                }
            }
        }


        public void countPoints()
        {
            bool first = true;
            foreach (var comp in rightResultPanel.Controls)
            {
                if (comp is AnswerBox)
                {
                    AnswerBox box = (AnswerBox)comp;
                    if (box.isRight) {
                        if (first)
                        {
                            Game.teams[box.answer.TeamName].give_points(3);
                            first = false;
                        }
                        else { Game.teams[box.answer.TeamName].give_points(1); }
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
