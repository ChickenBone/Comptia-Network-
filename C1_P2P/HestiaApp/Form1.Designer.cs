namespace HestiaApp
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
            this.SendBox = new System.Windows.Forms.RichTextBox();
            this.ChatBox = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ClearChat = new System.Windows.Forms.Button();
            this.SendButton = new System.Windows.Forms.Button();
            this.HelpButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SendBox
            // 
            this.SendBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.SendBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SendBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendBox.ForeColor = System.Drawing.Color.White;
            this.SendBox.Location = new System.Drawing.Point(3, 238);
            this.SendBox.Name = "SendBox";
            this.SendBox.Size = new System.Drawing.Size(474, 35);
            this.SendBox.TabIndex = 2;
            this.SendBox.Text = "";
            this.SendBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            // 
            // ChatBox
            // 
            this.ChatBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ChatBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChatBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ChatBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatBox.ForeColor = System.Drawing.Color.White;
            this.ChatBox.Location = new System.Drawing.Point(3, 3);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ReadOnly = true;
            this.ChatBox.Size = new System.Drawing.Size(474, 229);
            this.ChatBox.TabIndex = 0;
            this.ChatBox.Text = "[i] Welcome To Hestia v1.0-b2";
            this.ChatBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.ChatBox_LinkClicked);
            this.ChatBox.TextChanged += new System.EventHandler(this.ChatBox_TextChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.ChatBox);
            this.flowLayoutPanel1.Controls.Add(this.SendBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(511, 289);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // ClearChat
            // 
            this.ClearChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClearChat.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ClearChat.FlatAppearance.BorderSize = 0;
            this.ClearChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearChat.ForeColor = System.Drawing.Color.White;
            this.ClearChat.Location = new System.Drawing.Point(535, 195);
            this.ClearChat.Name = "ClearChat";
            this.ClearChat.Size = new System.Drawing.Size(95, 36);
            this.ClearChat.TabIndex = 4;
            this.ClearChat.Text = "Clear Chat";
            this.ClearChat.UseVisualStyleBackColor = false;
            this.ClearChat.Click += new System.EventHandler(this.ClearChat_Click);
            // 
            // SendButton
            // 
            this.SendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.SendButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.SendButton.FlatAppearance.BorderSize = 0;
            this.SendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendButton.ForeColor = System.Drawing.Color.White;
            this.SendButton.Location = new System.Drawing.Point(535, 237);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(95, 36);
            this.SendButton.TabIndex = 5;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = false;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // HelpButton
            // 
            this.HelpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.HelpButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.HelpButton.FlatAppearance.BorderSize = 0;
            this.HelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HelpButton.ForeColor = System.Drawing.Color.White;
            this.HelpButton.Location = new System.Drawing.Point(535, 153);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(95, 36);
            this.HelpButton.TabIndex = 6;
            this.HelpButton.Text = "Help";
            this.HelpButton.UseVisualStyleBackColor = false;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::HestiaApp.Properties.Resources.image;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(535, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(95, 60);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(534, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 35);
            this.label1.TabIndex = 8;
            this.label1.Text = "Hestia";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(642, 313);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.ClearChat);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button ClearChat;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.RichTextBox SendBox;
        public System.Windows.Forms.RichTextBox ChatBox;
        private System.Windows.Forms.Label label1;
    }
}

