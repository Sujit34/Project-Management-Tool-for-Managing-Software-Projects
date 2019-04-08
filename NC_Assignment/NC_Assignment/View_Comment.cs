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
    public partial class View_Comment : Form
    {
        public View_Comment()
        {
            InitializeComponent();
            Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Comment ad_com = new Add_Comment();
            ad_com.Show();

        }
        public void show()
        {
            select_project.Text = Project_Details.project_name;
            select_task.Text = Project_Details.project_task;

            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");
            string query = "select comment as'Comment',comment_by as 'Comment By',comment_time as 'Comment Time' from assignmentdb.task_comment where project_name='"+Project_Details.project_name+"' and task='"+Project_Details.project_task+"'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = cmd;
            DataTable dTable = new DataTable();
            MyAdapter.Fill(dTable);
            dataGridView1.DataSource = dTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Project_Details pd = new Project_Details();
            pd.Show();
        }

    }
}
