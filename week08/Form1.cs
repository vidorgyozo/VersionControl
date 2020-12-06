using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week08.Entities;

namespace week08
{
    public partial class Form1 : Form
    {
        List<Ball> _balls = new List<Ball>();

        private BallFactory _factory;

        public BallFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            Ball newBall = Factory.CreateNew();
            _balls.Add(newBall);
            mainPanel.Controls.Add(newBall);
            newBall.Left = -newBall.Width;
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            int maxPos = 0;
            foreach (Ball ball in _balls)
            {
                ball.MoveBall();
                if (maxPos < ball.Left)
                {
                    maxPos = ball.Left;
                }
            }

            if(maxPos > 1000)
            {
                Ball oldestBall = _balls[0];
                mainPanel.Controls.Remove(oldestBall);
                _balls.Remove(oldestBall);
            }
        }
    }
}
