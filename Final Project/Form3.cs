using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class Form3 : Form
    {
       // SqlConnection Connect = new SqlConnection("Data Source=DESKTOP-4VTNIQH\\SQLEXPRESS01;Initial Catalog=vasllibrary;Integrated Security=True;");
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 Form3 = new Form2();
            Form3.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void lable1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_Register_Click(object sender, EventArgs e)
        {
            SqlConnection Connect = new SqlConnection("Data Source=DESKTOP-4VTNIQH\\SQLEXPRESS01;Initial Catalog=vasllibrary;Integrated Security=True;");

            if (Txt_EmailRegister.Text == " " || Txt_UserNameRegister .Text == " " || Txt_PasswordRegister.Text == "" )
            {
                MessageBox.Show("Please fill all blank fields ", "Error messeage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if( Connect.State != ConnectionState.Open)
                {
                    try
                    {
                        Connect.Open();

                        String CheckUsername = "SELECT COUNT(*) FROM Users WHERE username = @username";

                        using (SqlCommand CheckCMD = new SqlCommand(CheckUsername, Connect))
                        {
                            CheckCMD.Parameters.AddWithValue("@username", Txt_UserNameRegister.Text.Trim());
                             
                            int count = (int)CheckCMD.ExecuteScalar();

                            if (count >= 1)
                            {
                                MessageBox.Show(Txt_UserNameRegister .Text .Trim () + "is already taken", "Error messeage", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }else
                            {
                                DateTime day = DateTime.Today;
                                string insertData = "INSERT INTO Users (email,username,password , date_register) VALUES (@email, @username , @password ,@date)";

                                using (SqlCommand insertCMD = new SqlCommand (insertData , Connect))
                                {
                                    insertCMD.Parameters.AddWithValue("@email", Txt_EmailRegister.Text.Trim());
                                    insertCMD.Parameters.AddWithValue("@username", Txt_UserNameRegister .Text.Trim());
                                    insertCMD.Parameters.AddWithValue("@password", Txt_PasswordRegister .Text.Trim());
                                    insertCMD.Parameters.AddWithValue("@date", day .ToString ());


                                    insertCMD.ExecuteNonQuery();

                                    MessageBox.Show("Register successfully", "Information Message"
                                        , MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    Form2 Form1 = new Form2();
                                    Form1.Show();
                                    this.Hide();
                                }
                            }
                        }   
                         

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error Connecting Database: " + ex , "Error messeage", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        Connect.Close();
                    }
                }
;            }
            

        }
    }
}
