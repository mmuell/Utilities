namespace EncoderTester
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ConnectPB = new System.Windows.Forms.Button();
            this.SerialPortST = new System.Windows.Forms.Label();
            this.SerialPortsCB = new System.Windows.Forms.ComboBox();
            this.DisconnectPB = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.CommandCB = new System.Windows.Forms.ComboBox();
            this.OutputET = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ConnectPB
            // 
            this.ConnectPB.Location = new System.Drawing.Point(204, 10);
            this.ConnectPB.Name = "ConnectPB";
            this.ConnectPB.Size = new System.Drawing.Size(75, 23);
            this.ConnectPB.TabIndex = 0;
            this.ConnectPB.Text = "Connect";
            this.ConnectPB.UseVisualStyleBackColor = true;
            this.ConnectPB.Click += new System.EventHandler(this.ConnectPB_Click);
            // 
            // SerialPortST
            // 
            this.SerialPortST.AutoSize = true;
            this.SerialPortST.Location = new System.Drawing.Point(13, 13);
            this.SerialPortST.Name = "SerialPortST";
            this.SerialPortST.Size = new System.Drawing.Size(58, 13);
            this.SerialPortST.TabIndex = 1;
            this.SerialPortST.Text = "Serial Port:";
            // 
            // SerialPortsCB
            // 
            this.SerialPortsCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SerialPortsCB.FormattingEnabled = true;
            this.SerialPortsCB.Location = new System.Drawing.Point(77, 10);
            this.SerialPortsCB.Name = "SerialPortsCB";
            this.SerialPortsCB.Size = new System.Drawing.Size(121, 21);
            this.SerialPortsCB.TabIndex = 2;
            // 
            // DisconnectPB
            // 
            this.DisconnectPB.Location = new System.Drawing.Point(285, 10);
            this.DisconnectPB.Name = "DisconnectPB";
            this.DisconnectPB.Size = new System.Drawing.Size(75, 23);
            this.DisconnectPB.TabIndex = 3;
            this.DisconnectPB.Text = "Disconnect";
            this.DisconnectPB.UseVisualStyleBackColor = true;
            this.DisconnectPB.Click += new System.EventHandler(this.DisconnectPB_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(204, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Run Command";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CommandCB
            // 
            this.CommandCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CommandCB.FormattingEnabled = true;
            this.CommandCB.Items.AddRange(new object[] {
            "GetTicks",
            "GetDegrees"});
            this.CommandCB.Location = new System.Drawing.Point(77, 51);
            this.CommandCB.Name = "CommandCB";
            this.CommandCB.Size = new System.Drawing.Size(121, 21);
            this.CommandCB.TabIndex = 5;
            // 
            // OutputET
            // 
            this.OutputET.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputET.Location = new System.Drawing.Point(13, 78);
            this.OutputET.Name = "OutputET";
            this.OutputET.Size = new System.Drawing.Size(536, 303);
            this.OutputET.TabIndex = 6;
            this.OutputET.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 387);
            this.Controls.Add(this.OutputET);
            this.Controls.Add(this.CommandCB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DisconnectPB);
            this.Controls.Add(this.SerialPortsCB);
            this.Controls.Add(this.SerialPortST);
            this.Controls.Add(this.ConnectPB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Encoder Tester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectPB;
        private System.Windows.Forms.Label SerialPortST;
        private System.Windows.Forms.ComboBox SerialPortsCB;
        private System.Windows.Forms.Button DisconnectPB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CommandCB;
        private System.Windows.Forms.RichTextBox OutputET;
    }
}

