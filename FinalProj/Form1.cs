﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Diagnostics;

namespace FinalProj
{
    public partial class Form1 : Form
    {
        private SQLiteConnection student_con;
        private SQLiteConnection class_con;
        private SQLiteConnection weight_con;
        private SQLiteCommand command;

        public Form1()
        {
            InitializeComponent();
            student_con = new SQLiteConnection("DataSource = studentGPA.db");
            class_con = new SQLiteConnection("DataSource = ClassWeight.db");
            weight_con = new SQLiteConnection("DataSource = weightAverage.sqlite");
            refreshStudentTable();
            calculateGPA();
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
            catch (Exception e)
            { Debug.WriteLine("HELP"); }
        }

        private void refreshStudentClassTable(String ln, String fn)
        {
            student_con.Open();
            SQLiteDataAdapter sqlData = new SQLiteDataAdapter("select * from classes" + ln + fn, student_con);
            DataTable table = new DataTable();
            sqlData.Fill(table);
            this.dataGridView1.DataSource = table;
            this.dataGridView1.Columns["ID"].DisplayIndex = 5;
            this.dataGridView1.Columns["class"].DisplayIndex = 0;
            this.dataGridView1.Columns["average"].DisplayIndex = 1;
            this.dataGridView1.Columns["tier"].DisplayIndex = 2;
            this.dataGridView1.Columns["exempted"].DisplayIndex = 3;
            this.dataGridView1.Columns["credit"].DisplayIndex = 4;
            student_con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            label3.Visible = true;
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
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && label1.Visible)
            {
                student_con.Open();
                command = new SQLiteCommand("INSERT INTO students(lastName, firstName, grade, GPA, credits) VALUES ('" + textBox2.Text + "', '" + textBox1.Text + "' , " + textBox3.Text +
                    ", '" + 0.0 + "', " + 0 + ")", student_con);
                command.ExecuteNonQuery();
                command = new SQLiteCommand("CREATE TABLE classes" + textBox2.Text + textBox1.Text + " (ID INTEGER PRIMARY KEY AUTOINCREMENT, class TEXT, average INT, tier INT, exempted TEXT, credit NUMERIC)", student_con);
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
            catch (Exception e1)
            { }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (addStudent.Visible)
            {
                DataGridViewRow r = dataGridView1.SelectedRows[0];
                firstNameText.Text = firstNameText.Text + r.Cells["firstName"].Value.ToString();
                lastNameText.Text = lastNameText.Text + r.Cells["lastName"].Value.ToString();
                String grade = "" + r.Cells["grade"].Value.ToString();
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
                gradeLevel.Visible = true;
                label5.Visible = true;
                gradeLevel.Text = grade;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String fn = firstNameText.Text.Split(new char[1] { (char)32 })[1];
            String ln = lastNameText.Text.Split(new char[1] { (char)32 })[1];
            try
            {
                student_con.Open();
                if(Convert.ToInt64(gradeLevel.Text) > 8)
                {
                    command = new SQLiteCommand("UPDATE students SET grade = " + gradeLevel.Text + " WHERE firstName = '" + fn + "' and lastName = '" + ln + "'", student_con);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e1)
            { }
            finally
            {
                student_con.Close();
            }
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
            textBox4.Text = "";
            calculateGPA();
            gradeLevel.Text = "";
            gradeLevel.Visible = false;
            label5.Visible = false;
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
            gradeLevel.Visible = false;
            label5.Visible = false;
            CancelAverage.Visible = true;
            addClass.Visible = false;
            deleteClass.Visible = false;
            textBox4.Text = "";
            backtoStudents.Visible = false;
            MissingClass.Visible = true;
            class_con.Open();
            SQLiteDataAdapter sqlData = new SQLiteDataAdapter("SELECT * FROM ClassWeights", class_con);
            DataTable dt = new DataTable();
            sqlData.Fill(dt);
            this.dataGridView1.DataSource = dt;
            class_con.Close();
        }

        private void deleteClass_Click(object sender, EventArgs e)
        {
            student_con.Open();
            try
            {
                String fn = firstNameText.Text.Split(new char[1] { (char)32 })[1];
                String ln = lastNameText.Text.Split(new char[1] { (char)32 })[1];
                if (dataGridView1.SelectedRows.Count >= 1)
                {
                    foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                    {
                        command = new SQLiteCommand("DELETE FROM classes" + ln + fn + " WHERE class = '" + r.Cells["class"].Value + "' AND average = " + r.Cells["average"].Value + 
                            " AND ID = " + r.Cells["ID"], student_con);
                        command.ExecuteNonQuery();
                    }
                    SQLiteDataAdapter sqlData = new SQLiteDataAdapter("select * from classes"+ln+fn, student_con);
                    DataTable dt = new DataTable();
                    sqlData.Fill(dt);
                    this.dataGridView1.DataSource = dt;
                }
                
            }
            catch (Exception e1)
            { Debug.WriteLine("Isuck"); }
            student_con.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (Semester1Grade.Visible)
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
                catch (Exception e1)
                { }
            }
            else if (addStudent.Visible)
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
                catch (Exception e1)
                { }
            }
            else if(addClass.Visible)
            {
                student_con.Open();
                try
                {
                    String fn = firstNameText.Text.Split(new char[1] { (char)32 })[1];
                    String ln = lastNameText.Text.Split(new char[1] { (char)32 })[1];
                    SQLiteDataAdapter sqlData = new SQLiteDataAdapter("SELECT * FROM classes"+ln+fn+" WHERE class LIKE '%" + textBox4.Text + "%'", student_con);
                    DataTable dt = new DataTable();
                    sqlData.Fill(dt);
                    this.dataGridView1.DataSource = dt;
                }
                catch (Exception e1)
                { }
                student_con.Close();
            }
        }

        private void CancelAverage_Click(object sender, EventArgs e)
        {
            Semester1Grade.Visible = false;
            Semester2Grade.Visible = false;
            textBox6.Visible = false;
            textBox5.Visible = false;
            gradeLevel.Visible = true;
            label5.Visible = true;
            Exempted1.Visible = false;
            Exempted2.Visible = false;
            AddAverage.Visible = false;
            CancelAverage.Visible = false;
            addClass.Visible = true;
            MissingClass.Visible = false;
            deleteClass.Visible = true;
            backtoStudents.Visible = true;
            textBox5.Text = textBox6.Text = textBox4.Text = "";
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
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    DataGridViewRow r = dataGridView1.SelectedRows[0];
                    if (textBox5.Text.Length > 0)
                    {
                        command = new SQLiteCommand("INSERT INTO classes" + ln + fn + "(class, average, tier, exempted, credit) VALUES ('" + r.Cells["className"].Value + " Semester 1', " + textBox5.Text + ", "
                            + r.Cells["tier"].Value + ", '" + (Exempted1.Checked ? "YES" : "NO") + "', " + (Convert.ToDouble(r.Cells["credit"].Value) >= 1.0? (Convert.ToDouble(r.Cells["credit"].Value) / 2.0) : Convert.ToDouble(r.Cells["credit"].Value)) + ")", student_con);
                        command.ExecuteNonQuery();
                    }
                    if (textBox6.Text.Length > 0)
                    {
                        command = new SQLiteCommand("INSERT INTO classes" + ln + fn + "(class, average, tier, exempted, credit) VALUES ('" + r.Cells["className"].Value + " Semester 2', " + textBox6.Text + ", "
                            + r.Cells["tier"].Value + ", '" + (Exempted2.Checked ? "YES" : "NO") + "', " + (Convert.ToDouble(r.Cells["credit"].Value) >= 1.0 ? (Convert.ToDouble(r.Cells["credit"].Value) / 2.0) : Convert.ToDouble(r.Cells["credit"].Value)) + ")", student_con);
                        command.ExecuteNonQuery();
                    }
                    Exempted1.Checked = false;
                    Exempted2.Checked = false;
                    labelAdded.Visible = true;
                    timer1.Enabled = true;
                }
            }
            catch (Exception e1)
            { }
            textBox5.Text = "";
            textBox6.Text = "";
            Exempted1.Checked = Exempted2.Checked = false;
            student_con.Close();
        }


        private void calculateGPA()
        {
            student_con.Open();
            weight_con.Open();
            try
            {
                for(int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    String ln = (String)row.Cells["lastName"].Value;
                    String fn = (String)row.Cells["firstName"].Value;
                    DataTable dt = new DataTable();
                    SQLiteDataAdapter sqlData = new SQLiteDataAdapter("SELECT * FROM classes" + ln + fn, student_con);
                    sqlData.Fill(dt);
                    double total = 0;
                    int count = 0;
                    double totalCredits = 0;
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            int tier = Convert.ToInt32(r["tier"]);
                            int average = Convert.ToInt32(r["average"]);
                            String exempted = (String)r["exempted"];
                            double credit = Convert.ToDouble(r["credit"]);
                            while(credit > 0)
                            {
                                if (average > 70)
                                {
                                    if (exempted.Equals("NO"))
                                    {
                                        if (average >= 97) command = new SQLiteCommand("select g97 from averages where tier = " + tier, weight_con);
                                        else if (average >= 93) command = new SQLiteCommand("SELECT g93 FROM averages WHERE tier = " + tier, weight_con);
                                        else if (average >= 90) command = new SQLiteCommand("SELECT g90 FROM averages WHERE tier = " + tier, weight_con);
                                        else if (average >= 87) command = new SQLiteCommand("SELECT g87 FROM averages WHERE tier = " + tier, weight_con);
                                        else if (average >= 83) command = new SQLiteCommand("SELECT g83 FROM averages WHERE tier = " + tier, weight_con);
                                        else if (average >= 80) command = new SQLiteCommand("SELECT g80 FROM averages WHERE tier = " + tier, weight_con);
                                        else if (average >= 77) command = new SQLiteCommand("SELECT g77 FROM averages WHERE tier = " + tier, weight_con);
                                        else if (average >= 73) command = new SQLiteCommand("SELECT g73 FROM averages WHERE tier = " + tier, weight_con);
                                        else command = new SQLiteCommand("SELECT g71 FROM averages WHERE tier = " + tier, weight_con);
                                        total += Convert.ToDouble(command.ExecuteScalar());
                                        count++;
                                    }
                                    totalCredits += 0.5;
                                }
                                credit -= .5;
                            }
                        }
                        if (count > 0)
                        {
                            total /= count;
                        }
                    }
                    command = new SQLiteCommand("UPDATE students SET GPA = " + Math.Round(total, 3) + " WHERE firstName = '" + fn + "' AND lastName = '" + ln + "'", student_con);
                    command.ExecuteNonQuery();
                    command = new SQLiteCommand("UPDATE students SET credits = " + totalCredits + " WHERE firstName = '" + fn + "' AND lastName = '" + ln + "'", student_con);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e1)
            {
                Debug.WriteLine("help");
            }
            student_con.Close();
            weight_con.Close();
            refreshStudentTable();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            if(addStudent.Visible)
            {
                MessageBox.Show("Double Click on Student Name to Edit Grades", "Help");
            }
            else if(addClass.Visible)
            {
                MessageBox.Show("Use Add Class and Delete Class Buttons to Add or Remove", "Help");
            }
            else if(AddAverage.Visible)
            {
                MessageBox.Show("Click on Class to Select and Input Averages, Then Click Add", "Help");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelAdded.Visible = false;
            timer1.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(textBox5.Visible)
            {
                textBox5.Focus();
            }
        }

        private void MissingClass_Click(object sender, EventArgs e)
        {

        }
    }
}




