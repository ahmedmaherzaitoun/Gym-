using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class loginform : Form
    {
        public loginform()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserNameTb.Text = "";
            PasswordTb.Text = "";
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (UserNameTb.Text == "user" && PasswordTb.Text == "12345")
            {
                mainform mf = new mainform();
                mf.Show();
                this.Hide();
            }
             else 
            {
                MessageBox.Show("User Name or Password incorrect");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginform_Load(object sender, EventArgs e)
        {

        }
    }
}
