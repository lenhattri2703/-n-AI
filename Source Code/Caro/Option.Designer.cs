namespace Giao_Dien
{
    partial class NewGame
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bnt_OK = new System.Windows.Forms.Button();
            this.radio_PvsP = new System.Windows.Forms.RadioButton();
            this.radio_PvsC = new System.Windows.Forms.RadioButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.Easy_Dlg = new System.Windows.Forms.RadioButton();
            this.Medium_Dlg = new System.Windows.Forms.RadioButton();
            this.Hard_Dlg = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Com = new System.Windows.Forms.RadioButton();
            this.You = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(507, 444);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(78, 23);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(168, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // bnt_OK
            // 
            this.bnt_OK.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bnt_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnt_OK.Location = new System.Drawing.Point(411, 444);
            this.bnt_OK.Name = "bnt_OK";
            this.bnt_OK.Size = new System.Drawing.Size(78, 23);
            this.bnt_OK.TabIndex = 7;
            this.bnt_OK.Text = "OK";
            this.bnt_OK.UseVisualStyleBackColor = false;
            this.bnt_OK.Click += new System.EventHandler(this.button1_Click);
            // 
            // radio_PvsP
            // 
            this.radio_PvsP.AutoSize = true;
            this.radio_PvsP.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_PvsP.ForeColor = System.Drawing.Color.Red;
            this.radio_PvsP.Location = new System.Drawing.Point(126, 66);
            this.radio_PvsP.Name = "radio_PvsP";
            this.radio_PvsP.Size = new System.Drawing.Size(183, 30);
            this.radio_PvsP.TabIndex = 8;
            this.radio_PvsP.Text = "Hai người chơi";
            this.radio_PvsP.UseVisualStyleBackColor = true;
            this.radio_PvsP.CheckedChanged += new System.EventHandler(this.radio_PvsP_CheckedChanged);
            // 
            // radio_PvsC
            // 
            this.radio_PvsC.AutoSize = true;
            this.radio_PvsC.Checked = true;
            this.radio_PvsC.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_PvsC.ForeColor = System.Drawing.Color.Blue;
            this.radio_PvsC.Location = new System.Drawing.Point(126, 182);
            this.radio_PvsC.Name = "radio_PvsC";
            this.radio_PvsC.Size = new System.Drawing.Size(188, 30);
            this.radio_PvsC.TabIndex = 9;
            this.radio_PvsC.TabStop = true;
            this.radio_PvsC.Text = "Một người chơi";
            this.radio_PvsC.UseVisualStyleBackColor = true;
            this.radio_PvsC.CheckedChanged += new System.EventHandler(this.radio_PvsC_CheckedChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(280, 137);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(223, 20);
            this.textBox2.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(280, 107);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(223, 20);
            this.textBox1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(122, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nhập tên người chơi 2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(122, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nhập tên người chơi 1:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(280, 224);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(223, 20);
            this.textBox3.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(124, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 19);
            this.label4.TabIndex = 14;
            this.label4.Text = "Nhập tên của bạn:";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(467, 192);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(17, 13);
            this.textBox4.TabIndex = 17;
            // 
            // Easy_Dlg
            // 
            this.Easy_Dlg.AutoSize = true;
            this.Easy_Dlg.Location = new System.Drawing.Point(16, 36);
            this.Easy_Dlg.Name = "Easy_Dlg";
            this.Easy_Dlg.Size = new System.Drawing.Size(45, 21);
            this.Easy_Dlg.TabIndex = 23;
            this.Easy_Dlg.Text = "Dễ";
            this.Easy_Dlg.UseVisualStyleBackColor = true;
            this.Easy_Dlg.CheckedChanged += new System.EventHandler(this.Easy_Dlg_CheckedChanged);
            // 
            // Medium_Dlg
            // 
            this.Medium_Dlg.AutoSize = true;
            this.Medium_Dlg.Checked = true;
            this.Medium_Dlg.Location = new System.Drawing.Point(138, 36);
            this.Medium_Dlg.Name = "Medium_Dlg";
            this.Medium_Dlg.Size = new System.Drawing.Size(100, 21);
            this.Medium_Dlg.TabIndex = 24;
            this.Medium_Dlg.TabStop = true;
            this.Medium_Dlg.Text = "Trung Bình";
            this.Medium_Dlg.UseVisualStyleBackColor = true;
            this.Medium_Dlg.CheckedChanged += new System.EventHandler(this.Medium_Dlg_CheckedChanged);
            // 
            // Hard_Dlg
            // 
            this.Hard_Dlg.AutoSize = true;
            this.Hard_Dlg.Location = new System.Drawing.Point(309, 36);
            this.Hard_Dlg.Name = "Hard_Dlg";
            this.Hard_Dlg.Size = new System.Drawing.Size(54, 21);
            this.Hard_Dlg.TabIndex = 25;
            this.Hard_Dlg.Text = "Khó";
            this.Hard_Dlg.UseVisualStyleBackColor = true;
            this.Hard_Dlg.CheckedChanged += new System.EventHandler(this.Hard_Dlg_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.Easy_Dlg);
            this.groupBox1.Controls.Add(this.Hard_Dlg);
            this.groupBox1.Controls.Add(this.Medium_Dlg);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(126, 350);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 81);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Level";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.Com);
            this.groupBox2.Controls.Add(this.You);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(128, 256);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 83);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            // 
            // Com
            // 
            this.Com.AutoSize = true;
            this.Com.Checked = true;
            this.Com.Location = new System.Drawing.Point(16, 36);
            this.Com.Name = "Com";
            this.Com.Size = new System.Drawing.Size(129, 21);
            this.Com.TabIndex = 23;
            this.Com.TabStop = true;
            this.Com.Text = "Máy đánh trước";
            this.Com.UseVisualStyleBackColor = true;
            this.Com.CheckedChanged += new System.EventHandler(this.Com_CheckedChanged);
            // 
            // You
            // 
            this.You.AutoSize = true;
            this.You.Location = new System.Drawing.Point(230, 36);
            this.You.Name = "You";
            this.You.Size = new System.Drawing.Size(126, 21);
            this.You.TabIndex = 24;
            this.You.Text = "Bạn đánh trước";
            this.You.UseVisualStyleBackColor = true;
            this.You.CheckedChanged += new System.EventHandler(this.You_CheckedChanged);
            // 
            // NewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(598, 479);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radio_PvsC);
            this.Controls.Add(this.radio_PvsP);
            this.Controls.Add(this.bnt_OK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewGame";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu hình ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bnt_OK;
        private System.Windows.Forms.RadioButton radio_PvsP;
        private System.Windows.Forms.RadioButton radio_PvsC;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.RadioButton Easy_Dlg;
        private System.Windows.Forms.RadioButton Medium_Dlg;
        private System.Windows.Forms.RadioButton Hard_Dlg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton Com;
        private System.Windows.Forms.RadioButton You;
    }
}