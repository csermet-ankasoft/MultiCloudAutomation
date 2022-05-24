namespace MultiCloudAutomation.Forms
{
    partial class AZURE_CREDENTIAL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AZURE_CREDENTIAL));
            this.button2 = new System.Windows.Forms.Button();
            this.labelTest = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxClientSecret = new System.Windows.Forms.TextBox();
            this.textBoxClientID = new System.Windows.Forms.TextBox();
            this.textBoxTenantID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSubscriptionID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(260, 275);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 41);
            this.button2.TabIndex = 5;
            this.button2.Text = "Düzenle";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTest.Location = new System.Drawing.Point(15, 327);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(214, 25);
            this.labelTest.TabIndex = 7;
            this.labelTest.Text = "HTTP Kodu : Waiting...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Client Secret ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Client ID";
            // 
            // textBoxClientSecret
            // 
            this.textBoxClientSecret.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxClientSecret.Location = new System.Drawing.Point(20, 110);
            this.textBoxClientSecret.Name = "textBoxClientSecret";
            this.textBoxClientSecret.PasswordChar = '*';
            this.textBoxClientSecret.ReadOnly = true;
            this.textBoxClientSecret.Size = new System.Drawing.Size(360, 29);
            this.textBoxClientSecret.TabIndex = 2;
            // 
            // textBoxClientID
            // 
            this.textBoxClientID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxClientID.Location = new System.Drawing.Point(20, 46);
            this.textBoxClientID.Name = "textBoxClientID";
            this.textBoxClientID.ReadOnly = true;
            this.textBoxClientID.Size = new System.Drawing.Size(360, 29);
            this.textBoxClientID.TabIndex = 1;
            // 
            // textBoxTenantID
            // 
            this.textBoxTenantID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTenantID.Location = new System.Drawing.Point(20, 173);
            this.textBoxTenantID.Name = "textBoxTenantID";
            this.textBoxTenantID.PasswordChar = '*';
            this.textBoxTenantID.ReadOnly = true;
            this.textBoxTenantID.Size = new System.Drawing.Size(360, 29);
            this.textBoxTenantID.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tenant ID";
            // 
            // textBoxSubscriptionID
            // 
            this.textBoxSubscriptionID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSubscriptionID.Location = new System.Drawing.Point(20, 240);
            this.textBoxSubscriptionID.Name = "textBoxSubscriptionID";
            this.textBoxSubscriptionID.PasswordChar = '*';
            this.textBoxSubscriptionID.ReadOnly = true;
            this.textBoxSubscriptionID.Size = new System.Drawing.Size(360, 29);
            this.textBoxSubscriptionID.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Subscription ID";
            // 
            // AZURE_CREDENTIAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(404, 370);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelTest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSubscriptionID);
            this.Controls.Add(this.textBoxTenantID);
            this.Controls.Add(this.textBoxClientSecret);
            this.Controls.Add(this.textBoxClientID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AZURE_CREDENTIAL";
            this.Text = "Multi Cloud Automation";
            this.Load += new System.EventHandler(this.AZURE_CREDENTIAL_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxClientSecret;
        private System.Windows.Forms.TextBox textBoxClientID;
        private System.Windows.Forms.TextBox textBoxTenantID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSubscriptionID;
        private System.Windows.Forms.Label label5;
    }
}