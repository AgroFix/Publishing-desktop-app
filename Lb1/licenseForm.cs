using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lb1
{
    public partial class licenseForm : Form
    {
        public licenseForm()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=itproger;SSL Mode=None");
        MySqlCommand command;

        public void populateDGV()
        {

            string selectQuery = "SELECT id_license, kind,  ddline   FROM license ";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);
            adapter.Fill(table);

            dataGridView1.DataSource = table;

        }
        public void openConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public void excuteMyQuery(string query)
        {
            try
            {
                openConnection();
                command = new MySqlCommand(query, connection);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Query Executed");
                }
                else
                {
                    MessageBox.Show("Query Not Executed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void licenseForm_Load(object sender, EventArgs e)
        {
            populateDGV();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO license(id_license, kind,ddline) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            excuteMyQuery(insertQuery);
            populateDGV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE license SET kind='" + textBox2.Text + "',license=" + textBox3.Text + " WHERE id_license =" + int.Parse(textBox1.Text);
            excuteMyQuery(updateQuery);
            populateDGV();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string deleteQuery = "DELETE FROM license WHERE id_license = " + int.Parse(textBox1.Text);
            excuteMyQuery(deleteQuery);
            populateDGV();
        }
    }
}
