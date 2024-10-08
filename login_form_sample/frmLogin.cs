using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Import OleDb
using System.Data.OleDb;

namespace login_form_sample
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }


        // Create connection
        string conn_str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\khest\\Documents\\C#\\app_dev\\login_form_sample\\accounts.mdb";
        OleDbConnection conn;
        OleDbDataReader dr;
        OleDbCommand cmd;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;


            string query = "SELECT * from accounts where username=@username and password=@password";

            conn = new OleDbConnection(conn_str);

            cmd = new OleDbCommand(query, conn);

            conn.Open();

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                MessageBox.Show("Login successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Question);
            } else
            {
                MessageBox.Show("Invalid username or password", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

        }
    }
}
