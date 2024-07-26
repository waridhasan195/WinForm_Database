using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using Json.Net;

namespace StudentPortal
{
    public  class Add_Data
    {
        public static Form1 f1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
        static string gender;
        Form1 ff = new Form1();
        


        public static void GenderGroupBox()
        {

            if ( f1.FemaleRadioButton.Checked)
            {
                gender = f1.FemaleRadioButton.Text;
                Console.WriteLine("RadioButton: " + gender);
            }
            if ( f1.MaleRadioButton.Checked )
            {
                gender = f1.MaleRadioButton.Text;
                Console.WriteLine("RadioButton: " + gender);
            }
            else
            {
                Console.WriteLine("Gender Data Error");
            }

        }

        

        public static void Add_Data_Function()
        {


             Form1 mainFormObject = new Form1();
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\warid\OneDrive\Documents\StudentPortal.mdf;Integrated Security=True;Connect Timeout=30");
            
            DateTime today = DateTime.Now;
            int today_Year = today.Year;
            int give_Age = f1.BirthDatePicker.Value.Year;
            int actual_Agee = today_Year - give_Age;

            if (connect.State == ConnectionState.Closed)
            {

                try
                {
                    
                    
                    connect.Open();
                    string InserDataQuery = "INSERT INTO Student_Personal_Info " +
                                            " (FullName, Age, Gender, Address_In_Text, Address_In_Menu, PhoneNumber, Email) " +
                                            "VALUES " +
                                            "(@FullName, @Age, @Gender, @Address_In_Text, @Address_In_Menu, @PhoneNumber, @Email)";
                    string ComboAddress = "Division: " + f1.DivisionComboBox.Text.Trim() + ", District: " + f1.DistrictComboBox.Text.Trim() + ", Thana: " + f1.ThanaComboBox.Text.Trim();
                    Form1 form1 = new Form1();


                    using (SqlCommand cmd = new SqlCommand(InserDataQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@FullName", f1.FullNameTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@Age", actual_Agee);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@Address_In_Text", f1.Address_in_Text.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address_In_Menu", ComboAddress);
                        cmd.Parameters.AddWithValue("@PhoneNumber", f1.ContactNumberTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", f1.EmailTextBox.Text.Trim());

                        cmd.ExecuteNonQuery();


                        MessageBox.Show("Data Add Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data Add Function Not Working: " + ex.ToString(), "Data Add Problem: " , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();    
                }
            }
            else
            {
                Console.WriteLine("Exit! Database Connection Failed.");
            }
        }
    }
}
