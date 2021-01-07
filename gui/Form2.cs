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
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addmemberform addmember = new addmemberform();
            addmember.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateform updatef = new updateform();
            updatef.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            payment pay = new payment();
            pay.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            viewmember vm = new viewmember();
            vm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
