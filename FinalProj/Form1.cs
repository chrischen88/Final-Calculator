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
        private SQLiteConnection class_con;
        private SQLiteCommand command;

        public Form1()
        {
            InitializeComponent();
            student_con = new SQLiteConnection("DataSource = studentGPA.db");
            class_con = new SQLiteConnection("DataSource = ClassWeight.db");
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

        private void refreshStudentClassTable(String ln, String fn)
        {
            student_con.Open();
            SQLiteDataAdapter sqlData = new SQLiteDataAdapter("select * from classes" + ln + fn, student_con);
            DataTable table = new DataTable();
            sqlData.Fill(table);
            this.dataGridView1.DataSource = table;
            student_con.Close();
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
            textBox1.Text = textBox2.Text = textBox3.Text = "";
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if(label1.Visible)
            {
                student_con.Open();
                command = new SQLiteCommand("INSERT INTO students(lastName, firstName, grade, GPA, credits) VALUES ('" + textBox2.Text + "', '" + textBox1.Text + "' , " + textBox3.Text +
                    ", '" + 0.0 + "', " + 0 + ")",student_con);
                command.ExecuteNonQuery();
                command = new SQLiteCommand("CREATE TABLE classes" + textBox2.Text + textBox1.Text + " (class TEXT, average INT, tier INT, exempted TEXT)", student_con);
                command.ExecuteNonQuery();
                student_con.Close();
            }
            label1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            label3.Visible = false;
            confirmButton.Visible = false;
            cancelButton.Visible = false;
            textBox1.Text = textBox2.Text = textBox3.Text = "";
            refreshStudentTable();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                student_con.Open();
                foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                {
                    command = new SQLiteCommand("DELETE FROM students WHERE firstName = '" + r.Cells["firstName"].Value + "' AND lastName = '" + r.Cells["lastName"].Value + "' AND" +
                        " grade = " + r.Cells["grade"].Value, student_con);
                    command.ExecuteNonQuery();
                    command = new SQLiteCommand("DROP TABLE classes" + r.Cells["lastName"].Value + r.Cells["firstName"].Value, student_con);
                    command.ExecuteNonQuery();
                }
                student_con.Close();
                refreshStudentTable();
            }
            catch(Exception e1)
            { }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dataGridView1.SelectedRows[0];
            refreshStudentClassTable(r.Cells["lastName"].Value.ToString(), r.Cells["firstName"].Value.ToString());
            backtoStudents.Visible = true;
            addStudent.Visible = false;
            deleteStudent.Visible = false;
            closeButton.Visible = false;
            addClass.Visible = true;
            deleteClass.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            refreshStudentTable();
            backtoStudents.Visible = false;
            addStudent.Visible = true;
            deleteStudent.Visible = true;
            closeButton.Visible = true;
            addClass.Visible = false;
            deleteClass.Visible = false;
        }

        private void addClass_Click(object sender, EventArgs e)
        {

        }

        private void deleteClass_Click(object sender, EventArgs e)
        {

        }
    }
}
