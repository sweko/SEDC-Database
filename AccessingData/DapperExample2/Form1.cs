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

namespace DapperExample2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var studentTypeMap = new CustomPropertyTypeMap(
                typeof (Student),
                (type, columnName) =>
                {
                    if (columnName == "PhoneNumber")
                        return type.GetProperty("Phone");
                    return type.GetProperty(columnName);
                });

            SqlMapper.SetTypeMap(typeof(Student), studentTypeMap);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cs = ConfigurationManager.ConnectionStrings["TheBase"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cs))
            {
                cnn.Open();
                var result = cnn.ExecuteScalar<int>(@"select count(*) from students");
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
                var queryParameters = new DynamicParameters();
                foreach (var parameter in parameterValues)
                {
                    queryParameters.Add(parameter.Key, parameter.Value);
                }
                var students = cnn.Query<Student>(query, queryParameters);

                foreach (var student in students)
                {
                    listBox1.Items.Add(student);
                }
            }
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

        private void InsertStudent(Student student)
        {
            var cs = ConfigurationManager.ConnectionStrings["TheBase"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cs))
            {
                cnn.Open();
                cnn.Execute(@"insert into Students (FirstName, LastName, PhoneNumber, Email, DateOfBirth)
values (@FirstName,@LastName,@Phone,@Email,@DateOfBirth)", student);
            }
        }
    }
}
