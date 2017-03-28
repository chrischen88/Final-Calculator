using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace FinalProj
{
    public partial class Form1 : Form
    {
        private SQLiteConnection student_con;
        private SQLiteCommand command;

        public Form1()
        {
            InitializeComponent();
            student_con = new SQLiteConnection("DataSource = studentGPA.db");
            refreshStudentTable();
        }

        public void refreshStudentTable()
        {
            try
            {
                student_con.Open();
                SQLiteDataAdapter sqlData = new SQLiteDataAdapter("select * from students", student_con);
                DataTable table = new DataTable();
                sqlData.Fill(table);
                this.dataGridView1.DataSource = table;
                student_con.Close();
            }
            catch(Exception e)
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            label3.Visible =true;
            confirmButton.Visible = true;
            cancelButton.Visible = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            label3.Visible = false;
            confirmButton.Visible = false;
            cancelButton.Visible = false;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if(label1.Visible)
            {
                student_con.Open();
                command = new SQLiteCommand("INSERT INTO students(lastName, firstName, grade, GPA, credits) VALUES ('" + textBox2.Text + "', '" + textBox1.Text + "' , " + textBox3.Text +
                    ", '" + 0.0 + "', " + 0 + ")",student_con);
                command.ExecuteNonQuery();
                student_con.Close();
            }
            refreshStudentTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            textBox3.Focus();
        }
    }
}
