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

namespace SedcLister
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cs = ConfigurationManager.ConnectionStrings["SedcBase"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cs))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from Students", cnn);
                var result = cmd.ExecuteScalar();
                MessageBox.Show(result.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var cs = ConfigurationManager.ConnectionStrings["SedcBase"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cs))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("select * from Students", cnn);
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    object[] row = new object[4];
                    dr.GetValues(row);

                    var id = (int)row[0];
                    var firstName = (string)row[1];
                    var lastName = (string)row[2];
                    var dob = Convert.IsDBNull(row[3])
                        ? new DateTime(1945, 5, 9)
                        : (DateTime)row[3];

                    listBox1.Items.Add(
                        string.Format("#{0}; {1} {2}, {3}", id, firstName, lastName, dob));
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var cs = ConfigurationManager.ConnectionStrings["SedcBase"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cs))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(@"select * from Students 
where FirstName like '%'+ @search +'%'
	or LastName like '%'+ @search +'%'", cnn);
                cmd.Parameters.AddWithValue("@search", textBox1.Text);
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    object[] row = new object[4];
                    dr.GetValues(row);

                    var id = (int)row[0];
                    var firstName = (string)row[1];
                    var lastName = (string)row[2];
                    var dob = Convert.IsDBNull(row[3])
                        ? new DateTime(1945, 5, 9)
                        : (DateTime)row[3];

                    listBox1.Items.Add(
                        string.Format("#{0}; {1} {2}, {3}", id, firstName, lastName, dob));
                }


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var cs = ConfigurationManager.ConnectionStrings["SedcBase"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cs))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from Students where FirstName = @firstName and LastName = @lastName", cnn);
                cmd.Parameters.AddWithValue("@firstName", textBox2.Text);
                cmd.Parameters.AddWithValue("@lastName", textBox3.Text);
                var result = (int)cmd.ExecuteScalar();
                if (result > 0)
                {
                    SqlBuilder.UpdateStudent(cnn, textBox2.Text, textBox3.Text, dateTimePicker1.Value.Date);
                }
                else
                {
                    cmd = new SqlCommand(@"insert into Students(FirstName, LastName, DateOfBirth)
values (@firstName, @lastName, @dob);
select @@identity", cnn);
                    cmd.Parameters.AddWithValue("@firstName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@lastName", textBox3.Text);
                    cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value.Date);
                    var resultId = cmd.ExecuteScalar();

                    listBox1.Items.Add(
                        string.Format("#{0}; {1} {2}, {3}",
                        resultId, textBox2.Text, textBox3.Text, dateTimePicker1.Value.Date));
                }
            }
        }
    }
}
