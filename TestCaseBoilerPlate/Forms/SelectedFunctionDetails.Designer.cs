namespace TestCaseBoilerplate.Forms
{
    partial class SelectedFunctionDetails
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
            this.SaveBtn = new System.Windows.Forms.Button();
            this.selectedTextLbl = new System.Windows.Forms.Label();
            this.openFile_Dialog = new System.Windows.Forms.OpenFileDialog();
            this.file_txt = new System.Windows.Forms.TextBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.all_public_chkbx = new System.Windows.Forms.CheckBox();
            this.all_private_chkbx = new System.Windows.Forms.CheckBox();
            this.lbl_txt = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveBtn
            // 
            this.SaveBtn.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.Location = new System.Drawing.Point(482, 57);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(56, 19);
            this.SaveBtn.TabIndex = 0;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // selectedTextLbl
            // 
            this.selectedTextLbl.AutoSize = true;
            this.selectedTextLbl.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedTextLbl.Location = new System.Drawing.Point(194, 50);
            this.selectedTextLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selectedTextLbl.Name = "selectedTextLbl";
            this.selectedTextLbl.Size = new System.Drawing.Size(0, 13);
            this.selectedTextLbl.TabIndex = 1;
            // 
            // openFile_Dialog
            // 
            this.openFile_Dialog.FileName = "openFile_Dialog";
            // 
            // file_txt
            // 
            this.file_txt.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.file_txt.Location = new System.Drawing.Point(8, 25);
            this.file_txt.Margin = new System.Windows.Forms.Padding(2);
            this.file_txt.Name = "file_txt";
            this.file_txt.Size = new System.Drawing.Size(458, 21);
            this.file_txt.TabIndex = 2;
            // 
            // browseBtn
            // 
            this.browseBtn.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseBtn.Location = new System.Drawing.Point(482, 25);
            this.browseBtn.Margin = new System.Windows.Forms.Padding(2);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(56, 21);
            this.browseBtn.TabIndex = 3;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // all_public_chkbx
            // 
            this.all_public_chkbx.AutoSize = true;
            this.all_public_chkbx.Checked = true;
            this.all_public_chkbx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.all_public_chkbx.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.all_public_chkbx.Location = new System.Drawing.Point(8, 59);
            this.all_public_chkbx.Margin = new System.Windows.Forms.Padding(2);
            this.all_public_chkbx.Name = "all_public_chkbx";
            this.all_public_chkbx.Size = new System.Drawing.Size(73, 17);
            this.all_public_chkbx.TabIndex = 4;
            this.all_public_chkbx.Text = "All Public";
            this.all_public_chkbx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.all_public_chkbx.UseVisualStyleBackColor = true;
            // 
            // all_private_chkbx
            // 
            this.all_private_chkbx.AutoSize = true;
            this.all_private_chkbx.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.all_private_chkbx.Location = new System.Drawing.Point(96, 59);
            this.all_private_chkbx.Margin = new System.Windows.Forms.Padding(2);
            this.all_private_chkbx.Name = "all_private_chkbx";
            this.all_private_chkbx.Size = new System.Drawing.Size(77, 17);
            this.all_private_chkbx.TabIndex = 5;
            this.all_private_chkbx.Text = "All Private";
            this.all_private_chkbx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.all_private_chkbx.UseVisualStyleBackColor = true;
            // 
            // lbl_txt
            // 
            this.lbl_txt.AutoSize = true;
            this.lbl_txt.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_txt.Location = new System.Drawing.Point(6, 9);
            this.lbl_txt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_txt.Name = "lbl_txt";
            this.lbl_txt.Size = new System.Drawing.Size(85, 13);
            this.lbl_txt.TabIndex = 6;
            this.lbl_txt.Text = "Select Test File";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_txt);
            this.panel1.Controls.Add(this.SaveBtn);
            this.panel1.Controls.Add(this.all_private_chkbx);
            this.panel1.Controls.Add(this.selectedTextLbl);
            this.panel1.Controls.Add(this.all_public_chkbx);
            this.panel1.Controls.Add(this.file_txt);
            this.panel1.Controls.Add(this.browseBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 287);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 88);
            this.panel1.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(549, 287);
            this.dataGridView1.TabIndex = 8;
            // 
            // SelectedFunctionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 375);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectedFunctionDetails";
            this.Text = "SelectedFunctionDetails";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label selectedTextLbl;
        private System.Windows.Forms.OpenFileDialog openFile_Dialog;
        private System.Windows.Forms.TextBox file_txt;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.CheckBox all_public_chkbx;
        private System.Windows.Forms.CheckBox all_private_chkbx;
        private System.Windows.Forms.Label lbl_txt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}