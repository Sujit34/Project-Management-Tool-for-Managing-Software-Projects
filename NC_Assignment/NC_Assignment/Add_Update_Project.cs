using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace NC_Assignment
{
    public partial class Add_Update_Project : Form
    {
        public string status;
        public int diff;
        public Add_Update_Project()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e)
        {
            string Query = "insert into assignmentdb.project(name,code_name,description,poss_start_date,poss_end_date,duration,status) values(?name,?code_name,?description,?poss_start_date,?poss_end_date,?duration,?status);";

            if (radioButton1.Checked == true)
            {
                status = "Not-Started";
            }
            else if (radioButton2.Checked == true)
            {
                status = "Started";
            }
            else if (radioButton2.Checked == true)
            {
                status = "Completed";
            }
            else if (radioButton2.Checked == true)
            {
                status = "Cancelled";
            }

            Insert(Query);// call the insert function
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


                cmd.Parameters.AddWithValue("?name", name.Text);
                cmd.Parameters.AddWithValue("?code_name", code_name.Text);
                cmd.Parameters.AddWithValue("?description", description.Text);
                cmd.Parameters.AddWithValue("?poss_start_date", possible_start_date.Text);
                cmd.Parameters.AddWithValue("?poss_end_date", possible_end_date.Text);
                cmd.Parameters.AddWithValue("?duration", diff);
                cmd.Parameters.AddWithValue("?status", status);                

                cmd.ExecuteNonQuery();
                MessageBox.Show("Info. Saved");
                con.Close();


            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }

        }

        // File upload in a folder
        private void browse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "All Files(*.*)|*.*";
                dlg.FilterIndex = 1;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.CheckFileExists)
                    {
                        
                        string _path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10)); //go to application folder (<bin) (10 for bin\\debug)
                        string correct_filename = Path.GetFileName(dlg.FileName); // actual file name
                        File.Copy(dlg.FileName, _path + "\\file\\" + correct_filename + "." + name.Text); //copy file in the folder
                        
                    }

                }
            }
            catch
            {
                MessageBox.Show("File Already Saved");
            }
        }

        private void next_form_Click(object sender, EventArgs e)
        {
            this.Hide();
            Assign_Res_Person ass_res_per = new Assign_Res_Person();
            ass_res_per.Show();

        }

        private void possible_end_date_ValueChanged(object sender, EventArgs e)
        {
            //Calculate time duration
            DateTime start_date = possible_start_date.Value;//start date
            DateTime end_date = possible_end_date.Value;//end date
            TimeSpan tspan = end_date - start_date;//duration
            diff = tspan.Days;// duration in days
            duration.Text = diff.ToString();
        }
    }
}

