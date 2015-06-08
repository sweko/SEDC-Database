using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace SedcStudents
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cs = ConfigurationManager.ConnectionStrings["TheBase"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cs))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(@"select count(*) from students", cnn);
                var result = (int)cmd.ExecuteScalar();
                string message = string.Format("There are {0} students", result);
                MessageBox.Show(message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowStudents(@"select * from students");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var query = @"select * from students
where FirstName like '%' + @search + '%'
   or LastName like '%' + @search + '%'";
            var parameters = new Dictionary<string, object>();
            parameters.Add("@search", textBox1.Text);

            ShowStudents(query, parameters);
        }

        private void ShowStudents(string query)
        {
            ShowStudents(query, new Dictionary<string, object>());
        }

        private void ShowStudents(string query, Dictionary<string, object> parameterValues)
        {
            listBox1.Items.Clear();
            var cs = ConfigurationManager.ConnectionStrings["TheBase"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cs))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);
                foreach (var parameter in parameterValues)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    object[] row = new object[6];
                    dr.GetValues(row);
                    Student student = new Student
                    {
                        ID = (int)row[0],
                        FirstName = (string)row[1],
                        LastName = (string)row[2],
                        Email = (string)row[3],
                        Phone = (string)row[4],
                        DateOfBirth = Convert.IsDBNull(row[5]) ? null : (DateTime?)row[5]
                    };
                    listBox1.Items.Add(student);
                }
            }
        }

        private void InsertStudent(Student student)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required");
            }
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required");
            }
                        if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Email is required");
            }

            Student student = new Student
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                DateOfBirth = dtpDateOfBirth.Value
            };

            InsertStudent(student);
            ShowStudents("select * from students");
        }
    }
}
