using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace QuizGame
{
    class Team
    {
        public string name { get; set; }
        public Color color { get; set; }
        public int points { get; }

        public Team(string name, Color color)
        {
            this.points = 0;
            this.name = name;
            this.color = color;
        }

        public void give_points(int points)
        {
            points += points;
        }
        public override bool Equals(object obj)
        {
            return name == ((Team)obj).name;
        }


    }
}
