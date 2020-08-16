using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// https://www.youtube.com/watch?v=P7aaaLvWy_s&t=14s
//成功 20200808  記得將原生MySQL關閉, xampp打開

namespace LoginMySQL_20200808_
{
    public partial class Form1 : Form
    {
        MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=test;User Id=root;password='1111'");
        int i;
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from login where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            // 找到符合的列數傳回1, 都不符則傳回0

            if (i==0)
            {
                //MessageBox.Show("row is" + i);
                label3.Text = "you have entered invalid username and password";
            }
            else
            {
                this.Hide();
                //MessageBox.Show("row is" + i);
                Form2 fm = new Form2();
                fm.Show();
            }
          
        }
    }
}
