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
            if(addStudent.Visible)
            {
                DataGridViewRow r = dataGridView1.SelectedRows[0];
                firstNameText.Text = firstNameText.Text + r.Cells["firstName"].Value.ToString();
                lastNameText.Text = lastNameText.Text + r.Cells["lastName"].Value.ToString();
                refreshStudentClassTable(r.Cells["lastName"].Value.ToString(), r.Cells["firstName"].Value.ToString());
                firstNameText.Visible = true;
                lastNameText.Visible = true;
                backtoStudents.Visible = true;
                addStudent.Visible = false;
                deleteStudent.Visible = false;
                closeButton.Visible = false;
                addClass.Visible = true;
                deleteClass.Visible = true;
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
            firstNameText.Visible = false;
            lastNameText.Visible = false;
            firstNameText.Text = "First: ";
            lastNameText.Text = "Last: ";
        }

        private void addClass_Click(object sender, EventArgs e)
        {
            Semester1Grade.Visible = true;
            Semester2Grade.Visible = true;
            textBox6.Visible = true;
            textBox5.Visible = true;
            Exempted1.Visible = true;
            Exempted2.Visible = true;
            AddAverage.Visible = true;
            CancelAverage.Visible = true;
            addClass.Visible = false;
            deleteClass.Visible = false;
            backtoStudents.Visible = false;
            class_con.Open();
            SQLiteDataAdapter sqlData = new SQLiteDataAdapter("SELECT * FROM ClassWeights", class_con);
            DataTable dt = new DataTable();
            sqlData.Fill(dt);
            this.dataGridView1.DataSource = dt;
            class_con.Close();
        }

        private void deleteClass_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(Semester1Grade.Visible)
            {
                try
                {
                    class_con.Open();
                    SQLiteDataAdapter sqlData = new SQLiteDataAdapter("select * from ClassWeights WHERE className LIKE '%" + textBox4.Text + "%'", class_con);
                    DataTable dt = new DataTable();
                    sqlData.Fill(dt);
                    this.dataGridView1.DataSource = dt;
                    class_con.Close();
                }
                catch(Exception e1)
                { }
            }
            else if(addStudent.Visible)
            {
                try
                {
                    student_con.Open();
                    SQLiteDataAdapter sqlData = new SQLiteDataAdapter("select * from students WHERE lastName LIKE '%" + textBox4.Text + "%' OR firstName LIKE '%" + textBox4.Text + "%'", student_con);
                    DataTable dt = new DataTable();
                    sqlData.Fill(dt);
                    this.dataGridView1.DataSource = dt;
                    student_con.Close();
                }
                catch(Exception e1)
                { }
            }
        }

        private void CancelAverage_Click(object sender, EventArgs e)
        {
            Semester1Grade.Visible = false;
            Semester2Grade.Visible = false;
            textBox6.Visible = false;
            textBox5.Visible = false;
            Exempted1.Visible = false;
            Exempted2.Visible = false;
            AddAverage.Visible = false;
            CancelAverage.Visible = false;
            addClass.Visible = true;
            deleteClass.Visible = true;
            backtoStudents.Visible = true;
            textBox5.Text = textBox6.Text = "";
            String fn = firstNameText.Text.Split(new char[1] { (char)32 })[1];
            String ln = lastNameText.Text.Split(new char[1] { (char)32 })[1];
            refreshStudentClassTable(ln, fn);
        }

        private void AddAverage_Click(object sender, EventArgs e)
        {
            try
            {
                student_con.Open();
                String fn = firstNameText.Text.Split(new char[1] { (char)32 })[1];
                String ln = lastNameText.Text.Split(new char[1] { (char)32 })[1];
                if(dataGridView1.SelectedRows.Count==1)
                {
                    DataGridViewRow r = dataGridView1.SelectedRows[0];
                    if (textBox5.Text.Length > 0)
                    {
                        command = new SQLiteCommand("INSERT INTO classes" + ln + fn + "(class, average, tier, exempted) VALUES ('" + r.Cells["className"].Value + " Semester 1', " + textBox5.Text + ", "
                            + r.Cells["tier"].Value + ", '" + (Exempted1.Checked ? "YES" : "NO") + "')", student_con);
                        command.ExecuteNonQuery();
                    }
                }
                student_con.Close();
            }
            catch(Exception e1)
            { }
        }
    }
}
