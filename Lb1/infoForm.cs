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
    public partial class infoForm : Form
    {
        public infoForm()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=itproger;SSL Mode=None");
        MySqlCommand command;

        public void populateDGV()
        {

            string selectQuery = "SELECT id_book, bname,  year   FROM book ";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);
            adapter.Fill(table);

            dataGridView1.DataSource = table;

            string selectQuery1 = "SELECT id_author, fname, lname,  age   FROM author ";
            DataTable table1 = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(selectQuery1, connection);
            adapter1.Fill(table1);

            dataGridView2.DataSource = table1;

            string selectQuery2 = "SELECT id_license, kind, ddline   FROM license ";
            DataTable table2 = new DataTable();
            MySqlDataAdapter adapter2 = new MySqlDataAdapter(selectQuery2, connection);
            adapter2.Fill(table2);

            dataGridView3.DataSource = table2;

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

        private void infoForm_Load(object sender, EventArgs e)
        {
            populateDGV();
        }
    }
}
