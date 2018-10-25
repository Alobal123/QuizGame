using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizGame
{
    internal partial class AnswerBox : Label
    {
        public Answer answer;
        public bool isRight = false;
        public AnswerBox(Answer answer)
        {
            this.answer = answer;
            this.Text = $"{answer.TeamName} : {answer.AnswerString}";
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Font = new Font(this.Font.FontFamily, 28);
            this.Size = new Size(new Point(600, 50));
            this.MouseClick += CheckAnswer;
            InitializeComponent();
        }

        private void CheckAnswer(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString() == "Left")
            {
                this.BackColor = Color.Green;
                this.isRight = true;
            }
            else
            {
                this.BackColor = Color.Red;
                this.isRight = true;
            }

            
        }

    }
}
