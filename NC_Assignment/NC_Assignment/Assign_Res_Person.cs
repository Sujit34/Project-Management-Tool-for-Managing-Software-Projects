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
    public partial class Assign_Res_Person : Form
    {
        public string desig;

        public Assign_Res_Person()
        {
            InitializeComponent();
            combo1_fill();
            combo2_fill();
            gridshow();

        }



        //fill the comboBox1(select project)
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

        //fill the comboBox2(select resource person)
        public void combo2_fill()
        {
            try
            {
                string dbcon = "datasource=localhost;port=3306;username=root;password=root";

                string Query = "select * from assignmentdb.user";
                MySqlConnection con= new MySqlConnection(dbcon);
                MySqlCommand cmd = new MySqlCommand(Query, con);

                MySqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string fill = reader.GetString("name");
                    comboBox2.Items.Add(fill);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //save new data
        private void save_Click(object sender, EventArgs e)
        {
            string dbcon = "datasource=localhost;port=3306;username=root;password=root";

            string Query = "select * from assignmentdb.user where name='"+this.comboBox2.SelectedItem+"'";
            MySqlConnection con = new MySqlConnection(dbcon);
            MySqlCommand cmd = new MySqlCommand(Query, con);

            MySqlDataReader reader;
            con.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                 desig = reader.GetString("designation");
                
            }

            string Query1 = "insert into assignmentdb.resperson(project_name,res_person,designation,assigned_by) values(?project_name,?res_person,?designation,?assigned_by);";

            Insert(Query1); //call insert operation function

            gridshow();
        }

        //insert operation
        public void Insert(string insert_query)
        {
            try
            {              
                

                string dbcon = "datasource=localhost;port=3306;username=root;password=root";

                MySqlConnection con = new MySqlConnection(dbcon);
                MySqlCommand cmd = new MySqlCommand(insert_query, con);
                con.Open();

                cmd.Parameters.AddWithValue("?project_name", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("?res_person", comboBox2.SelectedItem);
                cmd.Parameters.AddWithValue("?designation", desig);
                cmd.Parameters.AddWithValue("?assigned_by", Form1.user_name); 
                

                cmd.ExecuteNonQuery();
                MessageBox.Show("Info. Saved");
                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // show int the dataggridview
        public void gridshow()
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=root";

                string Query = "select project_name as 'Project Name',res_person as 'Resource Person',designation as 'Designation' from assignmentdb.resperson order by project_name";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand myCommand = new MySqlCommand(Query, myConn);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = myCommand;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void next_Click(object sender, EventArgs e)
        {
            this.Hide();
            Project_Details pd = new Project_Details();
            pd.Show();
        }

    }
}
