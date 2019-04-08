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
    public partial class Project_Details : Form
    {
        public static string project_name;
        public static string project_task;

        public Project_Details()
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

        public void details(string str)
        {
            string query1 = "select name,code_name,description,poss_start_date,poss_end_date,duration,status from assignmentdb.project where name='"+str+"'";
            Select(query1);
 
        }
        public void Select(string query1)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");
            MySqlCommand cmd = new MySqlCommand(query1, con);
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = cmd;
            DataTable dTable = new DataTable();
            MyAdapter.Fill(dTable);

            name.Text = dTable.Rows[0][0].ToString();
            code_name.Text = dTable.Rows[0][1].ToString();
            description.Text = dTable.Rows[0][2].ToString();
            poss_start_date.Text = dTable.Rows[0][3].ToString();
            poss_end_date.Text = dTable.Rows[0][4].ToString();
            duration.Text = dTable.Rows[0][5].ToString();
            status.Text = dTable.Rows[0][6].ToString();
 
        }
        public void assigned_member(string str)
        {
            try
            {
                string query1 = "select res_person as 'Resource person',designation as 'Designation' from assignmentdb.resperson where project_name='"+str+"'";
                MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");
                MySqlCommand cmd = new MySqlCommand(query1, con);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = cmd;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView2.DataSource = dTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
 
        }
        public void tasklist(string str)
        {
            try
            {
                string query1 = "select distinct task.description as 'Description',task.assignto as 'Assign to', task.priority as 'Priority', resperson.assigned_by as 'Assigned By', task.due_date as 'Due Date' from assignmentdb.resperson,assignmentdb.task where task.project_name='" + str + "' and resperson.project_name='" + str + "'";
                MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");
                MySqlCommand cmd = new MySqlCommand(query1, con);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = cmd;
                DataTable dTable1 = new DataTable();
                MyAdapter.Fill(dTable1);
                dataGridView3.DataSource = dTable1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
 
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_update_taskcs tsk = new Add_update_taskcs();
            tsk.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = comboBox1.SelectedItem.ToString();
            project_name = str;
            details(str);
            assigned_member(str);
            tasklist(str);
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cel = null;
            foreach (DataGridViewCell selectedCell in dataGridView3.SelectedCells)
            {
                cel = selectedCell;
                break;

            }
            if (cel != null) //find out row
            {

                DataGridViewRow row = cel.OwningRow;

                project_task = row.Cells[0].Value.ToString();
                
            }

            this.Hide();
            View_Comment vc = new View_Comment();
            vc.show();
        }


    }
}
