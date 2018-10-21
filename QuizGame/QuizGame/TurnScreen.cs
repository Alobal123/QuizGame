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
    public partial class TurnScreen : Form
    {
        enum State{
            ready,
            running,
            showing,
            eval
        }

        private Turn turn;
        private State state = State.ready;
        private int speed1 = 850;
        private int speed2 = 1;

        private int grid_width =  16;
        private int grid_height = 9;

        private List<Point> hiddenIndices;
        private List<Answer> answers;
        private Random rnd = new Random();

        private Image image;
        private string answer;
        private ResultLabel resultLabel;

        PictureBox[,] boxes = null;

        internal TurnScreen(Turn turn)
        {

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            this.Text = turn.name;
            this.turn = turn;

            InitializeComponent();

        }

        private void TurnScreen_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case State.ready:
                    if (this.boxes == null)
                    {
                        this.boxes = CreatePictureBoxes();
                    }
                    state = State.running;
                    timer.Interval = speed1;
                    Question question = turn.getQuestion();
                    answers = new List<Answer>();
                    if(question == null)
                    {
                        this.Close();
                        break;
                    }
                    this.answer = question.Answer;
                    this.image = Image.FromFile(question.Path);
                    this.hiddenIndices = getAllIndices(grid_width, grid_height);
                    timer.Enabled = true;
                    break;
                case State.running:
                    timer.Interval = speed2;
                    state = State.showing;
                    break;
                case State.showing:
                    break;
                case State.eval:
                    this.state = State.ready;
                    this.resultLabel.Dispose();
                    ResetBoxes();
                    break;
                default:
                    break;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Answer newest = Program.ws.get_Answer();
            if (newest != null)
            {
                answers.Add(newest);
            }
            changePicture(); 
        }

        private void changePicture()
        {
            if (hiddenIndices.Count == 0)
            {
                this.state = State.eval;
                ShowResult();
                this.timer.Enabled = false;
            }
            else
            {
                Point point = hiddenIndices[0];
                hiddenIndices.RemoveAt(0);

                int x = image.Width / grid_width;
                int y = image.Height / grid_height;

                int dx = image.Width % grid_width;
                int dy = image.Height % grid_height;

                Image croppedImage = CropImage(this.image, new Rectangle(x*point.X, y*point.Y, x, y));
                boxes[point.X, point.Y].Image = croppedImage;
            }
        }

        private List<Point> getAllIndices(int width, int height)
        {
            List<Point> indices = new List<Point>();
            for (int i = 0; i < width; i++)
            {
                for (int k = 0; k < height; k++)
                {
                    indices.Add(new Point(i,k));
                }
            }
            indices.ShuffleMe();
            return indices;
        } 

        private PictureBox[,] CreatePictureBoxes()
        {
            int width = this.ClientRectangle.Width / this.grid_width;
            int height = this.ClientRectangle.Height / this.grid_height;
            PictureBox[,] boxes = new PictureBox[grid_width,grid_height];
            for (int i = 0; i < grid_width; i++)
            {
                for (int k = 0; k < grid_height; k++)
                {
                    PictureBox box = new PictureBox
                    {
                        Width = width,
                        Height = height
                    };
                    box.Location = new Point(i * box.Width, k * box.Height);
                    this.Controls.Add(box);
                    box.BackColor = Color.Black;
                    box.SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i, k] = box;
                }
            }
            return boxes;
        }
        private void ResetBoxes()
        {
            foreach (var box in boxes)
            {
                box.Image = null;
            }
        }

        private Image CropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        private void TurnScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                TurnScreen_Click(sender, e);
        }
        private void ShowResult()
        {
            ResultLabel label = new ResultLabel(this.answer, answers);
            label.Location = new Point(this.ClientRectangle.Width/2 - label.Width/2, this.ClientRectangle.Height/2 - label.Height/2);
            this.Controls.Add(label);
            label.BringToFront();
            this.resultLabel = label;
        }

    }
}
