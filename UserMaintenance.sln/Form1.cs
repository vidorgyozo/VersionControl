using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.sln.Entities;

namespace UserMaintenance.sln
{
    public partial class Form1 : Form
    {
        private BindingList<User> _users = new BindingList<User>();

        public Form1()
        {
            InitializeComponent();

            fullNameLabel.Text = Resource1.FullName;
            addButton.Text = Resource1.Add;

            usersListBox.DataSource = _users;
            usersListBox.ValueMember = "ID";
            usersListBox.DisplayMember = "FullName";

            addButton.Click += AddButton_Click;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.FullName = fullNameTextBox.Text;
            _users.Add(u);
        }
    }
}
