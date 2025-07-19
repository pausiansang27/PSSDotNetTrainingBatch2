namespace PSSDotNetTrainingBatch2.WinFormsApp1
{
    partial class FrmStaff
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
            label1 = new Label();
            txtStaffCode = new TextBox();
            label4 = new Label();
            txtStaffName = new TextBox();
            label5 = new Label();
            txtEmail = new TextBox();
            label2 = new Label();
            txtPassword = new TextBox();
            label3 = new Label();
            cboPosition = new ComboBox();
            label6 = new Label();
            txtMobileNo = new TextBox();
            btnSave = new Button();
            dgvData = new DataGridView();
            colEdit = new DataGridViewButtonColumn();
            colId = new DataGridViewTextBoxColumn();
            colStaffCode = new DataGridViewTextBoxColumn();
            colStaffName = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colPassword = new DataGridViewTextBoxColumn();
            colPosition = new DataGridViewTextBoxColumn();
            colMobileNo = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 12);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "Staff Code:";
            // 
            // txtStaffCode
            // 
            txtStaffCode.Location = new Point(25, 30);
            txtStaffCode.Name = "txtStaffCode";
            txtStaffCode.Size = new Size(181, 23);
            txtStaffCode.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 122);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 6;
            label4.Text = "Email:";
            // 
            // txtStaffName
            // 
            txtStaffName.Location = new Point(25, 83);
            txtStaffName.Name = "txtStaffName";
            txtStaffName.Size = new Size(181, 23);
            txtStaffName.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 65);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 8;
            label5.Text = "Staff Name:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(25, 140);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(181, 23);
            txtEmail.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 177);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 11;
            label2.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(25, 195);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(181, 23);
            txtPassword.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 231);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 13;
            label3.Text = "Position:";
            // 
            // cboPosition
            // 
            cboPosition.FormattingEnabled = true;
            cboPosition.Items.AddRange(new object[] { "--Select--", "Admin", "Staff" });
            cboPosition.Location = new Point(25, 249);
            cboPosition.Name = "cboPosition";
            cboPosition.Size = new Size(181, 23);
            cboPosition.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 284);
            label6.Name = "label6";
            label6.Size = new Size(66, 15);
            label6.TabIndex = 15;
            label6.Text = "Mobile No:";
            // 
            // txtMobileNo
            // 
            txtMobileNo.Location = new Point(25, 302);
            txtMobileNo.Name = "txtMobileNo";
            txtMobileNo.Size = new Size(181, 23);
            txtMobileNo.TabIndex = 16;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(131, 344);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 17;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { colEdit, colId, colStaffCode, colStaffName, colEmail, colPassword, colPosition, colMobileNo });
            dgvData.Location = new Point(248, 12);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.Size = new Size(531, 355);
            dgvData.TabIndex = 18;
            dgvData.CellContentClick += dgvData_CellContentClick;
            // 
            // colEdit
            // 
            colEdit.HeaderText = "Edit";
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            colEdit.Text = "Edit";
            colEdit.UseColumnTextForButtonValue = true;
            // 
            // colId
            // 
            colId.DataPropertyName = "StaffId";
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colStaffCode
            // 
            colStaffCode.DataPropertyName = "StaffCode";
            colStaffCode.HeaderText = "Staff Code";
            colStaffCode.Name = "colStaffCode";
            colStaffCode.ReadOnly = true;
            // 
            // colStaffName
            // 
            colStaffName.DataPropertyName = "StaffName";
            colStaffName.HeaderText = "Staff Name";
            colStaffName.Name = "colStaffName";
            colStaffName.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.DataPropertyName = "EmailAddress";
            colEmail.HeaderText = "Email";
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colPassword
            // 
            colPassword.DataPropertyName = "Password";
            colPassword.HeaderText = "Password";
            colPassword.Name = "colPassword";
            colPassword.ReadOnly = true;
            // 
            // colPosition
            // 
            colPosition.DataPropertyName = "Position";
            colPosition.HeaderText = "Position";
            colPosition.Name = "colPosition";
            colPosition.ReadOnly = true;
            // 
            // colMobileNo
            // 
            colMobileNo.DataPropertyName = "MobileNo";
            colMobileNo.HeaderText = "Mobile No";
            colMobileNo.Name = "colMobileNo";
            colMobileNo.ReadOnly = true;
            // 
            // FrmStaff
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 397);
            Controls.Add(dgvData);
            Controls.Add(btnSave);
            Controls.Add(txtMobileNo);
            Controls.Add(label6);
            Controls.Add(cboPosition);
            Controls.Add(label3);
            Controls.Add(txtPassword);
            Controls.Add(label2);
            Controls.Add(txtEmail);
            Controls.Add(txtStaffName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtStaffCode);
            Controls.Add(label1);
            Name = "FrmStaff";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Staff";
            Load += FrmStaff_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtStaffCode;
        private Label label4;
        private TextBox txtStaffName;
        private Label label5;
        private TextBox txtEmail;
        private Label label2;
        private TextBox txtPassword;
        private Label label3;
        private ComboBox cboPosition;
        private Label label6;
        private TextBox txtMobileNo;
        private Button btnSave;
        private DataGridView dgvData;
        private DataGridViewButtonColumn colEdit;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colStaffCode;
        private DataGridViewTextBoxColumn colStaffName;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colPassword;
        private DataGridViewTextBoxColumn colPosition;
        private DataGridViewTextBoxColumn colMobileNo;
    }
}
