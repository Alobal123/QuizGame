using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizGame
{
    internal partial class TurnButton : Button
    {
        private Turn turn;
        public TurnButton(Turn turn)
        {
            this.turn = turn;
            this.Text = turn.name;
            this.Click += CreateTurnScreen;
            InitializeComponent();
        }

        public TurnButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CreateTurnScreen(object sender, EventArgs e)
        {
            TurnScreen form = new TurnScreen(turn);
            //Application.Run(form);
            form.ShowDialog();
            this.Enabled = false;
        }
    }
    
}
