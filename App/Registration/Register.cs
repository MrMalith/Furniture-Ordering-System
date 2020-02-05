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
using System.Diagnostics;
using ControlzEx.Standard;
//using System.Data.SqlClient.SqlException;

namespace Registration
{
    public partial class Register : Form
    {
        public Register()
        {
            var sw = Stopwatch.StartNew();
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            long ticks = sw.ElapsedTicks;
            Console.WriteLine(ticks);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3BDK76K\SQLEXPRESS;Initial Catalog=FurnitureOrdering;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            //check whether all the text boxes are !empty
            TextBox[] newTextBoxes = { txtUserName, txtPassword, txtAdd, txtMob };
            for(int inti=0; inti<newTextBoxes.Length; inti++ )
            {
                if(newTextBoxes[inti].Text==String.Empty)
                {
                    MessageBox.Show("Please fill the TextBox");
                    newTextBoxes[inti].Focus();
                    return;
                }                
            }
            if(txtUserName.Text.Length<5)
            {
                MessageBox.Show("Your username must be at least five characters! ");
                txtUserName.Focus();
                return;
            }
            if(txtPassword.Text.Length<5)
            {
                MessageBox.Show("Your password must be at least five characters! ");
                txtPassword.Focus();
                return;
            }
            if(txtMob.Text.Length<9)
            {
                MessageBox.Show("Enter a valid Mobile number! ");
                txtMob.Focus();
                return;

            }
            
            //connecting to the database
            con.Open();

            string sql = "INSERT INTO Register (username , Password , address , mobile_no) VALUES (' " + txtUserName.Text + "' , '" + txtPassword.Text + "' , '" + txtAdd.Text + "' , '" + txtMob.Text + "')";
           

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.ExecuteNonQuery();

            MessageBox.Show("User is registered");
            //link to the login form
            Login ss = new Login();

            ss.Show();

            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult iExit;

            iExit = MessageBox.Show("Confirm u want to Exit the system", "Covanro Furniture", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login ss1 = new Login();

            ss1.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMob_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void LinklblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            Login ss1 = new Login();

            ss1.Show();
        }
    }
}
