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
    public partial class Add_update_taskcs : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");

        public Add_update_taskcs()
        {
            InitializeComponent();
            combo1_fill();

        }

        //fill comboBox1(select project)
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

        //fill combobox2(select resource person)
        public void combo2_fill(string str1)
        {
            try
            {
                string dbcon = "datasource=localhost;port=3306;username=root;password=root";

                string Query = "select * from assignmentdb.resperson where project_name='"+str1+"'";
                MySqlConnection con = new MySqlConnection(dbcon);
                MySqlCommand cmd = new MySqlCommand(Query, con);

                MySqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string fill = reader.GetString("res_person");
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

        private void button1_Click(object sender, EventArgs e)
        {
            string Query1 = "insert into assignmentdb.task(project_name,assignto,description,due_date,priority) values(?project_name,?assignto,?description,?due_date,?priority);";

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

                cmd.Parameters.AddWithValue("?project_name", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("?assignto", comboBox2.SelectedItem);
                cmd.Parameters.AddWithValue("?description", description.Text);
                cmd.Parameters.AddWithValue("?due_date", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("?priority", comboBox3.SelectedItem);

                

                cmd.ExecuteNonQuery();
                MessageBox.Show("Info. Saved");
                con.Close();

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Project_Details pd = new Project_Details();
            pd.Show();

        }



    }
}
