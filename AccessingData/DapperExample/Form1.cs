using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace DapperExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DapperMappings.Init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cs = ConfigurationManager.ConnectionStrings["TheBase"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cs))
            {
                cnn.Open();
                var result = cnn.ExecuteScalar(@"select count(*) from students");
                string message = string.Format("There are {0} students", result);
                MessageBox.Show(message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowStudents(@"select FirstName, PhoneNumber, DateOfBirth, Email, LastName, ID from students");
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

        private void ShowStudents(string query, Dictionary<string, object> parameters)
        {
            listBox1.Items.Clear();
            var cs = ConfigurationManager.ConnectionStrings["TheBase"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cs))
            {
                cnn.Open();
                var students = cnn.Query<Student>(query, DapperMappings.MapParameters(parameters));
                foreach (var student in students)
                {
                    listBox1.Items.Add(student);
                }
            }

        }

        private void InsertStudent(Student student)
        {
            var cs = ConfigurationManager.ConnectionStrings["TheBase"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cs))
            {
                cnn.Open();
                var parameters = new
                {
                    firstName = student.FirstName,
                    lastName = student.LastName,
                    phone = student.Phone,
                    email = student.Email,
                    dob = student.DateOfBirth
                };

                cnn.Execute(@"insert into Students (FirstName, LastName, PhoneNumber, Email, DateOfBirth)
values (@firstName,@lastName,@phone,@email,@dob)", parameters);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required");
                return;
            }
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required");
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Email is required");
                return;
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
