using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            writeToFileButton.Text = Resource1.WriteToFile;
            deleteButton.Text = Resource1.Delete;

            usersListBox.DataSource = _users;
            usersListBox.ValueMember = "ID";
            usersListBox.DisplayMember = "FullName";

            addButton.Click += AddButton_Click;
            writeToFileButton.Click += WriteToFileButton_Click;
            deleteButton.Click += DeleteButton_Click;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (_users.Count > 0)
            {
                _users.RemoveAt(usersListBox.SelectedIndex);
            }
        }

        private void WriteToFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text File (*.txt) | *.txt";
            dialog.DefaultExt = ".txt";
            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                foreach (User u in _users)
                {
                    sb.AppendLine(String.Format("{0} {1}", u.ID, u.FullName));
                }
                byte[] textInByte = new UTF8Encoding(true).GetBytes(sb.ToString());
                Stream stream = dialog.OpenFile();
                stream.Write(textInByte, 0, textInByte.Length);
                stream.Flush();
                stream.Close();
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.FullName = fullNameTextBox.Text;
            _users.Add(u);
        }
    }
}
