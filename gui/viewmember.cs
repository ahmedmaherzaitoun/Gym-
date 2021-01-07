using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class viewmember : Form
    {
        public viewmember()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\Documents\GymDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            con.Open();
            string query = "select * from MemberTb";
            SqlDataAdapter ada = new SqlDataAdapter(query,con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            ada.Fill(ds);
            AllMember.DataSource = ds.Tables[0];
            con.Close();
        }
        private void viewmember_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainform mainf = new mainform();
            mainf.Show();
            this.Hide();
        }

        private void AllMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void SearchByNames()
        {
            con.Open();
            string query = "select * from MemberTb where Mname='" + SearchMember.Text + "'";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            ada.Fill(ds);
            AllMember.DataSource = ds.Tables[0];
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            populate();
            SearchMember.Text = "";
        }

        private void Login_Click(object sender, EventArgs e)
        {
            SearchByNames();
        }
    }
}
