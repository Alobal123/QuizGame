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
                rightAnswerLabel.Text += "\n";
                rightAnswerLabel.Text += a.ToString();
                
            }
        }
    }
}
