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
    internal partial class TurnButton : Button
    {
        private Turn turn;
        public TurnButton(Turn turn)
        {
            this.turn = turn;
            this.Text = turn.name;
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Font = new Font(this.Font.FontFamily, 28);
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
            ((MainScreen)Parent.Parent).stopTeamAdding();
            TurnScreen form = new TurnScreen(turn,(MainScreen)(this.Parent.Parent));
            form.ShowDialog();
            this.Enabled = false;
        }
    }
    
}
