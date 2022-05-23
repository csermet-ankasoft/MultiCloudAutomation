namespace MultiCloudAutomation.Forms
{
    partial class First_Page
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
            this.buttonAzureCred = new System.Windows.Forms.Button();
            this.buttonAWSCred = new System.Windows.Forms.Button();
            this.buttonVM = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAzureCred
            // 
            this.buttonAzureCred.BackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonAzureCred.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAzureCred.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAzureCred.Location = new System.Drawing.Point(21, 231);
            this.buttonAzureCred.Name = "buttonAzureCred";
            this.buttonAzureCred.Size = new System.Drawing.Size(164, 100);
            this.buttonAzureCred.TabIndex = 0;
            this.buttonAzureCred.Text = "Azure Credential";
            this.buttonAzureCred.UseVisualStyleBackColor = false;
            this.buttonAzureCred.Click += new System.EventHandler(this.buttonAzureCred_Click);
            // 
            // buttonAWSCred
            // 
            this.buttonAWSCred.BackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonAWSCred.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAWSCred.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAWSCred.Location = new System.Drawing.Point(21, 71);
            this.buttonAWSCred.Name = "buttonAWSCred";
            this.buttonAWSCred.Size = new System.Drawing.Size(164, 100);
            this.buttonAWSCred.TabIndex = 0;
            this.buttonAWSCred.Text = "AWS Credential";
            this.buttonAWSCred.UseVisualStyleBackColor = false;
            this.buttonAWSCred.Click += new System.EventHandler(this.buttonAWSCRED);
            // 
            // buttonVM
            // 
            this.buttonVM.BackColor = System.Drawing.Color.MediumPurple;
            this.buttonVM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVM.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVM.Location = new System.Drawing.Point(41, 66);
            this.buttonVM.Name = "buttonVM";
            this.buttonVM.Size = new System.Drawing.Size(199, 110);
            this.buttonVM.TabIndex = 1;
            this.buttonVM.Text = "Sanal Makineler";
            this.buttonVM.UseVisualStyleBackColor = false;
            this.buttonVM.Click += new System.EventHandler(this.buttonVM_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonAWSCred);
            this.panel1.Controls.Add(this.buttonAzureCred);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(279, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 361);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "CREDENTIALS";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.MediumPurple;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(41, 221);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(199, 110);
            this.button4.TabIndex = 1;
            this.button4.Text = "Depolama Alanları";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateBlue;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.buttonVM);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(279, 361);
            this.panel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "[-- SERVISLER --]";
            // 
            // First_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "First_Page";
            this.Text = "Multi Cloud Automation";
            this.Load += new System.EventHandler(this.First_Page_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAzureCred;
        private System.Windows.Forms.Button buttonAWSCred;
        private System.Windows.Forms.Button buttonVM;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
    }
}