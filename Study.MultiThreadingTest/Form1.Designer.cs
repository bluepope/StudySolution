
namespace Study.MultiThreadingTest
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTaskCancel = new System.Windows.Forms.Button();
            this.btnTaskRun = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThreadCancel = new System.Windows.Forms.Button();
            this.btnThreadRun = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.lblThreadId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblProgressPercent = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnViewModelGridCancel = new System.Windows.Forms.Button();
            this.btnViewModelGridRun = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnControlGridCancel = new System.Windows.Forms.Button();
            this.btnControlGridRun = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.lblThreadId);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.lblProgressPercent);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(800, 217);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thread 스터디 기초";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnTaskCancel);
            this.groupBox3.Controls.Add(this.btnTaskRun);
            this.groupBox3.Location = new System.Drawing.Point(527, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(216, 72);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Task 테스트";
            // 
            // btnTaskCancel
            // 
            this.btnTaskCancel.Location = new System.Drawing.Point(111, 22);
            this.btnTaskCancel.Name = "btnTaskCancel";
            this.btnTaskCancel.Size = new System.Drawing.Size(88, 34);
            this.btnTaskCancel.TabIndex = 7;
            this.btnTaskCancel.Text = "취소";
            this.btnTaskCancel.UseVisualStyleBackColor = true;
            // 
            // btnTaskRun
            // 
            this.btnTaskRun.Location = new System.Drawing.Point(17, 22);
            this.btnTaskRun.Name = "btnTaskRun";
            this.btnTaskRun.Size = new System.Drawing.Size(88, 34);
            this.btnTaskRun.TabIndex = 6;
            this.btnTaskRun.Text = "실행";
            this.btnTaskRun.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThreadCancel);
            this.groupBox2.Controls.Add(this.btnThreadRun);
            this.groupBox2.Location = new System.Drawing.Point(281, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 78);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thread 테스트";
            // 
            // btnThreadCancel
            // 
            this.btnThreadCancel.Location = new System.Drawing.Point(111, 22);
            this.btnThreadCancel.Name = "btnThreadCancel";
            this.btnThreadCancel.Size = new System.Drawing.Size(88, 34);
            this.btnThreadCancel.TabIndex = 7;
            this.btnThreadCancel.Text = "취소";
            this.btnThreadCancel.UseVisualStyleBackColor = true;
            // 
            // btnThreadRun
            // 
            this.btnThreadRun.Location = new System.Drawing.Point(17, 22);
            this.btnThreadRun.Name = "btnThreadRun";
            this.btnThreadRun.Size = new System.Drawing.Size(88, 34);
            this.btnThreadRun.TabIndex = 6;
            this.btnThreadRun.Text = "실행";
            this.btnThreadRun.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnRun);
            this.groupBox1.Location = new System.Drawing.Point(281, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 74);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BackgroundWorker 테스트";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(111, 27);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 34);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(17, 27);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(88, 34);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "실행";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // lblThreadId
            // 
            this.lblThreadId.AutoSize = true;
            this.lblThreadId.Location = new System.Drawing.Point(139, 97);
            this.lblThreadId.Name = "lblThreadId";
            this.lblThreadId.Size = new System.Drawing.Size(17, 15);
            this.lblThreadId.TabIndex = 12;
            this.lblThreadId.Text = "--";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "동작스레드ID";
            // 
            // lblProgressPercent
            // 
            this.lblProgressPercent.AutoSize = true;
            this.lblProgressPercent.Location = new System.Drawing.Point(142, 67);
            this.lblProgressPercent.Name = "lblProgressPercent";
            this.lblProgressPercent.Size = new System.Drawing.Size(14, 15);
            this.lblProgressPercent.TabIndex = 10;
            this.lblProgressPercent.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "진행률";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.dataGridView1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 217);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(800, 233);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "groupBox5";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnViewModelGridCancel);
            this.groupBox7.Controls.Add(this.btnViewModelGridRun);
            this.groupBox7.Location = new System.Drawing.Point(544, 118);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(216, 72);
            this.groupBox7.TabIndex = 17;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "뷰모델 수정";
            // 
            // btnViewModelGridCancel
            // 
            this.btnViewModelGridCancel.Location = new System.Drawing.Point(111, 22);
            this.btnViewModelGridCancel.Name = "btnViewModelGridCancel";
            this.btnViewModelGridCancel.Size = new System.Drawing.Size(88, 34);
            this.btnViewModelGridCancel.TabIndex = 7;
            this.btnViewModelGridCancel.Text = "취소";
            this.btnViewModelGridCancel.UseVisualStyleBackColor = true;
            this.btnViewModelGridCancel.Click += new System.EventHandler(this.btnViewModelGridCancel_Click);
            // 
            // btnViewModelGridRun
            // 
            this.btnViewModelGridRun.Location = new System.Drawing.Point(17, 22);
            this.btnViewModelGridRun.Name = "btnViewModelGridRun";
            this.btnViewModelGridRun.Size = new System.Drawing.Size(88, 34);
            this.btnViewModelGridRun.TabIndex = 6;
            this.btnViewModelGridRun.Text = "실행";
            this.btnViewModelGridRun.UseVisualStyleBackColor = true;
            this.btnViewModelGridRun.Click += new System.EventHandler(this.btnViewModelGridRun_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnControlGridCancel);
            this.groupBox6.Controls.Add(this.btnControlGridRun);
            this.groupBox6.Location = new System.Drawing.Point(544, 22);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(216, 72);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "컨트롤 직접 수정";
            // 
            // btnControlGridCancel
            // 
            this.btnControlGridCancel.Location = new System.Drawing.Point(111, 22);
            this.btnControlGridCancel.Name = "btnControlGridCancel";
            this.btnControlGridCancel.Size = new System.Drawing.Size(88, 34);
            this.btnControlGridCancel.TabIndex = 7;
            this.btnControlGridCancel.Text = "취소";
            this.btnControlGridCancel.UseVisualStyleBackColor = true;
            this.btnControlGridCancel.Click += new System.EventHandler(this.btnControlGridCancel_Click);
            // 
            // btnControlGridRun
            // 
            this.btnControlGridRun.Location = new System.Drawing.Point(17, 22);
            this.btnControlGridRun.Name = "btnControlGridRun";
            this.btnControlGridRun.Size = new System.Drawing.Size(88, 34);
            this.btnControlGridRun.TabIndex = 6;
            this.btnControlGridRun.Text = "실행";
            this.btnControlGridRun.UseVisualStyleBackColor = true;
            this.btnControlGridRun.Click += new System.EventHandler(this.btnControlGridRun_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(12, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(457, 133);
            this.dataGridView1.TabIndex = 10;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Col1";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnTaskCancel;
        private System.Windows.Forms.Button btnTaskRun;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnThreadCancel;
        private System.Windows.Forms.Button btnThreadRun;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lblThreadId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblProgressPercent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnViewModelGridCancel;
        private System.Windows.Forms.Button btnViewModelGridRun;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnControlGridCancel;
        private System.Windows.Forms.Button btnControlGridRun;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}

