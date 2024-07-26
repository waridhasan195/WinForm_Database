using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace StudentPortal
{
    internal class Students_Personal_Info
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\warid\OneDrive\Documents\StudentPortal.mdf;Integrated Security=True;Connect Timeout=30");

        public int StudentId { get; set; }
        public string FullName { get; set;}
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Address_In_Text { get; set; }
        public string Address_In_Menu { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Date_insert { get; set; }
        public string Date_update { get; set; }


        public List<Students_Personal_Info> getListData()
        {
            List<Students_Personal_Info> ListData = new List<Students_Personal_Info>();

            if(connect.State == ConnectionState.Closed)
            {
                try 
                {     
                    connect.Open();
                    string data_Query = "SELECT * FROM Student_Personal_Info";
                    using (SqlCommand cmd = new SqlCommand(data_Query, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Students_Personal_Info spi = new Students_Personal_Info();
                            spi.StudentId = (int)reader["StudentId"];
                            spi.FullName = reader["FullName"].ToString();
                            spi.Age = reader["Age"].ToString();
                            spi.Gender = reader["Gender"].ToString();
                            spi.Address_In_Text = reader["Address_In_Text"].ToString();
                            spi.Address_In_Menu = reader["Address_In_Menu"].ToString();
                            spi.PhoneNumber = reader["PhoneNumber"].ToString();
                            spi.Email = reader["Email"].ToString();

                            ListData.Add(spi);
                            Console.WriteLine("Students_Personal_Info:" + ListData);

                        }
                    }
                } 
                catch (Exception ex)
                {
                    MessageBox.Show("Students_Personal_Info Error: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            return ListData;
        }
        
        
    }

}
