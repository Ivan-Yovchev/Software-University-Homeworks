using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLoginIn_Click(object sender, EventArgs e)
        {
            if(this.textBoxUsername.Text == "nakov" &&
                this.textBoxPassword.Text == "12345")
            {
                MessageBox.Show("Login successful");
            }
            else
            {
                MessageBox.Show("Invalid login");
            }
        }
    }
}
