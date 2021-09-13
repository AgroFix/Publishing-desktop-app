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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            authorForm AuthorForm = new authorForm();
            AuthorForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bookForm BookForm = new bookForm();
            BookForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        licenseForm LicenseForm = new licenseForm();
               LicenseForm.Show();
           
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            infoForm InfoForm = new infoForm();
            InfoForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            employeeForm EmployeeForm = new employeeForm();
            EmployeeForm.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            licenseForm LicenseForm = new licenseForm();
            LicenseForm.Show();
        }
    }
}
