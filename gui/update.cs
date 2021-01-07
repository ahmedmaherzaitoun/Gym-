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
    public partial class updateform : Form
    {
        public updateform()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\Documents\GymDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            con.Open();
            string query = "select * from MemberTb";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            ada.Fill(ds);
            AllMemberU.DataSource = ds.Tables[0];
            con.Close();
        }
        private void updateform_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int key=0;
        private void AllMemberU_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            key = Convert.ToInt32(AllMemberU.SelectedRows[0].Cells[0].Value.ToString());

            NameTb.Text = AllMemberU.SelectedRows[0].Cells[1].Value.ToString();
            PhoneTb.Text = AllMemberU.SelectedRows[0].Cells[2].Value.ToString();
            GenderCb.Text = AllMemberU.SelectedRows[0].Cells[3].Value.ToString();
            AgeTb.Text = AllMemberU.SelectedRows[0].Cells[4].Value.ToString();
            AmountTb.Text = AllMemberU.SelectedRows[0].Cells[5].Value.ToString();
            TimingCb.Text = AllMemberU.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NameTb.Text= " ";
            PhoneTb.Text = " ";
            GenderCb.Text = " ";
            AmountTb.Text = " ";
            AgeTb.Text = " ";
            TimingCb.Text = " ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainform mainf = new mainform();
            mainf.Show();
            this.Hide();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (key == 0 || NameTb.Text == ""|| PhoneTb.Text == "" ||GenderCb.Text == ""|| AmountTb.Text == ""||AgeTb.Text =="" || TimingCb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update MemberTb set MName='"+NameTb.Text+"',Mphone='"+PhoneTb.Text+"',MAge="+AgeTb.Text+",MAmount="+AmountTb.Text+",MTimely='"+TimingCb.Text+"'where MId="+key+";";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Updated succssefuly");
                    populate();
                    con.Close();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Row to Delete it");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "delete from MemberTb where MId=" + key + ";";
                    SqlCommand cmd =new SqlCommand(query,con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Deleted succssefuly");
                    populate();
                    con.Close();

                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }
    }
}
