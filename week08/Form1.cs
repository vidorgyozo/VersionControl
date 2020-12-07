using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week08.Abstractions;
using week08.Entities;

namespace week08
{
    public partial class Form1 : Form
    {
        List<Toy> _toys = new List<Toy>();

        Toy _nextToy;

        private IToyFactory _factory;

        public IToyFactory Factory
        {
            get { return _factory; }
            set
            {
                _factory = value;
                DisplayNext();
            }
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
            ballButton.Text = Resource1.Ball;
            carButton.Text = Resource1.Car;
            comingNextLabel.Text = Resource1.ComingNext;

            ballButton.Click += BallButton_Click;
            carButton.Click += CarButton_Click;
        }

        private void CarButton_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void BallButton_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            Toy newToy = Factory.CreateNew();
            _toys.Add(newToy);
            mainPanel.Controls.Add(newToy);
            newToy.Left = -newToy.Width;
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            int maxPos = 0;
            foreach (Toy toy in _toys)
            {
                toy.MoveToy();
                if (maxPos < toy.Left)
                {
                    maxPos = toy.Left;
                }
            }

            if (maxPos > 1000)
            {
                Toy oldestToy = _toys[0];
                mainPanel.Controls.Remove(oldestToy);
                _toys.Remove(oldestToy);
            }
        }

        private void DisplayNext()
        {
            if (_nextToy != null)
            {
                this.Controls.Remove(_nextToy);
            }
            _nextToy = Factory.CreateNew();
            _nextToy.Left = comingNextLabel.Left + 75;
            _nextToy.Top = 5;
            this.Controls.Add(_nextToy);
        }
    }
}
