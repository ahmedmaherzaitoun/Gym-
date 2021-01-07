using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp7
{
    public partial class payment : Form
    {
        public payment()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\Documents\GymDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void FillNamePayment()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select MName from MemberTb", con);
            SqlDataReader read;
            read = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("MName", typeof(string));
            dt.Load(read);
            NameCb.ValueMember = "MName";
            NameCb.DataSource = dt;
            con.Close();
        }
        private void SearchByNames()
        {
            con.Open();
            string query = "select * from PaymentTb where PMember='"+SearchNameTb.Text+"'";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            ada.Fill(ds);
            AllMemberPayment.DataSource = ds.Tables[0];
            con.Close();
        }
        private void populate()
        {
            con.Open();
            string query = "select * from PaymentTb";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            ada.Fill(ds);
            AllMemberPayment.DataSource = ds.Tables[0];
            con.Close();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AmountTb.Text = "";
        }

        private void payment_Load(object sender, EventArgs e)
        {
            FillNamePayment();
            populate();
        }
        int key = 0;
        private void Login_Click(object sender, EventArgs e)
        {
            if (NameCb.Text == ""|| AmountTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                string pt = paytimeCb.Value.Month.ToString() + paytimeCb.Value.Year.ToString();

                con.Open();
                SqlDataAdapter ada = new SqlDataAdapter("select count(*) from PaymentTb where PMember='"+NameCb.SelectedValue.ToString()+"' and PMonth='" +pt+"'",con);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("This Month was paid");
                }
                else
                {
                    string query = "insert into PaymentTb values('" + pt + "','" + NameCb.SelectedValue.ToString() + "'," + AmountTb.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("The Payment process is successfully");
                }
                con.Close();
                populate();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainform mf = new mainform();
            mf.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SearchByNames();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            populate();
            SearchNameTb.Text= "";
        }
    }
}
