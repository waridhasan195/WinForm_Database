using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace StudentPortal
{
    public static class ComboBoxAddress
    {
        public static Form1 f1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();

        public static void ComboBoxAddressDivisionFunction()
        {
            Console.WriteLine("ComboFunction");
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\warid\OneDrive\Documents\StudentPortal.mdf;Integrated Security=True;Connect Timeout=30");

            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    string AddressComboboxQueryDivision = "SELECT DISTINCT(Division) FROM AddressCombobox";
                    SqlCommand cmd = new SqlCommand(AddressComboboxQueryDivision, connect);
                    SqlDataReader reader = cmd.ExecuteReader();
 
                    while(reader.Read())
                    {
                        f1.DivisionComboBox.Items.Add(reader.GetValue(0).ToString());
                        Console.WriteLine(reader.GetValue(0).ToString());
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("ComboBoxErrorDivision: " + ex.Message);
                }
            }
        }

        public static void ComboBoxAddressDistrictFunction()
        {
            Console.WriteLine("ComboFunction");
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\warid\OneDrive\Documents\StudentPortal.mdf;Integrated Security=True;Connect Timeout=30");

            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    string DivisioncomboBoxValue = f1.DivisionComboBox.Text;
                    string AddressComboboxQueryDistricts = "SELECT DISTINCT(District) from AddressCombobox where Division = '" + f1.DivisionComboBox.Text + "'";
                    SqlCommand cmd = new SqlCommand(AddressComboboxQueryDistricts, connect);
                    SqlDataReader reader = cmd.ExecuteReader();
                    f1.DistrictComboBox.Items.Clear();

                    while (reader.Read())
                    { 
                        f1.DistrictComboBox.Items.Add(reader.GetValue(0).ToString());
                        Console.WriteLine(reader.GetValue(0).ToString());
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ComboBoxErrorDistrict: " + ex.Message);
                }
            }
        }

        public static void ComboBoxAddressThanaFunction()
        {
            Console.WriteLine("ComboFunction");
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\warid\OneDrive\Documents\StudentPortal.mdf;Integrated Security=True;Connect Timeout=30");

            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    string AddressComboboxQueryThana = "SELECT DISTINCT(Thana) from AddressCombobox where District = '" + f1.DistrictComboBox.Text + "'";
                    SqlCommand cmd = new SqlCommand(AddressComboboxQueryThana, connect);
                    SqlDataReader reader = cmd.ExecuteReader();
                    f1.ThanaComboBox.Items.Clear();

                    while (reader.Read())
                    {
                        f1.ThanaComboBox.Items.Add(reader.GetValue(0).ToString());
                        Console.WriteLine(reader.GetValue(0).ToString());
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("ComboBoxErrorThana: " + ex.Message);
                }
            }
        }
    }
}
