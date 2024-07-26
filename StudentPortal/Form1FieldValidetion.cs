using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentPortal
{
    internal class Form1FieldValidetion
    {
        public static Form1 f1_Validetion = Application.OpenForms.OfType<Form1>().FirstOrDefault();


        public static void Validetion()
        {
            if (string.IsNullOrEmpty(f1_Validetion.FullNameTextBox.Text))
            {
                MessageBox.Show("Please Enter your Full Name", "Fill up Waring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                f1_Validetion.FullNameTextBox.Focus();
                return;
            }

            DateTime today = DateTime.Now;
            int today_Year = today.Year;
            int give_Age = f1_Validetion.BirthDatePicker.Value.Year;
            int actual_Age = today_Year - give_Age;

            if (actual_Age < 18)
            {
                MessageBox.Show("You are under age !", "Under Age", MessageBoxButtons.OK, MessageBoxIcon.Question);
                f1_Validetion.BirthDatePicker.Focus();
                Console.WriteLine("Under Age.");
                return;
            }

            if (string.IsNullOrEmpty(f1_Validetion.MaleRadioButton.Text))
            {
                if (string.IsNullOrEmpty(f1_Validetion.FemaleRadioButton.Text))
                {
                    MessageBox.Show("Please Enter Gender", "Fill up Waring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    f1_Validetion.MaleRadioButton.Focus();
                    f1_Validetion.FemaleRadioButton.Focus();
                    return;
                }
                return;
            }

            if (string.IsNullOrEmpty(f1_Validetion.Address_in_Text.Text))
            {
                MessageBox.Show("Please Enter your Address", "Fill up Waring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                f1_Validetion.Address_in_Text.Focus();
                return;
            }
            if (string.IsNullOrEmpty(f1_Validetion.ContactNumberTextBox.Text))
            {
                MessageBox.Show("Please Enter your Contract", "Fill up Waring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                f1_Validetion.ContactNumberTextBox.Focus();
                return;
            }

            if (f1_Validetion.EmailTextBox.Text != "")
            {
                try
                {
                    new System.Net.Mail.MailAddress(f1_Validetion.EmailTextBox.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please Enter valid email. " + ex, "Fill up Waring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    f1_Validetion.EmailTextBox.Focus();
                    return;
                }
            }
            
        }
        
    }
}
