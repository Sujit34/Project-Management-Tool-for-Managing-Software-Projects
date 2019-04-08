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
    public partial class IT_Admin_arena : Form
    {
        public string status;

        public IT_Admin_arena()
        {
            InitializeComponent();
            gridshow(); // show existing user in the datagridview
        }

        // Add new user 
        private void add_Click(object sender, EventArgs e)
        {
            string Query = "insert into assignmentdb.user(name,email,default_pass,status,designation) values(?name,?email,?default_pass,?status,?designation);";

            if (radioButton1.Checked == true)
            {
                status = "active";
            }
            else if (radioButton2.Checked == true)
            {
                status = "inactive";
            }

            Insert(Query);// call the insert function
        }


        // update user 
        private void update_Click(object sender, EventArgs e)
        {
            string Query = "update assignmentdb.user set name='" + this.name.Text + "',email='" + this.email.Text + "',default_pass='" + this.password.Text + "',status='" + this.status + "',designation='" + this.comboBox1.SelectedItem + "' where email='" + this.email.Text + "';";
            Update(Query);

        }


        // insert operation
        public void Insert(string insert_query)
        {
            try
            {
                string dbcon = "datasource=localhost;port=3306;username=root;password=root";               

                MySqlConnection con = new MySqlConnection(dbcon);
                MySqlCommand cmd = new MySqlCommand(insert_query, con);
                con.Open();              

                cmd.Parameters.AddWithValue("?name", name.Text);
                cmd.Parameters.AddWithValue("?email", email.Text);
                cmd.Parameters.AddWithValue("?default_pass", password.Text);
                cmd.Parameters.AddWithValue("?status", status);
                cmd.Parameters.AddWithValue("?designation", comboBox1.SelectedItem);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Info. Saved");
                con.Close();

                clear(); // clear textbox, radiobutton, combobox 

                gridshow(); // call for viewing in the datagridview
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             
        }

        // update operation
        public void Update(string update_query)
        {
            try
            {

                string dbcon = "datasource=localhost;port=3306;username=root;password=root";                

                MySqlConnection con = new MySqlConnection(dbcon);
                MySqlCommand cmd = new MySqlCommand(update_query, con);
                MySqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();
                MessageBox.Show("Data Updated");
                con.Close();
                clear(); // clear textbox, radiobutton, combobox 
                gridshow();  // call for viewing in the datagridview

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }         
        }


        // show in the gridview
        public void gridshow()
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=root";

                string Query = "select name as 'Name',email as 'Email',designation as 'Designation',status as 'status',default_pass as 'Password' from assignmentdb.user order by name";
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


        // clear operation
        public void clear()
        {
            name.Clear();
            email.Clear();
            password.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            comboBox1.SelectedItem = null;
 
        }      


        // cellclick in datagridview
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cel = null;
            foreach (DataGridViewCell selectedCell in dataGridView1.SelectedCells)
            {
                cel = selectedCell;
                break;

            }
            if (cel != null) //find out row
            {

                DataGridViewRow row = cel.OwningRow;

                name.Text = row.Cells[0].Value.ToString();
                email.Text = row.Cells[1].Value.ToString();                  
                password.Text = row.Cells[4].Value.ToString();

                if (row.Cells[3].Value.ToString().Equals("active"))
                {
                    radioButton1.Checked = true;
                    status = "active";
                }
                else if (row.Cells[3].Value.ToString().Equals("inactive"))
                {
                    radioButton2.Checked = true;
                    status = "inactive";
 
                }
                comboBox1.SelectedItem=row.Cells[2].Value.ToString();                
           }
        }




    }
}
