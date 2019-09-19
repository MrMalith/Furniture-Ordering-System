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

namespace Registration
{
    public partial class Login : Form
    {
        //connection string to the DB
        String cs = (@"Data Source=DESKTOP-3BDK76K\SQLEXPRESS;Initial Catalog=FurnitureOrdering;Integrated Security=True");
        public Login()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
          
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            //check whether text boxes are filled or not
            TextBox[] newTextBoxes = { txtUserName, txtPassword };
            for(int inti =0; inti<newTextBoxes.Length;inti++)
            {
                if(newTextBoxes[inti].Text==String.Empty)
                {
                    MessageBox.Show("Please fill all the fields! ");
                    newTextBoxes[inti].Focus();
                    return;
                }
            }
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                myConnection = new SqlConnection(cs);

                SqlCommand myCommand = default(SqlCommand);

                myCommand = new SqlCommand("SELECT username,password FROM Register WHERE username= @username AND password = @password");

                SqlParameter uName = new SqlParameter("@username", SqlDbType.VarChar);
                SqlParameter uPassword = new SqlParameter("@password", SqlDbType.VarChar);

                uName.Value = txtUserName.Text;
                uPassword.Value = txtPassword.Text;

                myCommand.Parameters.Add(uName);
                myCommand.Parameters.Add(uPassword);

                //intitializing component
                myCommand.Connection = myConnection;
                myConnection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                if (myReader.Read() == true)
                {
                    MessageBox.Show("Successfully logged-in "+ txtUserName.Text);
                    this.Hide();

                    Main_UI ss2 = new Main_UI();
                    ss2.Show();
                }
                else
                {
                    MessageBox.Show("Login failed!");

                    txtUserName.Clear();
                    txtPassword.Clear();
                }
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Dispose();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            Register ss2 = new Register();

            ss2.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
