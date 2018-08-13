namespace Stock_Programming
{
    partial class SignUpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUpForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.codeBox = new System.Windows.Forms.TextBox();
            this.idBox = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.checkBox = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.codeCheckBox = new System.Windows.Forms.TextBox();
            this.codeSameCheck = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelId = new System.Windows.Forms.Label();
            this.CanButton = new System.Windows.Forms.Button();
            this.SignButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.startMoney = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "회원 가입";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label22.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label22.Location = new System.Drawing.Point(45, 57);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(75, 21);
            this.label22.TabIndex = 19;
            this.label22.Text = "ID 입력 :";
            // 
            // codeBox
            // 
            this.codeBox.Location = new System.Drawing.Point(126, 100);
            this.codeBox.Name = "codeBox";
            this.codeBox.PasswordChar = '*';
            this.codeBox.Size = new System.Drawing.Size(100, 21);
            this.codeBox.TabIndex = 23;
            this.codeBox.Leave += new System.EventHandler(this.codeBox_Leave);
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(126, 58);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(100, 21);
            this.idBox.TabIndex = 20;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label24.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label24.Location = new System.Drawing.Point(23, 100);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(97, 21);
            this.label24.TabIndex = 22;
            this.label24.Text = "Code 입력 :";
            // 
            // checkBox
            // 
            this.checkBox.BackColor = System.Drawing.SystemColors.Highlight;
            this.checkBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox.Location = new System.Drawing.Point(232, 51);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(69, 34);
            this.checkBox.TabIndex = 21;
            this.checkBox.Text = "중복확인";
            this.checkBox.UseVisualStyleBackColor = false;
            this.checkBox.Click += new System.EventHandler(this.checkBox_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(23, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 21);
            this.label2.TabIndex = 24;
            this.label2.Text = "Code 확인 :";
            // 
            // codeCheckBox
            // 
            this.codeCheckBox.Location = new System.Drawing.Point(126, 127);
            this.codeCheckBox.Name = "codeCheckBox";
            this.codeCheckBox.PasswordChar = '*';
            this.codeCheckBox.Size = new System.Drawing.Size(100, 21);
            this.codeCheckBox.TabIndex = 25;
            this.codeCheckBox.Leave += new System.EventHandler(this.codeCheckBox_Leave);
            // 
            // codeSameCheck
            // 
            this.codeSameCheck.AutoSize = true;
            this.codeSameCheck.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.codeSameCheck.Location = new System.Drawing.Point(126, 153);
            this.codeSameCheck.Name = "codeSameCheck";
            this.codeSameCheck.Size = new System.Drawing.Size(0, 12);
            this.codeSameCheck.TabIndex = 26;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelId);
            this.groupBox1.Controls.Add(this.CanButton);
            this.groupBox1.Controls.Add(this.SignButton);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.startMoney);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.codeSameCheck);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.codeCheckBox);
            this.groupBox1.Controls.Add(this.checkBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.idBox);
            this.groupBox1.Controls.Add(this.codeBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 315);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Join Up";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(126, 82);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(0, 12);
            this.labelId.TabIndex = 43;
            // 
            // CanButton
            // 
            this.CanButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.CanButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CanButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CanButton.Location = new System.Drawing.Point(192, 217);
            this.CanButton.Name = "CanButton";
            this.CanButton.Size = new System.Drawing.Size(87, 50);
            this.CanButton.TabIndex = 37;
            this.CanButton.Text = "취소";
            this.CanButton.UseVisualStyleBackColor = false;
            this.CanButton.Click += new System.EventHandler(this.CanButton_Click);
            // 
            // SignButton
            // 
            this.SignButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.SignButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SignButton.Location = new System.Drawing.Point(81, 217);
            this.SignButton.Name = "SignButton";
            this.SignButton.Size = new System.Drawing.Size(87, 50);
            this.SignButton.TabIndex = 36;
            this.SignButton.Text = "가입";
            this.SignButton.UseVisualStyleBackColor = false;
            this.SignButton.Click += new System.EventHandler(this.SignButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(230, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 12);
            this.label7.TabIndex = 35;
            this.label7.Text = "(10만원~1000만원)";
            // 
            // startMoney
            // 
            this.startMoney.Location = new System.Drawing.Point(126, 172);
            this.startMoney.Name = "startMoney";
            this.startMoney.Size = new System.Drawing.Size(100, 21);
            this.startMoney.TabIndex = 33;
            this.startMoney.Leave += new System.EventHandler(this.startMoney_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(30, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 21);
            this.label6.TabIndex = 32;
            this.label6.Text = "시작 금액 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(234, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "(숫자만 입력하세요)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(398, 535);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 535);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SignUpForm";
            this.Text = "SignUpForm";
            this.Load += new System.EventHandler(this.SignUpForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox codeBox;
        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button checkBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox codeCheckBox;
        private System.Windows.Forms.Label codeSameCheck;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox startMoney;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button CanButton;
        private System.Windows.Forms.Button SignButton;
        private System.Windows.Forms.Label labelId;
    }
}