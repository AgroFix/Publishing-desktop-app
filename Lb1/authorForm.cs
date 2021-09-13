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
    public partial class authorForm : Form
    {
        public authorForm()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=itproger;SSL Mode=None");
        MySqlCommand command;
        private void authorForm_Load(object sender, EventArgs e)
        {
            populateDGV();

        }
        public void populateDGV()
        {
            string selectQuery = "SELECT * FROM author";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
       

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
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
                command = new MySqlCommand(query,connection);
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
        private void button1_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO author(fname, lname, age) VALUES('"+textBox2.Text+"','"+ textBox3.Text +"','"+textBox4.Text +"')";
            excuteMyQuery(insertQuery);
            populateDGV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE author SET fname='" + textBox2.Text + "',lname='" + textBox3.Text + "',age=" + textBox4.Text + " WHERE id_author ="+int.Parse(textBox1.Text);
            excuteMyQuery(updateQuery);
            populateDGV();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string deleteQuery = "DELETE FROM author WHERE id_author = " + int.Parse(textBox1.Text);
            excuteMyQuery(deleteQuery);
            populateDGV();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
   
}
