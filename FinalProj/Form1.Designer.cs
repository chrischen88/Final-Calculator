namespace FinalProj
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.addStudent = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.deleteStudent = new System.Windows.Forms.Button();
            this.backtoStudents = new System.Windows.Forms.Button();
            this.addClass = new System.Windows.Forms.Button();
            this.deleteClass = new System.Windows.Forms.Button();
            this.Semester1Grade = new System.Windows.Forms.Label();
            this.Semester2Grade = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.Exempted1 = new System.Windows.Forms.CheckBox();
            this.Exempted2 = new System.Windows.Forms.CheckBox();
            this.AddAverage = new System.Windows.Forms.Button();
            this.CancelAverage = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.firstNameText = new System.Windows.Forms.Label();
            this.lastNameText = new System.Windows.Forms.Label();
            this.labelAdded = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gradeLevel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MissingClass = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(12, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(485, 298);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // addStudent
            // 
            this.addStudent.Location = new System.Drawing.Point(505, 221);
            this.addStudent.Name = "addStudent";
            this.addStudent.Size = new System.Drawing.Size(123, 23);
            this.addStudent.TabIndex = 1;
            this.addStudent.Text = "Add Student";
            this.addStudent.UseVisualStyleBackColor = true;
            this.addStudent.Click += new System.EventHandler(this.button1_Click);
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(505, 279);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(123, 23);
            this.helpButton.TabIndex = 2;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(505, 308);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(123, 23);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(505, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(123, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(505, 72);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(123, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.Visible = false;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(529, 137);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 7;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Visible = false;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(537, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "First Name";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(536, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Last Name";
            this.label2.Visible = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(529, 166);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Visible = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(505, 111);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(123, 20);
            this.textBox3.TabIndex = 6;
            this.textBox3.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(547, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Grade";
            this.label3.Visible = false;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(59, 7);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(156, 20);
            this.textBox4.TabIndex = 13;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Search";
            // 
            // deleteStudent
            // 
            this.deleteStudent.Location = new System.Drawing.Point(505, 250);
            this.deleteStudent.Name = "deleteStudent";
            this.deleteStudent.Size = new System.Drawing.Size(123, 23);
            this.deleteStudent.TabIndex = 15;
            this.deleteStudent.Text = "Delete Student";
            this.deleteStudent.UseVisualStyleBackColor = true;
            this.deleteStudent.Click += new System.EventHandler(this.button4_Click);
            // 
            // backtoStudents
            // 
            this.backtoStudents.Location = new System.Drawing.Point(505, 308);
            this.backtoStudents.Name = "backtoStudents";
            this.backtoStudents.Size = new System.Drawing.Size(123, 23);
            this.backtoStudents.TabIndex = 16;
            this.backtoStudents.Text = "Back";
            this.backtoStudents.UseVisualStyleBackColor = true;
            this.backtoStudents.Visible = false;
            this.backtoStudents.Click += new System.EventHandler(this.button5_Click);
            // 
            // addClass
            // 
            this.addClass.Location = new System.Drawing.Point(506, 221);
            this.addClass.Name = "addClass";
            this.addClass.Size = new System.Drawing.Size(123, 23);
            this.addClass.TabIndex = 17;
            this.addClass.Text = "Add Class";
            this.addClass.UseVisualStyleBackColor = true;
            this.addClass.Visible = false;
            this.addClass.Click += new System.EventHandler(this.addClass_Click);
            // 
            // deleteClass
            // 
            this.deleteClass.Location = new System.Drawing.Point(506, 250);
            this.deleteClass.Name = "deleteClass";
            this.deleteClass.Size = new System.Drawing.Size(123, 23);
            this.deleteClass.TabIndex = 18;
            this.deleteClass.Text = "Delete Class";
            this.deleteClass.UseVisualStyleBackColor = true;
            this.deleteClass.Visible = false;
            this.deleteClass.Click += new System.EventHandler(this.deleteClass_Click);
            // 
            // Semester1Grade
            // 
            this.Semester1Grade.AutoSize = true;
            this.Semester1Grade.Location = new System.Drawing.Point(502, 17);
            this.Semester1Grade.Name = "Semester1Grade";
            this.Semester1Grade.Size = new System.Drawing.Size(103, 13);
            this.Semester1Grade.TabIndex = 19;
            this.Semester1Grade.Text = "Semester 1 Average";
            this.Semester1Grade.Visible = false;
            // 
            // Semester2Grade
            // 
            this.Semester2Grade.AutoSize = true;
            this.Semester2Grade.Location = new System.Drawing.Point(503, 79);
            this.Semester2Grade.Name = "Semester2Grade";
            this.Semester2Grade.Size = new System.Drawing.Size(103, 13);
            this.Semester2Grade.TabIndex = 20;
            this.Semester2Grade.Text = "Semester 2 Average";
            this.Semester2Grade.Visible = false;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(505, 33);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(123, 20);
            this.textBox5.TabIndex = 21;
            this.textBox5.Visible = false;
            // 
            // Exempted1
            // 
            this.Exempted1.AutoSize = true;
            this.Exempted1.Location = new System.Drawing.Point(505, 59);
            this.Exempted1.Name = "Exempted1";
            this.Exempted1.Size = new System.Drawing.Size(79, 17);
            this.Exempted1.TabIndex = 22;
            this.Exempted1.Text = "Exempted?";
            this.Exempted1.UseVisualStyleBackColor = true;
            this.Exempted1.Visible = false;
            // 
            // Exempted2
            // 
            this.Exempted2.AutoSize = true;
            this.Exempted2.Location = new System.Drawing.Point(506, 125);
            this.Exempted2.Name = "Exempted2";
            this.Exempted2.Size = new System.Drawing.Size(79, 17);
            this.Exempted2.TabIndex = 24;
            this.Exempted2.Text = "Exempted?";
            this.Exempted2.UseVisualStyleBackColor = true;
            this.Exempted2.Visible = false;
            // 
            // AddAverage
            // 
            this.AddAverage.Location = new System.Drawing.Point(529, 148);
            this.AddAverage.Name = "AddAverage";
            this.AddAverage.Size = new System.Drawing.Size(75, 23);
            this.AddAverage.TabIndex = 24;
            this.AddAverage.Text = "Add";
            this.AddAverage.UseVisualStyleBackColor = true;
            this.AddAverage.Visible = false;
            this.AddAverage.Click += new System.EventHandler(this.AddAverage_Click);
            // 
            // CancelAverage
            // 
            this.CancelAverage.Location = new System.Drawing.Point(505, 308);
            this.CancelAverage.Name = "CancelAverage";
            this.CancelAverage.Size = new System.Drawing.Size(123, 23);
            this.CancelAverage.TabIndex = 25;
            this.CancelAverage.Text = "Cancel";
            this.CancelAverage.UseVisualStyleBackColor = true;
            this.CancelAverage.Visible = false;
            this.CancelAverage.Click += new System.EventHandler(this.CancelAverage_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(504, 99);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(124, 20);
            this.textBox6.TabIndex = 23;
            this.textBox6.Visible = false;
            // 
            // firstNameText
            // 
            this.firstNameText.AutoSize = true;
            this.firstNameText.Location = new System.Drawing.Point(221, 10);
            this.firstNameText.Name = "firstNameText";
            this.firstNameText.Size = new System.Drawing.Size(32, 13);
            this.firstNameText.TabIndex = 26;
            this.firstNameText.Text = "First: ";
            this.firstNameText.Visible = false;
            // 
            // lastNameText
            // 
            this.lastNameText.AutoSize = true;
            this.lastNameText.Location = new System.Drawing.Point(359, 10);
            this.lastNameText.Name = "lastNameText";
            this.lastNameText.Size = new System.Drawing.Size(33, 13);
            this.lastNameText.TabIndex = 27;
            this.lastNameText.Text = "Last: ";
            this.lastNameText.Visible = false;
            // 
            // labelAdded
            // 
            this.labelAdded.AutoSize = true;
            this.labelAdded.Location = new System.Drawing.Point(547, 205);
            this.labelAdded.Name = "labelAdded";
            this.labelAdded.Size = new System.Drawing.Size(41, 13);
            this.labelAdded.TabIndex = 28;
            this.labelAdded.Text = "Added!";
            this.labelAdded.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gradeLevel
            // 
            this.gradeLevel.Location = new System.Drawing.Point(589, 10);
            this.gradeLevel.Name = "gradeLevel";
            this.gradeLevel.Size = new System.Drawing.Size(39, 20);
            this.gradeLevel.TabIndex = 29;
            this.gradeLevel.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(544, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Grade:";
            this.label5.Visible = false;
            // 
            // MissingClass
            // 
            this.MissingClass.Location = new System.Drawing.Point(506, 250);
            this.MissingClass.Name = "MissingClass";
            this.MissingClass.Size = new System.Drawing.Size(122, 23);
            this.MissingClass.TabIndex = 31;
            this.MissingClass.Text = "Missing Class?";
            this.MissingClass.UseVisualStyleBackColor = true;
            this.MissingClass.Visible = false;
            this.MissingClass.Click += new System.EventHandler(this.MissingClass_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 347);
            this.Controls.Add(this.MissingClass);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gradeLevel);
            this.Controls.Add(this.labelAdded);
            this.Controls.Add(this.lastNameText);
            this.Controls.Add(this.firstNameText);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.CancelAverage);
            this.Controls.Add(this.AddAverage);
            this.Controls.Add(this.Exempted2);
            this.Controls.Add(this.Exempted1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.Semester2Grade);
            this.Controls.Add(this.Semester1Grade);
            this.Controls.Add(this.deleteClass);
            this.Controls.Add(this.addClass);
            this.Controls.Add(this.backtoStudents);
            this.Controls.Add(this.deleteStudent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.addStudent);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "GPA Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addStudent;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button deleteStudent;
        private System.Windows.Forms.Button backtoStudents;
        private System.Windows.Forms.Button addClass;
        private System.Windows.Forms.Button deleteClass;
        private System.Windows.Forms.Label Semester1Grade;
        private System.Windows.Forms.Label Semester2Grade;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.CheckBox Exempted1;
        private System.Windows.Forms.CheckBox Exempted2;
        private System.Windows.Forms.Button AddAverage;
        private System.Windows.Forms.Button CancelAverage;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label firstNameText;
        private System.Windows.Forms.Label lastNameText;
        private System.Windows.Forms.Label labelAdded;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox gradeLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button MissingClass;
    }
}

