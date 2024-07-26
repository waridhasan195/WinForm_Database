using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;



namespace StudentPortal
{
    public partial class Form1 : Form
    {
        string buttoncheckedValue;
        
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\warid\OneDrive\Documents\StudentDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        

        public Form1()
        {
            InitializeComponent();
            DisplayAllData();
        }

        public void DisplayAllData()
        {
            DisplayStudentPersonalInfo();
        }







        public void DisplayStudentPersonalInfo()
        {
            Students_Personal_Info spi = new Students_Personal_Info();
            List<Students_Personal_Info> ViewData = spi.getListData();
            WeatherDescriptionValue.DataSource = ViewData;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PublicStaticClass.WeatherFunction();
            ComboBoxAddress.ComboBoxAddressDivisionFunction();
            AddButton.Enabled = false;
        }

        private void Exit_Icon_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Are you sure want to exit.", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ClearAllTextBox(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if(c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                else
                {
                    ClearAllTextBox(c);
                }
            }
            DivisionComboBox.Text = "Division";
            DistrictComboBox.Text = "District";
            ThanaComboBox.Text = "Thana";
            BirthDatePicker.Text = "";
            AgreeCheckBox.Checked = false;
            MaleRadioButton.Checked = false;
            FemaleRadioButton.Checked = false;
            
        }

        public void ClearContent_Click(object sender, EventArgs e)
        {
            ClearAllTextBox(this);
        }

        private void DivisioncomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DistrictComboBox.Items.Clear();
            ThanaComboBox.Items.Clear();
            ComboBoxAddress.ComboBoxAddressDistrictFunction();


        }

        private void DistrictComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxAddress.ComboBoxAddressThanaFunction();
            
        }

        private void NumbersOnlyContactTextBox(object sender, KeyPressEventArgs e)
        {
            int asciicode = Convert.ToInt32(e.KeyChar);

            if (asciicode != 8)
            {
                if (asciicode >= 9 && asciicode <= 57)
                {
                    e.Handled = false;
                }

                if ((sender as TextBox).Text.Length >= 11)
                {
                    e.Handled = true;
                    MessageBox.Show("Please Enter Valid Phone Number.", "Phone Number Lenght only 11.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                return;
            }

            else
            {
                MessageBox.Show("Please Enter Valid Number.", "Numbers Only.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void AgreeCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (AgreeCheckBox.Checked)
            {
                AddButton.Enabled = true;
            }
            if (!AgreeCheckBox.Checked)
            {
                AddButton.Enabled = false;
            }
        }

        

        private void AddButton_Click(object sender, EventArgs e)
        {
            //Form1FieldValidetion.Validetion();
            Form1FieldValidetion.Validetion();
            Add_Data.Add_Data_Function();
            
            
            DisplayAllData();
            ClearContent_Click();

        }

        public void ClearContent_Click()
        {
            ClearAllTextBox(this);
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            Add_Data.GenderGroupBox();
        }




        /*

        public void RadioButtonChange_Click(object sender, EventArgs e)
        {
            
                        RadioButton selectedRadioButton = sender as RadioButton;
                        if(selectedRadioButton != null && selectedRadioButton.Checked)
                        {
                            buttoncheckedValue = selectedRadioButton.Text;
                            Console.WriteLine("RadioButton: " + buttoncheckedValue);
                        }
                        else
                        {
                            Console.WriteLine("RadioButton Error" );
                        }
            

        Add_Data.GenderGroupBox();
        }

        */


    }


}
