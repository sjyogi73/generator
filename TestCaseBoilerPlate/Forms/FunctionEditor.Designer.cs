namespace TestCaseBoilerplate.Forms
{
    partial class FunctionEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.funcNameTxtBox = new System.Windows.Forms.TextBox();
            this.returnTypeTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.accessSpectifierTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.isGenericCheckBox = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.parametersGrid = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dataRow = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.negativeDataRow = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parametersGrid)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataRow)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.negativeDataRow)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Function Name :";
            // 
            // funcNameTxtBox
            // 
            this.funcNameTxtBox.Location = new System.Drawing.Point(94, 3);
            this.funcNameTxtBox.Name = "funcNameTxtBox";
            this.funcNameTxtBox.ReadOnly = true;
            this.funcNameTxtBox.Size = new System.Drawing.Size(186, 20);
            this.funcNameTxtBox.TabIndex = 1;
            // 
            // returnTypeTxtBox
            // 
            this.returnTypeTxtBox.Location = new System.Drawing.Point(94, 29);
            this.returnTypeTxtBox.Name = "returnTypeTxtBox";
            this.returnTypeTxtBox.Size = new System.Drawing.Size(186, 20);
            this.returnTypeTxtBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Return Type :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(296, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Access Specifier :";
            // 
            // accessSpectifierTxtBox
            // 
            this.accessSpectifierTxtBox.Location = new System.Drawing.Point(387, 6);
            this.accessSpectifierTxtBox.Name = "accessSpectifierTxtBox";
            this.accessSpectifierTxtBox.Size = new System.Drawing.Size(137, 20);
            this.accessSpectifierTxtBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Is Generic :";
            // 
            // isGenericCheckBox
            // 
            this.isGenericCheckBox.AutoSize = true;
            this.isGenericCheckBox.Location = new System.Drawing.Point(507, 37);
            this.isGenericCheckBox.Name = "isGenericCheckBox";
            this.isGenericCheckBox.Size = new System.Drawing.Size(15, 14);
            this.isGenericCheckBox.TabIndex = 7;
            this.isGenericCheckBox.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(609, 6);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.funcNameTxtBox);
            this.panel1.Controls.Add(this.returnTypeTxtBox);
            this.panel1.Controls.Add(this.isGenericCheckBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.accessSpectifierTxtBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 65);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 472);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(687, 34);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 65);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(687, 407);
            this.panel3.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.parametersGrid);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(687, 103);
            this.panel4.TabIndex = 0;
            // 
            // parametersGrid
            // 
            this.parametersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.parametersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parametersGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parametersGrid.Location = new System.Drawing.Point(0, 0);
            this.parametersGrid.Name = "parametersGrid";
            this.parametersGrid.Size = new System.Drawing.Size(687, 103);
            this.parametersGrid.TabIndex = 10;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 103);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(687, 22);
            this.panel5.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Data Row";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dataRow);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.panel7.Size = new System.Drawing.Size(687, 144);
            this.panel7.TabIndex = 1;
            // 
            // dataRow
            // 
            this.dataRow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataRow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataRow.Location = new System.Drawing.Point(0, 0);
            this.dataRow.Name = "dataRow";
            this.dataRow.Size = new System.Drawing.Size(687, 139);
            this.dataRow.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.negativeDataRow);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 125);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(687, 282);
            this.panel6.TabIndex = 2;
            // 
            // negativeDataRow
            // 
            this.negativeDataRow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.negativeDataRow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.negativeDataRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.negativeDataRow.Location = new System.Drawing.Point(0, 144);
            this.negativeDataRow.Name = "negativeDataRow";
            this.negativeDataRow.Size = new System.Drawing.Size(687, 138);
            this.negativeDataRow.TabIndex = 2;
            // 
            // FunctionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 506);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FunctionEditor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Function Editor";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.parametersGrid)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataRow)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.negativeDataRow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox funcNameTxtBox;
        private System.Windows.Forms.TextBox returnTypeTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox accessSpectifierTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox isGenericCheckBox;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView parametersGrid;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView negativeDataRow;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView dataRow;
    }
}