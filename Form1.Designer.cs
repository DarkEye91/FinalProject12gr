namespace FinalProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            label6 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            pictureBox2 = new PictureBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Javanese Text", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(69, 11);
            label1.Name = "label1";
            label1.Size = new Size(296, 73);
            label1.TabIndex = 0;
            label1.Text = "Create an account";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Menu;
            textBox1.Font = new Font("Segoe Print", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(69, 109);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Username";
            textBox1.Size = new Size(112, 27);
            textBox1.TabIndex = 1;
            textBox1.Validating += textBox1_Validating_1;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Menu;
            textBox2.Font = new Font("Segoe Print", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(69, 151);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.PlaceholderText = "Password";
            textBox2.Size = new Size(112, 27);
            textBox2.TabIndex = 2;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.Menu;
            textBox3.Font = new Font("Segoe Print", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(69, 190);
            textBox3.Name = "textBox3";
            textBox3.PasswordChar = '*';
            textBox3.PlaceholderText = "Repeat Password";
            textBox3.Size = new Size(112, 27);
            textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.Menu;
            textBox4.Font = new Font("Segoe Print", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.Location = new Point(243, 109);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Phone Number";
            textBox4.Size = new Size(110, 27);
            textBox4.TabIndex = 4;
            textBox4.Validating += textBox4_Validating_1;
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.Menu;
            textBox5.Font = new Font("Segoe Print", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox5.Location = new Point(242, 151);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Email";
            textBox5.Size = new Size(110, 27);
            textBox5.TabIndex = 5;
            textBox5.Validating += textBox5_Validating;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarMonthBackground = SystemColors.Menu;
            dateTimePicker1.Location = new Point(202, 220);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ButtonHighlight;
            label2.Font = new Font("Segoe Print", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label2.Location = new Point(256, 196);
            label2.Name = "label2";
            label2.Size = new Size(97, 21);
            label2.TabIndex = 7;
            label2.Text = "Date of Birth ";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Menu;
            button1.Font = new Font("Javanese Text", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(164, 335);
            button1.Name = "button1";
            button1.Size = new Size(115, 46);
            button1.TabIndex = 8;
            button1.Text = "Sign Up";
            button1.TextAlign = ContentAlignment.TopCenter;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.Menu;
            button2.Font = new Font("Javanese Text", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(174, 402);
            button2.Name = "button2";
            button2.Size = new Size(96, 23);
            button2.TabIndex = 9;
            button2.Text = "Log in Instead";
            button2.TextAlign = ContentAlignment.BottomCenter;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ButtonHighlight;
            label3.Font = new Font("Palatino Linotype", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(69, 232);
            label3.Name = "label3";
            label3.Size = new Size(82, 16);
            label3.TabIndex = 10;
            label3.Text = "at least 5 letters";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ButtonHighlight;
            label4.Font = new Font("Palatino Linotype", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(69, 257);
            label4.Name = "label4";
            label4.Size = new Size(83, 16);
            label4.TabIndex = 11;
            label4.Text = "at least 1 capital";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ButtonHighlight;
            label5.Font = new Font("Palatino Linotype", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(69, 282);
            label5.Name = "label5";
            label5.Size = new Size(102, 16);
            label5.TabIndex = 12;
            label5.Text = "at least one number";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(439, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(361, 459);
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(215, 384);
            label6.Name = "label6";
            label6.Size = new Size(18, 15);
            label6.TabIndex = 14;
            label6.Text = "or";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ButtonHighlight;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.Location = new Point(-2, 87);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(442, 232);
            pictureBox2.TabIndex = 15;
            pictureBox2.TabStop = false;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(pictureBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private DateTimePicker dateTimePicker1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Label label3;
        private Label label4;
        private Label label5;
        private PictureBox pictureBox1;
        private Label label6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private PictureBox pictureBox2;
        private ErrorProvider errorProvider1;
    }
}