namespace MultiCloudAutomation.Forms
{
    partial class AzureAddInstance
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
            this.comboBoxRegion = new System.Windows.Forms.ComboBox();
            this.comboBoxResourceGroup = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxOsType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxnic = new System.Windows.Forms.ComboBox();
            this.textBoxComputerName = new System.Windows.Forms.TextBox();
            this.textBoxVMName = new System.Windows.Forms.TextBox();
            this.textBoxadminusername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxadminpass = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxRegion
            // 
            this.comboBoxRegion.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.comboBoxRegion.Enabled = false;
            this.comboBoxRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRegion.ForeColor = System.Drawing.SystemColors.Desktop;
            this.comboBoxRegion.FormattingEnabled = true;
            this.comboBoxRegion.Items.AddRange(new object[] {
            "australiaeast"});
            this.comboBoxRegion.Location = new System.Drawing.Point(149, 60);
            this.comboBoxRegion.Name = "comboBoxRegion";
            this.comboBoxRegion.Size = new System.Drawing.Size(297, 28);
            this.comboBoxRegion.TabIndex = 2;
            this.comboBoxRegion.Text = "australiaeast";
            // 
            // comboBoxResourceGroup
            // 
            this.comboBoxResourceGroup.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.comboBoxResourceGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResourceGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxResourceGroup.FormattingEnabled = true;
            this.comboBoxResourceGroup.Location = new System.Drawing.Point(149, 26);
            this.comboBoxResourceGroup.Name = "comboBoxResourceGroup";
            this.comboBoxResourceGroup.Size = new System.Drawing.Size(297, 28);
            this.comboBoxResourceGroup.TabIndex = 1;
            this.comboBoxResourceGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxResourceGroup_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(76, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Region :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Resource Group :";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(254, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 50);
            this.button1.TabIndex = 10;
            this.button1.Text = "Create Instance";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Computer Name :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(96, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Size :";
            // 
            // textBoxSize
            // 
            this.textBoxSize.Enabled = false;
            this.textBoxSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSize.Location = new System.Drawing.Point(149, 94);
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.Size = new System.Drawing.Size(297, 26);
            this.textBoxSize.TabIndex = 3;
            this.textBoxSize.Text = "StandardB1s";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(69, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Os Type :";
            // 
            // comboBoxOsType
            // 
            this.comboBoxOsType.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.comboBoxOsType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOsType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxOsType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxOsType.ForeColor = System.Drawing.SystemColors.Desktop;
            this.comboBoxOsType.FormattingEnabled = true;
            this.comboBoxOsType.Items.AddRange(new object[] {
            "Windows",
            "Linux"});
            this.comboBoxOsType.Location = new System.Drawing.Point(149, 126);
            this.comboBoxOsType.Name = "comboBoxOsType";
            this.comboBoxOsType.Size = new System.Drawing.Size(297, 28);
            this.comboBoxOsType.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(57, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "VM Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "NIC Name :";
            // 
            // comboBoxnic
            // 
            this.comboBoxnic.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.comboBoxnic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxnic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxnic.FormattingEnabled = true;
            this.comboBoxnic.Location = new System.Drawing.Point(149, 290);
            this.comboBoxnic.Name = "comboBoxnic";
            this.comboBoxnic.Size = new System.Drawing.Size(297, 28);
            this.comboBoxnic.TabIndex = 9;
            // 
            // textBoxComputerName
            // 
            this.textBoxComputerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxComputerName.Location = new System.Drawing.Point(149, 194);
            this.textBoxComputerName.Name = "textBoxComputerName";
            this.textBoxComputerName.Size = new System.Drawing.Size(297, 26);
            this.textBoxComputerName.TabIndex = 6;
            // 
            // textBoxVMName
            // 
            this.textBoxVMName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxVMName.Location = new System.Drawing.Point(149, 160);
            this.textBoxVMName.Name = "textBoxVMName";
            this.textBoxVMName.Size = new System.Drawing.Size(297, 26);
            this.textBoxVMName.TabIndex = 5;
            // 
            // textBoxadminusername
            // 
            this.textBoxadminusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxadminusername.Location = new System.Drawing.Point(149, 226);
            this.textBoxadminusername.Name = "textBoxadminusername";
            this.textBoxadminusername.Size = new System.Drawing.Size(297, 26);
            this.textBoxadminusername.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Admin Username :";
            // 
            // textBoxadminpass
            // 
            this.textBoxadminpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxadminpass.Location = new System.Drawing.Point(149, 258);
            this.textBoxadminpass.Name = "textBoxadminpass";
            this.textBoxadminpass.Size = new System.Drawing.Size(297, 26);
            this.textBoxadminpass.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 261);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "Admin Password :";
            // 
            // AzureAddInstance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(459, 397);
            this.Controls.Add(this.comboBoxOsType);
            this.Controls.Add(this.comboBoxRegion);
            this.Controls.Add(this.comboBoxnic);
            this.Controls.Add(this.comboBoxResourceGroup);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxSize);
            this.Controls.Add(this.textBoxVMName);
            this.Controls.Add(this.textBoxadminpass);
            this.Controls.Add(this.textBoxadminusername);
            this.Controls.Add(this.textBoxComputerName);
            this.Name = "AzureAddInstance";
            this.Text = "AzureAddInstance";
            this.Load += new System.EventHandler(this.AzureAddInstance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxRegion;
        private System.Windows.Forms.ComboBox comboBoxResourceGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxOsType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxnic;
        private System.Windows.Forms.TextBox textBoxComputerName;
        private System.Windows.Forms.TextBox textBoxVMName;
        private System.Windows.Forms.TextBox textBoxadminusername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxadminpass;
        private System.Windows.Forms.Label label10;
    }
}