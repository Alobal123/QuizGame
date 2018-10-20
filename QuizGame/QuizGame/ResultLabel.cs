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
    public partial class ResultLabel : UserControl
    {
        public ResultLabel(string answer)
        {
            
            InitializeComponent();
            this.rightAnswerLabel.Text = answer;
        }
    }
}
