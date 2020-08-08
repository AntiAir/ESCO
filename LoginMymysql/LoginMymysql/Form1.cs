using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LoginMymysql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void btnlogin_Click(object sender, EventArgs e)
        {
            string user = txtuser.Text;
            string pass = txtpass.Text;
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=dbtest");
            MySqlDataAdapter sda = new MySqlDataAdapter("select count (*) from users where username = '" + txtuser.Text + "' and password = '" + txtpass.Text + "'",conn);
            DataTable dt = new DataTable();
            _ = sda.Fill(dt);
            if(dt.Rows[0][0].ToString()=="1")
            {
                MessageBox.Show("username and password are matched", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

            }
            else
            {
                MessageBox.Show("incorrect username and password are matched", "alter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
