using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NC_Assignment
{
    public partial class Form1 : Form
    {
        public static string loginas;
        public static string user_name;

        public Form1()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            try
            {
                

                loginas = comboBox1.SelectedItem.ToString();
                 user_name = name.Text;  
              

                this.Hide();
                if (loginas.Equals("IT Admin"))
                {
                    IT_Admin_arena itadmin = new IT_Admin_arena();
                    itadmin.Show();
                }
                else if (loginas.Equals("Project Manager") )
                {
                    Add_Update_Project add_up_pro = new Add_Update_Project();
                    add_up_pro.Show();
                }
                else 
                {
                    Assign_Res_Person ass_res_per = new Assign_Res_Person();
                    ass_res_per.Show();
                }
            }
            catch
            {
                MessageBox.Show("Select Designation");
            }
        }
    }
}
