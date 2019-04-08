using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace NC_Assignment
{
    public partial class Add_Comment : Form
    {
        public Add_Comment()
        {
            InitializeComponent();
            combo1_fill();
        }

        public void combo1_fill()
        {
            try
            {
                string dbcon = "datasource=localhost;port=3306;username=root;password=root";

                string Query = "select * from assignmentdb.project";
                MySqlConnection con = new MySqlConnection(dbcon);
                MySqlCommand cmd = new MySqlCommand(Query, con);

                MySqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string fill = reader.GetString("name");
                    comboBox1.Items.Add(fill);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void combo2_fill(string str1)
        {
            try
            {
                string dbcon = "datasource=localhost;port=3306;username=root;password=root";

                string Query = "select * from assignmentdb.task where project_name='" + str1 + "'";
                MySqlConnection con = new MySqlConnection(dbcon);
                MySqlCommand cmd = new MySqlCommand(Query, con);

                MySqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string fill = reader.GetString("description");
                    comboBox2.Items.Add(fill);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            string str = comboBox1.SelectedItem.ToString();
            combo2_fill(str);
        }

        private void save_Click(object sender, EventArgs e)
        {
            string Query1 = "insert into assignmentdb.task_comment(comment,comment_by,comment_time,project_name,task) values(?comment,?comment_by,?comment_time,?project_name,?task);";

            Insert(Query1); 
        }
        public void Insert(string insert_query)
        {
            try
            {


                string dbcon = "datasource=localhost;port=3306;username=root;password=root";

                MySqlConnection con = new MySqlConnection(dbcon);
                MySqlCommand cmd = new MySqlCommand(insert_query, con);
                con.Open();

                cmd.Parameters.AddWithValue("?comment", richTextBox1.Text);
                cmd.Parameters.AddWithValue("?comment_by", Form1.user_name);
                cmd.Parameters.AddWithValue("?comment_time", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("?project_name", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("?task", comboBox2.SelectedItem);

               

                cmd.ExecuteNonQuery();
                MessageBox.Show("Info. Saved");
                con.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_Comment vc = new View_Comment();
            vc.show();
        }


    }
}
