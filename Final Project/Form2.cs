using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

namespace Final_Project
{
    public partial class Form2 : Form
    {

        SqlConnection Connect = new SqlConnection("Data Source=DESKTOP-4VTNIQH\\SQLEXPRESS01;Initial Catalog=vasllibrary;Integrated Security=True;");

        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labll3_click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lable1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void Btn_Signup_Click(object sender, EventArgs e)
        {
            Form3 Form2 = new Form3();
            Form2.Show();
            this.Hide();
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            if (TXT_Login_UserName.Text == " " || TXT_Login_Password.Text == " ")
            {
                MessageBox.Show("Please fill all blank fields ", "Error messeage", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (Connect.State != ConnectionState.Open) ;
                {
                    try
                    {
                        Connect.Open();
                        string selectData
                            = "SELECT * FROM users WHERE username = @username AND password = @password";
                        using (SqlCommand cmd = new SqlCommand (selectData ,Connect))
                        {
                            cmd.Parameters.AddWithValue("@username", TXT_Login_UserName.Text.Trim());
                            cmd.Parameters.AddWithValue("@password", TXT_Login_Password .Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if(table .Rows .Count >= 1)
                            {
                                MessageBox.Show("Login Successfully!", "Information messeage"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Main_Form Form = new Main_Form();
                                Form.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorect username/password", "Error messeage"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Connecting Database: " + ex, "Error messeage"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        Connect.Close();
                    }
                }
            }
            
                 
                

                













            
        }
    }
}